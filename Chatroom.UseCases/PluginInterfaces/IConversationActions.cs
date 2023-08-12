using Chatroom.CoreModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatroom.UseCases.PluginInterfaces
{
    public interface IConversationActions
    {
        Task<List<User>> GetConversations(Guid userId);
    }
}
