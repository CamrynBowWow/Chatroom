using Chatroom.CoreModel;

namespace Chatroom.UseCases.Interfaces
{
    public interface IFetchMessages
    {
        Task<(List<Message>, int)> ExecuteAsync(Guid HostUserId, Guid OtherUserId);
    }
}
