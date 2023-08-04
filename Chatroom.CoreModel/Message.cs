using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatroom.CoreModel
{
    public class Message
    {
        public int MessageId { get; set; }

        public string? Context { get; set; }

        public DateTime? Created { get; set; }

        public User? User { get; set; }
    }
}
