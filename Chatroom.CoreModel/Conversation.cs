using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatroom.CoreModel
{
    public class Conversation
    {
        public int ConversationId { get; set; }

        public List<User>? UserNames { get; set; } 

        public List<Message>? MessageIds { get; set; } 

        public ICollection<UserConversation>? UserConversations { get; set; }
    }
}
