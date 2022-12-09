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

        public User Add(User User)
        {
            if (_userRepository.Search(b => b.UserName == User.UserName).Result.Any())
                return null;

            _userRepository.Add(User);
            return User;
        }

        public async Task<User> Update(User User)
        {
            if (_userRepository.Search(b => b.UserName == User.UserName && b.Id != User.Id).Result.Any())
                return null;

            await _userRepository.Update(User);
            return User;
        }

        public async Task<bool> Remove(User User)
        {
            await _userRepository.Remove(User);
            return true;
        }

        public void Dispose()
        {
            _userRepository?.Dispose();
        }
    }
}
