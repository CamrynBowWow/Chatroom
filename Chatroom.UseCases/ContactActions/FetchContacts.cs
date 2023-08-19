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
    public class FetchContacts : IFetchContacts
    {
        private readonly IContactActions contactActions;

        public FetchContacts(IContactActions contactActions)
        {
            this.contactActions = contactActions;
        }

        public async Task<List<User>> ExecuteAsync(Guid userId)
        {
            return await contactActions.FetchContacts(userId);
        }
    }
}
