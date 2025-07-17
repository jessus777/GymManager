using GymManager.Application.Interfaces.Persistence;
using GymManager.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;

namespace GymManager.Persistence.Repositories
{
    public class UserRepositoryAsync
        : IUserRepositoryAsync
    {
        private readonly UserManager<User> _userManager;

        public UserRepositoryAsync(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public Task AddAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> ChangePasswordAsync(User user, string currentPassword, string newPassword)
        {
            return await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
        }

        public async Task<IdentityResult> CreateAsync(User user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public Task<IEnumerable<User>> FindAsync(Expression<Func<User, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Remove(User entity)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
