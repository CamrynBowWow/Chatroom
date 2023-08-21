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
    public class CreateConversation : ICreateConversation
    {
        private readonly IConversationActions conversationActions;

        public CreateConversation(IConversationActions conversationActions)
        {
            this.conversationActions = conversationActions;
        }

        public async Task<(int, bool)> ExecuteAsync(User recipientUser, Guid userId)
        {
            return await conversationActions.CreateConversations(recipientUser, userId);
        }
    }
}
