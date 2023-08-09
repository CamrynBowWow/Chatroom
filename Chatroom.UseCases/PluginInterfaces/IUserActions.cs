using Chatroom.CoreModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatroom.UseCases.PluginInterfaces
{
    public interface IUserActions
    {
        Task<bool> SignInAction(string email, string password);

        Task<User> GetUserDetails(string email);
    }
}
