using System.Threading.Tasks;

namespace Sub
{
    public abstract class RequestHandler<T> where T : class
    {
        public abstract Task Handle(T t);
    }
}