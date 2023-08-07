using Chatroom.CoreModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Chatroom.Plugins.EFCore
{
    public class ChatroomContext : DbContext
    {
        public ChatroomContext(DbContextOptions options) : base(options) { }

        public DbSet<User> User { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<ContactList> ContactList { get; set; }
        public DbSet<Conversation> Conversation { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserConversation>()
                .HasKey(uc => new { uc.UserId, uc.ConversationId });

            modelBuilder.Entity<UserConversation>()
               .HasOne(uc => uc.User)
               .WithMany(u => u.UserConversations)
               .HasForeignKey(uc => uc.UserId);

            modelBuilder.Entity<UserConversation>()
                .HasOne(uc => uc.Conversation)
                .WithMany(c => c.UserConversations)
                .HasForeignKey(uc => uc.ConversationId);

            modelBuilder.Entity<Message>()
                .HasOne(message => message.User)
                .WithMany(user => user.Message)
                .HasForeignKey(message => message.UserId);

            modelBuilder.Entity<User>()
                .HasOne(user => user.ContactList)
                .WithOne(contactList => contactList.User)
                .HasForeignKey<ContactList>(contactList => contactList.UserId);

            modelBuilder.Entity<ContactList>().HasKey(cl => cl.ContactId);
            modelBuilder.Entity<Message>().HasKey(m => m.MessageId);
            modelBuilder.Entity<Conversation>().HasKey(con => con.ConversationId);

            modelBuilder.Entity<User>().HasIndex(user => user.Email).IsUnique();
            modelBuilder.Entity<User>().HasIndex(user => user.UniqueName).IsUnique();

            //modelBuilder.Entity<Message>().HasData(
            //    new Message
            //    {
            //        MessageId = 1,
            //        Context = "Hi, there!",
            //        Created = DateTime.Now,
            //        UserId = Guid.NewGuid(),
            //    }
            //);

            //modelBuilder.Entity<Conversation>().HasData(
            //    new Conversation
            //    {
            //        ConversationId = 1,
            //        UserNames = new List<string>
            //        {
            //            "Tom",
            //            "Jane",
            //        },
            //        MessageIds = new List<int>
            //        {
            //            1
            //        }
            //    }
            //);

            //modelBuilder.Entity<User>().HasData(
            //    new User
            //    {
            //        UserId = Guid.NewGuid(),
            //        FirstName = "Tom",
            //        LastName = "Jerry",
            //        UniqueName = "CoolTom",
            //        Password = "Password",
            //        Email = "test@gmail.com",
            //        CreatedAt = DateTime.Now,
            //        LastUpdatedAt = null,
            //    },
            //    new User
            //    {
            //        UserId = Guid.NewGuid(),
            //        FirstName = "Jane",
            //        LastName = "Doe",
            //        UniqueName = "Unkown",
            //        Password = "1234567",
            //        Email = "jane@gmail.com",
            //        CreatedAt = DateTime.Now,
            //        LastUpdatedAt = null,
            //    }
            //);            

            //modelBuilder.Entity<ContactList>().HasData(
            //    new ContactList
            //    {
            //        ContactId = 1,
            //        UserId = Guid.NewGuid(),
            //        UserContacts = new List<string>
            //        {
            //            "Unkown"
            //        }
            //    },
            //    new ContactList
            //    {
            //        ContactId = 2,
            //        UserId = Guid.NewGuid(),
            //        UserContacts = new List<string>
            //        {
            //            "CoolTom"
            //        }
            //    }
            //);

        }
    }
}
