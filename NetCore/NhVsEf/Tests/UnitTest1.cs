using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using EF;
using Microsoft.EntityFrameworkCore;
using Models;
using Xunit;

namespace Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Cleanup()
        {
            var countriesContext = new CountriesContext();
            countriesContext.Database.EnsureDeleted();
            countriesContext.Database.EnsureCreated();
        }
        
        [Fact]
        public void EF_Test1()
        {
            IUnitOfWorkFactory factory = new EfUnitOfWorkFactory();
            using (var uow = factory.Create())
            {
                var repository = new Repository<Country>(uow.DbContext);

                var dataSeed = new Country()
                {
                    Name = "USA",
                    Cities = new List<City>()
                    {
                        new City() { Name = "NY"},
                        new City() { Name = "LA"},
                    }
                };
                repository.Create(dataSeed);
                uow.SaveChanges();

                var country = repository.Where(x => x.Id == 1).FirstOrDefault();
                Assert.NotNull(country);
                Assert.True(country.Cities.Any());

                #region Fix

                var efContext = (DbContext)uow.DbContext.Original;
                var cities = country.Cities.ToArray();
                for (var index = 0; index < cities.Length; index++)
                {
                    var history = cities[index];
                    efContext.Entry(history).State = EntityState.Deleted;
                }

                #endregion

                country.Cities.Clear();


                uow.SaveChanges();
            }
            using (var uow = factory.Create())
            {
                var repository = new Repository<Country>(uow.DbContext);
                var country = repository.Where(x => x.Id == 1).Include(x => x.Cities).FirstOrDefault();
                Assert.NotNull(country);
                Assert.True(!country.Cities.Any());

                repository.Delete(country);
            }
        }

       
    }
}
