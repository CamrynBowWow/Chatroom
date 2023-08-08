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
            modelBuilder.Entity<Message>()
                .HasOne(message => message.User)
                .WithMany(user => user.Message)
                .HasForeignKey(message => message.UserId);

            modelBuilder.Entity<User>()
                .HasOne(user => user.ContactList)
                .WithOne(contactList => contactList.User)
                .HasForeignKey<ContactList>(contactList => contactList.UserId);

            modelBuilder.Entity<Message>()
                .HasOne(message => message.Conversation)
                .WithMany(conversation => conversation.Messages)
                .HasForeignKey(message => message.ConversationId);

            modelBuilder.Entity<ContactList>().HasKey(cl => cl.ContactId);
            modelBuilder.Entity<Message>().HasKey(m => m.MessageId);
            modelBuilder.Entity<Conversation>().HasKey(con => con.ConversationId);

            modelBuilder.Entity<User>().HasIndex(user => user.Email).IsUnique();
            modelBuilder.Entity<User>().HasIndex(user => user.UniqueName).IsUnique();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = new Guid("EB0FBF5C-A60A-4EA7-A5E1-A9B58D1A062B"),
                    FirstName = "Joe",
                    LastName = "Dirt",
                    UniqueName = "JoeDirtie",
                    Password = "Password",
                    Email = "joe@gmail.com",
                    CreatedAt = DateTime.Now,
                },
                new User
                {
                    UserId = new Guid("7BCCB0BA-0050-4F69-9312-906436DDA76F"),
                    FirstName = "Jane",
                    LastName = "Doe",
                    UniqueName = "JaneNew",
                    Password = "1234567",
                    Email = "jane@gmail.com",
                    CreatedAt = DateTime.Now,
                }                
            );

            // Joe ID EB0FBF5C-A60A-4EA7-A5E1-A9B58D1A062B
            // Jane ID 7BCCB0BA-0050-4F69-9312-906436DDA76F

            modelBuilder.Entity<Conversation>().HasData(
                new Conversation
                {
                    ConversationId = 1,
                    StartedUser = new Guid("EB0FBF5C-A60A-4EA7-A5E1-A9B58D1A062B"),
                    RecipientUser = new Guid("7BCCB0BA-0050-4F69-9312-906436DDA76F")
                }
            );

            modelBuilder.Entity<Message>().HasData(
                new Message
                {
                    MessageId = 1,
                    Context = "Hi, There!",
                    Created = DateTime.Now,
                    UserId = new Guid("EB0FBF5C-A60A-4EA7-A5E1-A9B58D1A062B"),
                    ConversationId = 1
                }
            );

            modelBuilder.Entity<ContactList>().HasData(
                new ContactList
                {
                    ContactId = 1,
                    UserId = new Guid("EB0FBF5C-A60A-4EA7-A5E1-A9B58D1A062B"),
                    UserContact = new Guid("7BCCB0BA-0050-4F69-9312-906436DDA76F")
                },  
                new ContactList
                {
                    ContactId = 2,
                    UserId = new Guid("7BCCB0BA-0050-4F69-9312-906436DDA76F"),
                    UserContact = new Guid("EB0FBF5C-A60A-4EA7-A5E1-A9B58D1A062B")
                }    
            );
        }
    }
}
