using com.tweetapp.Models;
using com.tweetapp.Models.Dtos.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace com.tweetapp.Services
{
    public interface IUserService
    {
        public Task<bool> RegisterUserAsync(CreateUserDto userDetails);

        public Task<IEnumerable<ViewUserDto>> GetAllUsersAsync();

        public Task<ViewUserDto> GetUserAsync(string userId);

        public Task<ViewUserDto> UserLogin(UserCredentials credential);

        public Task<bool?> IsEmailIdAlreadyExist(string emailId);

        public Task<bool> ResetPassword(string userId, string newPassword);

        public Task<bool> ValidateSecurityCredential(ForgotPasswordDto credentilas);
    }
}
