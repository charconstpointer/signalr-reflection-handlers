using System.Threading.Tasks;

namespace Sub
{
    public abstract class ResWrapper<T> : HandlerBase
    {
        public abstract Task Handle(T t);
    }
}