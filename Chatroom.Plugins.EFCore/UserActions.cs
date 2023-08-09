using Chatroom.CoreModel;
using Chatroom.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatroom.Plugins.EFCore
{
    public class UserActions : IUserActions
    {
        private readonly ChatroomContext db;

        public UserActions(ChatroomContext db)
        {
            this.db = db;
        }

        public async Task<bool> SignInAction(string email, string password)
        {
            User user = await db.User.FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
            {
                return false;
            }

            bool passwordMatch = user.Password == password;

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

        public async Task EditUserProfileAsync()
        {

        }

        public async Task DeleteUserProfileAsync()
        {

        }       
    }
}
