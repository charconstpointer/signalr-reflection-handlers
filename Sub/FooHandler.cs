using System;
using System.Threading.Tasks;
using Pub;

namespace Sub
{
    public class FooHandler : RequestHandler<Foo>
    {
        public override async Task Handle(Foo t)
        {
            Console.WriteLine($"Hey im Foo! {t.Body} {t.Time}");
        }
    }
}