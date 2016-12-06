//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="EfUnitOfWorkFactory.cs" company="Noordhoff Uitgevers BV">
//      © Noordhoff Uitgevers BV, the Netherlands
//  </copyright>
//   <author>Valiukevich, Evgeny</author>
//  --------------------------------------------------------------------------------------------------------------------
namespace EF
{
    using Core;

    public class EfUnitOfWorkFactory : IUnitOfWorkFactory
    {
        public EfUnitOfWorkFactory()
        {
        }

        public IUnitOfWork Create()
        {
            return new EfUnitOfWork(new CountriesContext());
        }
    }
}