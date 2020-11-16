using System.Threading.Tasks;

namespace Sub
{
    public abstract class HandlerBase
    {
        public abstract Task Handle(object request);
    }
}