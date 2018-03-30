using Common;

namespace EF
{
    public class EfUnitOfWorkFactory : IUnitOfWorkFactory
    {
        public IUnitOfWork Create()
        {
            var countriesContext = new CountriesContext();
            return new EfUnitOfWork(countriesContext);
        }
    }
}