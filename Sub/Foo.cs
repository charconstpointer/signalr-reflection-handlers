using System;

namespace Sub
{
    public class Foo : IMessage
    {
        public string Body { get; set; }
        public DateTime Time { get; set; }
    }
}