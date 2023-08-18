using Chatroom.CoreModel;
using Chatroom.UseCases.Interfaces;
using Chatroom.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatroom.UseCases.MessageActions
{
    public class FetchMessages : IFetchMessages
    {
        private readonly IMessageActions messageActions;

        public FetchMessages(IMessageActions messageActions)
        {
            this.messageActions = messageActions;
        }

        public async Task<(List<Message>, int)> ExecuteAsync(Guid HostUserId, Guid OtherUserId)
        {
            return await messageActions.FetchMessages(HostUserId, OtherUserId);
        }
    }
}
