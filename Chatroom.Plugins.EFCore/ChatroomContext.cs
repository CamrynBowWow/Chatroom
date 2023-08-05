using Chatroom.CoreModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatroom.Plugins.EFCore
{
    public class ChatroomContext : DbContext
    {
        public ChatroomContext(DbContextOptions options) : base(options) { }

        public DbSet<User> User { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Conversation> Conversation { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
