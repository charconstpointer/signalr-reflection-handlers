using System;

namespace Pub
{
    public class Foo : IMessage
    {
        public string Body { get; set; }
        public DateTime Time { get; set; }
    }
}