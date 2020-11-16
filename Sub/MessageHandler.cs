using System;
using System.Threading.Tasks;
using Pub;

namespace Sub
{
    public class MessageHandler : RequestHandler<Message>
    {
        public override async Task Handle(Message t)
        {
            Console.WriteLine(t.Body);
        }
    }
}