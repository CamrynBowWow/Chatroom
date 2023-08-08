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

        public Guid StartedUser { get; set; }

        public Guid RecipientUser { get; set; }

        public ICollection<Message>? Messages { get; set; }
    }
}
