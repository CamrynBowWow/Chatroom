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
    public class SendMessage : ISendMessage
    {
        private readonly IMessageActions messageActions;

        public SendMessage(IMessageActions messageActions)
        {
            this.messageActions = messageActions;
        }

        public async Task ExecuteAsync(Message message)
        {
            await messageActions.SendMessage(message);
        }
    }
}
