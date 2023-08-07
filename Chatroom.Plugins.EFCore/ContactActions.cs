using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatroom.Plugins.EFCore
{
    public class ContactActions
    {
        private readonly ChatroomContext db;

        public ContactActions(ChatroomContext db)
        {
            this.db = db;
        }

        public async Task AddContact()
        {
            
        }

        public async Task DeleteContact()
        {

        }
    }
}
