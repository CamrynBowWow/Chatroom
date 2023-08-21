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
        Task<Dictionary<int, User>> GetConversations(Guid userId);

        Task<(int, bool)> CreateConversations(User recipientUser, Guid userId);
    }
}
