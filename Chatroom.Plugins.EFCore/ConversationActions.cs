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
    public class ConversationActions : IConversationActions
    {
        private readonly ChatroomContext db;

        public ConversationActions(ChatroomContext db)
        {
            this.db = db;
        }

        public async Task DeleteConversation()
        {

        }

        public async Task CreateConversation()
        {

        }

        public async Task<List<User>> GetConversations(Guid userId)
        {
            List<Conversation> conversation = await db.Conversation.Where(c => c.StartedUser == userId || c.RecipientUser == userId).ToListAsync();

            List<User> user = new();
                
            foreach (Conversation con in conversation)
            {
                user.AddRange(await db.User.Where(u => (u.UserId == con.RecipientUser || u.UserId == con.StartedUser) && u.UserId != userId).ToListAsync());
            }

            return user;
        }
    }
}
