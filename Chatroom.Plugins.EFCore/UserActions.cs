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
 
            this.passwordHashCompare = new PasswordHashCompare();
            this.passwordHashCreate = new PasswordHashCreate();
        }

        public async Task<bool> SignInAction(string email, string password)
        {
            User? user = await db.User.FirstOrDefaultAsync(u => u.Email.ToLower() == email);

            if (user == null)
            {
                return false;
            }

            // Just for dummy data
            if (password == "1234567" || password == "Password")
            {
                return true;
            }

            bool passwordMatch = await passwordHashCompare.VerifyPassword(user.Password, password);

            return passwordMatch;
        }

        public async Task<User> GetUserDetails(string email)
        {
            User user = await db.User.FirstOrDefaultAsync(u => u.Email == email);

            if (user != null)
            {
                return user;
            }

            return null;
        }

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

            user.Password = await passwordHashCreate.HashPassword(user.Password);

            db.User.Add(user);
            db.SaveChanges();

            return ("Success, Welcome!", true);
        }
    }
}
