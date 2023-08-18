using Chatroom.CoreModel;

namespace Chatroom.UseCases.Interfaces
{
    public interface IFetchConversations
    {
        Task<Dictionary<int, User>> ExecuteAsync(Guid userId);
    }
}
