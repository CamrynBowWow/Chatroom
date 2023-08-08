using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatroom.CoreModel
{
    public class ContactList
    {
        public int ContactId { get; set; }

        public Guid UserId { get; set; }

        public Guid UserContact { get; set; }

        public User? User { get; set; }
    }
}
