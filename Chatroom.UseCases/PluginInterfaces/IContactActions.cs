using Chatroom.CoreModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatroom.UseCases.PluginInterfaces
{
    public interface IContactActions
    {
        Task<(User?, string)> AddContact(string uniqueName, Guid userId);

        Task<List<User>> FetchContacts(Guid userId);
    }
}
