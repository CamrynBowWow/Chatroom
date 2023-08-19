using Chatroom.CoreModel;
using Chatroom.UseCases.Interfaces;
using Chatroom.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatroom.UseCases.ContactActions
{
    public class AddContact : IAddContact
    {
        private readonly IContactActions contactActions;

        public AddContact(IContactActions contactActions)
        {
            this.contactActions = contactActions;
        }

        public async Task<(User?, string)> ExecuteAsync(string uniqueName, Guid userId)
        {
            return await contactActions.AddContact(uniqueName, userId);
        }
    }
}
