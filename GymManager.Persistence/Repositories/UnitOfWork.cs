using GymManager.Application.Interfaces.Persistence;
using GymManager.Domain.Entities;
using GymManager.Persistence.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage;

namespace GymManager.Persistence.Repositories
{
    public class UnitOfWork
        : IUnitOfWork
    {
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _context;
        private IDbContextTransaction _transaction;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        private IUserRepositoryAsync _userRepositoryAsync;

        public IUserRepositoryAsync UserRepositoryAsync =>
            _userRepositoryAsync ??= new UserRepositoryAsync(_context, _userManager);

        public async Task BeginTransactionAsync()
        {
            if (_transaction != null)
                return; // Ya hay una transacción activa

            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            if (_transaction == null)
                throw new InvalidOperationException("No hay transacción activa.");

            await _transaction.CommitAsync();
            await _transaction.DisposeAsync();
            _transaction = null;
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task RollbackAsync()
        {
            if (_transaction == null)
                throw new InvalidOperationException("No hay transacción activa.");

            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
            _transaction = null;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
