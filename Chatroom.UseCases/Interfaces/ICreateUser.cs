using Chatroom.CoreModel;

namespace Chatroom.UseCases.Interfaces
{
    public interface ICreateUser
    {
        Task<(string, bool)> ExecuteAsync(User user);
    }
}
