using System;

namespace Common
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Save changes in both LPS and Admin
        /// </summary>
        void SaveChanges();

        IDbContext DbContext { get; }
    }
}