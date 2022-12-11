using LibraryApplication.Domain.Interfaces;
using LibraryApplication.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ICollection<User>> GetAll()
        {
            return await _userRepository.GetAll();
        }

        public async Task<User> GetById(int id)
        {
            return await _userRepository.GetById(id);
        }

        public User Add(User user)
        {
            if (_userRepository.Search(b => b.UserName == user.UserName).Result.Any())
                return null;

            _userRepository.Add(user);
            return user;
        }

        public async Task<bool> Update(User user)
        {
            bool result = await _userRepository.Update(user);

            if (result)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> Remove(User user)
        {
            await _userRepository.Remove(user);
            return true;
        }

        public void Dispose()
        {
            _userRepository?.Dispose();
        }
    }
}
