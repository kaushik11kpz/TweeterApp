using com.tweetapp.Models;
using com.tweetapp.Models.Dtos.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace com.tweetapp.Data.IRepository
{
    public interface IUserRepository
    {
        public Task<bool> CreateUserAsync(Users userDetails);

        public Task<IEnumerable<Users>> GetAllUsersAsync();

        public Task<Users> GetUserAsync(string userId);

        public Task<Users> LoginUser(UserCredentials credential);

        public Task<bool> IsUserAlreadyExist(string userId);

        public Task<bool> updatePassword(string userId, string newPassword);

        public Task<bool> CheckSecurityCredential(ForgotPasswordDto credential);
    }
}
