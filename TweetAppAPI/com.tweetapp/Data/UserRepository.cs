using com.tweetapp.Data.IRepository;
using com.tweetapp.Models;
using com.tweetapp.Models.Dtos.UserDto;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace com.tweetapp.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<Users> _users;
        public UserRepository(IMongoClient mongoClient, IConfiguration config)
        {
            var database = mongoClient.GetDatabase("tweetapp");
            _users = database.GetCollection<Users>(config.GetValue<string>("CosmosDbSettings:UsersCollectionName"));
        }
        public async Task<bool> CreateUserAsync(Users userDetails)
        {
             await _users.InsertOneAsync(userDetails);
             return true;
        }

        public async Task<IEnumerable<Users>> GetAllUsersAsync()
        {
            return await _users.Find(s => true).ToListAsync();
        }

        public async Task<Users> GetUserAsync(string userId)
        {
            return await _users.Find(s => s.EmailId == userId).FirstOrDefaultAsync();
        }

        public async Task<Users> LoginUser(UserCredentials credential)
        {
            return await _users.Find(s => s.EmailId == credential.EmailId && s.Password == credential.Password).FirstOrDefaultAsync();
        }

        public async Task<bool> IsUserAlreadyExist(string userId)
        {
            return await _users.Find(s => s.EmailId == userId).FirstOrDefaultAsync() != null;
        }

        public async Task<bool> updatePassword(string userId, string newPassword)
        {
            var result = await _users.UpdateOneAsync(t => t.EmailId == userId, Builders<Users>.Update.Set(m => m.Password, newPassword));
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

        public async Task<bool> CheckSecurityCredential(ForgotPasswordDto credential)
        {
            var result = await _users.Find(m => m.EmailId == credential.EmailId && 
            m.SecurityQuestion == credential.SecurityQuestion && 
            m.SecurityAnswer.ToLower() == credential.SecurityAnswer.ToLower()).FirstOrDefaultAsync();

            return result != null;
        }
    }
}
