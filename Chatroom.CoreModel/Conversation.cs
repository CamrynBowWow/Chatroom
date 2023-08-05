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

        public User? User { get; set; } // Might need to make an array for it

        public Message[]? Message { get; set; } // Maybe make this a list
    }
}
