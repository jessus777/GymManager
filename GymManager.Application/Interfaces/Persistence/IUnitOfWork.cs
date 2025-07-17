using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.Application.Interfaces.Persistence
{
    public interface IUnitOfWork
        : IDisposable
    {
        Task<int> SaveChangesAsync();
        // Métodos para transacciones explícitas
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
