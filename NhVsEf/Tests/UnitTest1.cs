using System.Data.Entity;
using System.Linq;
using Core;
using EF;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using NH;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void EF_Test1()
        {
            IUnitOfWorkFactory factory = new EfUnitOfWorkFactory();
            using (var uow = factory.Create())
            {
                var repository = new Repository<Country>(uow.DbContext);
                var module = repository.Where(x => x.Id == "1").FirstOrDefault();
                Assert.IsNotNull(module);
                Assert.IsTrue(module.Cities.Any());

                #region Fix

                var efContext = (DbContext) uow.DbContext.Original;
                var pwModuleHistories = module.Cities.ToArray();
                for (var index = 0; index < pwModuleHistories.Length; index++)
                {
                    var history = pwModuleHistories[index];
                    efContext.Entry(history).State = EntityState.Deleted;
                }

                #endregion

                module.Cities.Clear();


                uow.SaveChanges();
            }
            using (var uow = factory.Create())
            {
                var repository = new Repository<Country>(uow.DbContext);
                var module = repository.Where(x => x.Id == "1").FirstOrDefault();
                Assert.IsNotNull(module);
                Assert.IsTrue(!module.Cities.Any());
            }
        }

        [TestMethod]
        public void NH_Test1()
        {
            IUnitOfWorkFactory factory = new NhUnitOfWorkFactory();
            using (var uow = factory.Create())
            {
                var repository = new Repository<Country>(uow.DbContext);

                var module = repository.Where(x => x.Id == "1").FirstOrDefault();

                Assert.IsNotNull(module);
                Assert.IsTrue(module.Cities.Any());

                module.Cities.Clear();
            }

            using (var uow = factory.Create())
            {
                var repository = new Repository<Country>(uow.DbContext);
                var module = repository.Where(x => x.Id == "1").FirstOrDefault();
                Assert.IsNotNull(module);
                Assert.IsTrue(!module.Cities.Any());
            }
        }
    }
}