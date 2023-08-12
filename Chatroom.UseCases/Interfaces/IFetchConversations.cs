using Chatroom.CoreModel;

namespace Chatroom.UseCases.Interfaces
{
    public interface IFetchConversations
    {
        Task<List<User>> ExecuteAsync(Guid userId);
    }
}
