using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using Pub;

namespace Sub
{
    class Program
    {
        private static void Register(HubConnection connection)
        {
            var types = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.BaseType!.IsGenericType && t.BaseType?.GetGenericTypeDefinition() == typeof(RequestHandler<>));
            foreach (var type in types)
            {
                var t = type.GetMethods()[0].GetParameters()[0].ParameterType;
                connection.On<object>(t.Name, x =>
                {
                    try
                    {
                        var instance =
                            Activator.CreateInstance(
                                typeof(Wrapper<,>).MakeGenericType(t, type));
                        var handler = instance as HandlerBase;
                        handler?.Handle(x);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                });
            }
        }

        static async Task Main(string[] args)
        {
            var connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:5001/masta")
                .Build();
            Register(connection);
            await connection.StartAsync();
            // connection.On<object>("Message", Console.WriteLine);
            Console.ReadKey();
        }
    }
}