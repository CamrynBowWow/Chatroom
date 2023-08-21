using Chatroom.CoreModel;
using Chatroom.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatroom.Plugins.EFCore
{
    public class ContactActions : IContactActions
    {
        private readonly ChatroomContext db;

        public ContactActions(ChatroomContext db)
        {
            this.db = db;
        }

        public async Task<(User?, string)> AddContact(string uniqueName, Guid userId)
        {
            User fetchedUser = await db.User.FirstOrDefaultAsync(user => user.UniqueName == uniqueName);

            if (fetchedUser == null || fetchedUser.UserId == userId)
            {
                return (null, "User was not found. Check spelling.");
            }

            if ((await db.ContactList.FirstOrDefaultAsync(u => u.UserId == userId && u.UserContact == fetchedUser.UserId)) != null)
            {
                return (null, "User is already part of your Contact List.");
            }          

            ContactList contactList = new();

            contactList.UserId = userId;
            contactList.UserContact = fetchedUser.UserId;

            db.ContactList.Add(contactList);
            db.SaveChanges();

            return (fetchedUser, "Added User to your contact list.");
        }

        public async Task<List<User>> FetchContacts(Guid userId)
        {
            List<ContactList> userContactList = await db.ContactList.Where(u => u.UserId == userId).ToListAsync();

            List<User>? userList = new();

            foreach (ContactList userContact in userContactList)
            {
                userList.Add(await db.User.FirstOrDefaultAsync(u => u.UserId == userContact.UserContact));
            }

            return userList;
        }
    }
}
