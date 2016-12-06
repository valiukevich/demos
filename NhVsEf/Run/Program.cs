using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Run
{
    using Core;

    using Models;

    using NH;

    class Program
    {
        static void Main(string[] args)
        {
            IUnitOfWorkFactory factory = new NH.NhUnitOfWorkFactory();
            using (var uow = factory.Create())
            {
                var repository = new Repository<PwModule>(uow.DbContext);
                var repository2 = new Repository<TModule>(uow.DbContext);
                var modules = repository.Read().ToList();
                var modules2 = repository2.Read().ToList();
                modules.FirstOrDefault()?.Histories.Clear();
            }
        }
    }
}
