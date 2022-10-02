using AutoMapper;
using com.tweetapp.Data.IRepository;
using com.tweetapp.Models;
using com.tweetapp.Models.Dtos.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace com.tweetapp.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _user;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepo, IMapper mapper)
        {
            _user = userRepo;
            _mapper = mapper;
        }
        public async Task<bool> RegisterUserAsync(CreateUserDto userDetails)
        {
            try
            {
                var user = _mapper.Map<Users>(userDetails);
                bool respone = await _user.CreateUserAsync(user);
                return respone;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<IEnumerable<ViewUserDto>> GetAllUsersAsync()
        {
            try
            {
                var users = await _user.GetAllUsersAsync();
                var userDetail = new List<ViewUserDto>();
                foreach (var user in users)
                {
                    userDetail.Add(_mapper.Map<ViewUserDto>(user));
                }
                return userDetail;
            }
            catch(Exception ex)
            {
                return null;
            }
            
        }

        public async Task<ViewUserDto> GetUserAsync(string userId)
        {
            try
            {
                var user = await _user.GetUserAsync(userId);
                return _mapper.Map<ViewUserDto>(user);
            }
            catch(Exception ex)
            {
                return null;
            }
            
        }

        public async Task<bool?> IsEmailIdAlreadyExist(string emailId)
        {
            try
            {
                return await _user.IsUserAlreadyExist(emailId);
            }
            catch(Exception ex)
            {
                return null;
            }
            
        }

        public async Task<ViewUserDto> UserLogin(UserCredentials credential)
        {
            var user = await _user.LoginUser(credential);
            if (user != null)
            {
                return _mapper.Map<ViewUserDto>(user);
            }
            return null;
        }

        public async Task<bool> ResetPassword(string userId, string newPassword)
        {
            var result = await _user.updatePassword(userId, newPassword);

            return result;
        }

        public async Task<bool> ValidateSecurityCredential(ForgotPasswordDto credentilas)
        {
            var result = await _user.CheckSecurityCredential(credentilas);
            return result;
        }
    }
}
