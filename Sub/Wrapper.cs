using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Sub
{
    public class Wrapper<T, TH> : ResWrapper<T> where T : class where TH : RequestHandler<T>
    {
        public override async Task Handle(T t)
        {
            try
            {
                var type = Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .FirstOrDefault(tt =>
                    {
                        var foo = typeof(RequestHandler<T>).IsAssignableFrom(tt);
                        return foo;
                    });
                if (type is null)
                {
                    throw new ApplicationException($"Could not find handler for provided type {nameof(T)}");
                }

                var instance = (TH) Activator.CreateInstance(type);
                await instance!.Handle(t);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public override async Task Handle(object request)
        {
            try
            {
                var ayy = JsonConvert.DeserializeObject<T>(request.ToString()!);
                await Handle(ayy);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}