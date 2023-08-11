using Chatroom.UseCases.Interfaces;
using Chatroom.CoreModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chatroom.UseCases.PluginInterfaces;

namespace Chatroom.UseCases.UserActions
{
    public class CreateUserUseCase : ICreateUser
    {
        private readonly IUserActions userActions;

        public CreateUserUseCase(IUserActions userActions)
        {
            this.userActions = userActions;
        }

        public async Task<(string, bool)> ExecuteAsync(User user)
        {
            return await userActions.CreateUser(user);
        }
    }
}
