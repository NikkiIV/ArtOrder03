using ArtOrder03.Core.Contracts;
using ArtOrder03.Core.Models.User;
using ArtOrder03.Infrastructure.Data.Repositories;
using ArtOrder03.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;

namespace ArtOrder03.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IApplicationDbRepository? repo;

        public UserService(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }

        public async Task<ApplicationUser> GetUserById(string id)
        {
            return await repo.GetByIdAsync<ApplicationUser>(id);
        }

        public async Task<UserEditViewModel> GetUserForEdit(string id)
        {
            var user = await repo.GetByIdAsync<ApplicationUser>(id);

            var theUser = new UserEditViewModel()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName
            };

            return theUser;
        }

        public async Task<IEnumerable<UserListViewModel>> GetUsers()
        {
            var users = await repo.All<ApplicationUser>().
                Select(u => new UserListViewModel()
                {
                    Email = u.Email,
                    Id = u.Id,
                    Name = $"{u.FirstName} {u.LastName}"
                })
                .ToListAsync();

            return users;
        }

        public async Task<bool> UpdateUser(UserEditViewModel model)
        {
            bool result = false;
            var user = await repo.GetByIdAsync<ApplicationUser>(model.Id);

            if (user != null)
            {
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;

                await repo.SaveChangesAsync();
                result = true;
            }

            return result;
        }
    }
}
