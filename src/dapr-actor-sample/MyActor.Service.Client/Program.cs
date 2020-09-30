using Dapr.Actors;
using Dapr.Actors.Client;
using MyActor.Interfaces;
using System;
using System.Threading.Tasks;

namespace MyActor.Service.Client
{
    class Program
    {
        static async Task InvokeActorMethodWithRemotingAsync()
        {
            var actorType = "MyActor";
            var actorID = new ActorId("1");
            var proxy = ActorProxy.Create<IMyActor>(actorID, actorType);
            var response = await proxy.SetDataAsync(new MyData() {
                PropertyA = "value-a",
                PropertyB = "value-b"
            });

            Console.WriteLine(response);

            var savedData = await proxy.GetDataAsync();
            Console.WriteLine(savedData);
        }
        static async Task Main(string[] args)
        {
            await InvokeActorMethodWithRemotingAsync();
        }
    }
}
