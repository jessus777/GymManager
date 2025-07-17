using GymManager.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace GymManager.Application.Interfaces.Persistence
{
    public interface IUserRepositoryAsync
        : IRepository<User, Guid>
    {
        Task<User?> FindByEmailAsync(string email);
        Task<IdentityResult> CreateAsync(User user, string password);
        Task<IdentityResult> ChangePasswordAsync(User user, string currentPassword, string newPassword);
    }
}
