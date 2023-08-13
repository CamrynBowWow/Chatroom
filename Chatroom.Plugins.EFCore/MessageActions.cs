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
    public class MessageActions : IMessageActions
    {
        private readonly ChatroomContext db;

        public MessageActions(ChatroomContext db)
        {
            this.db = db;
        }

        public async Task<List<Message>> FetchMessages(Guid HostUserId, Guid OtherUserId)
        {
            var conversationId = await db.Conversation.FirstOrDefaultAsync(c => (c.StartedUser == HostUserId || c.StartedUser == OtherUserId) && (c.RecipientUser == HostUserId || c.RecipientUser == OtherUserId));

            List<Message> messages = await db.Message.Where(m => m.ConversationId == conversationId.ConversationId).ToListAsync();

            return messages;
        }

        public async Task SendMessageAsync()
        {

        }
    }
}
