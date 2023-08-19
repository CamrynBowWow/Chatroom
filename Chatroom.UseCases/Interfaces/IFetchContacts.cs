using Chatroom.CoreModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatroom.UseCases.Interfaces
{
    public interface IFetchContacts
    {
        Task<List<User>> ExecuteAsync(Guid userId);
    }
}
