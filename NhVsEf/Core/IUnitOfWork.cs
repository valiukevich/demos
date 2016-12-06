namespace Core
{
    using System;
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Save changes in both LPS and Admin
        /// </summary>
        void SaveChanges();

        IDbContext DbContext { get; }
    }
}