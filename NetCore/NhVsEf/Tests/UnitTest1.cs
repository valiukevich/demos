using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using EF;
using Microsoft.EntityFrameworkCore;
using Models;
using NH;
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
            var countryId = DoDataSeed().Id;
            IUnitOfWorkFactory factory = new EfUnitOfWorkFactory();
            using (var uow = factory.Create())
            {
                var repository = new Repository<Country>(uow.DbContext);
                var country = repository.Where(x => x.Id == countryId).Include(x => x.Cities).FirstOrDefault();
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
                var country = repository.Where(x => x.Id == countryId).Include(x => x.Cities).FirstOrDefault();
                Assert.NotNull(country);
                Assert.True(!country.Cities.Any());

                repository.Delete(country);
            }
        }

        private static Country DoDataSeed()
        {
            IUnitOfWorkFactory factory = new EfUnitOfWorkFactory();
            using (var uow = factory.Create())
            {
                var repository = new Repository<Country>(uow.DbContext);
                var dataSeed = new Country()
                {
                    Name = "USA",
                    Cities = new List<City>()
                };
                dataSeed.Cities.Add(new City() { Country = dataSeed, Name = "NY" });
                dataSeed.Cities.Add(new City() { Country = dataSeed, Name = "LA" });
                repository.Create(dataSeed);
                return dataSeed;
            }
        }

        [Fact]
        public void NH_Test1()
        {
            var countryId = DoDataSeed().Id;
            IUnitOfWorkFactory factory = new NhUnitOfWorkFactory();
            using (var uow = factory.Create())
            {
                var repository = new Repository<Country>(uow.DbContext);
                var country = repository.Where(x => x.Id == countryId).FirstOrDefault();
                Assert.NotNull(country);
                Assert.True(country.Cities.Any());

                country.Cities.Clear();
            }

            using (var uow = factory.Create())
            {
                var repository = new Repository<Country>(uow.DbContext);
                var country = repository.Where(x => x.Id == countryId).Include(x => x.Cities).FirstOrDefault();
                Assert.NotNull(country);
                Assert.True(!country.Cities.Any());

                repository.Delete(country);
            }
        }

    }
}
