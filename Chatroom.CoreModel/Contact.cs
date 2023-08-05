using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatroom.CoreModel
{
    public class Contact
    {
        public int ContactId { get; set; }

        public User? User { get; set; }
    }
}
