using Chatroom.CoreModel;
using Chatroom.UseCases.Interfaces;
using Chatroom.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatroom.UseCases.ConversationActions
{
    public class FetchConversations : IFetchConversations
    {
        private readonly IConversationActions conversationActions;

        public FetchConversations(IConversationActions conversationActions)
        {
            this.conversationActions = conversationActions;
        }

        public async Task<List<User>> ExecuteAsync(Guid userId)
        {
            return await conversationActions.GetConversations(userId);
        }
    }
}
