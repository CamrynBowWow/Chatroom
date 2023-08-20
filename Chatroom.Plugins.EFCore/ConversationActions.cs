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

        public async Task<Dictionary<int, User>> GetConversations(Guid userId)
        {
            List<Conversation> conversation = await db.Conversation.Where(c => c.StartedUser == userId || c.RecipientUser == userId).ToListAsync();

            User user = new();

            Dictionary<int, User> userDictionary = new Dictionary<int, User>();
                
            foreach (Conversation con in conversation)
            {
                user = await db.User.FirstOrDefaultAsync(u => (u.UserId == con.RecipientUser || u.UserId == con.StartedUser) && u.UserId != userId);

                if (user != null)
                {
                    userDictionary.Add(con.ConversationId, user);
                }
            }

            return userDictionary;
        }

        public Task<int> CreateConversations(User recipientUser, Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
