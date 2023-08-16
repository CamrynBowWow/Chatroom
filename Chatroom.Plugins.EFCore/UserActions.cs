using Chatroom.CoreModel;
using Chatroom.UseCases.Methods;
using Chatroom.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Chatroom.Plugins.EFCore
{
    public class UserActions : IUserActions
    {
        private readonly ChatroomContext db;
        private readonly PasswordHashCompare passwordHashCompare;
        private readonly PasswordHashCreate passwordHashCreate;

        public UserActions(ChatroomContext db)
        {
            
            this.db = db;
            // instances of the PasswordHashCompare and PasswordHashCreate 
            this.passwordHashCompare = new PasswordHashCompare();
            this.passwordHashCreate = new PasswordHashCreate();
        }

        /// HERE: Password
        public async Task<bool> SignInAction(string email, string password)
        {
            User user = await db.User.FirstOrDefaultAsync(u => u.Email.ToLower() == email);

            if (user == null)
            {
                return false;
            }

            // compared with the hashed user input 
            bool passwordMatch = PasswordHashCompare.VerifyPassword(user.Password, password);

            return passwordMatch;
        }

        public async Task<User> GetUserDetails(string email)
        {
            User user = await db.User.FirstOrDefaultAsync(u => u.Email == email);

            if (user != null)
            {
                return user; // Maybe Return Specificed data
            }

            return null;
        }

        // Maybe make return something else
        /// HERE: Password
        public async Task<(string, bool)> CreateUser(User user)
        {
            if (db.User.Any(u => u.Email == user.Email))
            {
                return ("Email Already Exist.", false);
            }
            
            if (db.User.Any(u => u.UniqueName == user.UniqueName))
            {
                return ("Unique Name Already Exist.", false);
            }


            string passwordToHash = user.Password;
            user.Password = passwordHashCreate.HashPassword(passwordToHash);
            db.User.Add(user);
            db.SaveChanges();

            return ("Success, Welcome!", true);
        }
    }
}
