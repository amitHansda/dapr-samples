using Dapr.Actors.Runtime;
using Dapr.Actors;
using MyActor.Interfaces;
using System.Threading.Tasks;
using System;

namespace MyActor.Service
{
    internal class MyActor : Actor , IMyActor , IRemindable
    {
        public MyActor(ActorService actorService, 
            ActorId actorId) : base(actorService, actorId)
        {

        }
        /// <summary>
        /// Called whenever actor is activated
        /// </summary>
        /// <returns></returns>
        protected override Task OnActivateAsync()
        {
            Console.WriteLine("Activating actor id:{0}",Id);
            return base.OnActivateAsync();
        }

        protected override Task OnDeactivateAsync()
        {
            Console.WriteLine("Deactivating actor id:{0}",Id);
            return base.OnDeactivateAsync();
        }

        public async Task<MyData> GetDataAsync()
        {
            return await this.StateManager.GetStateAsync<MyData>("my_data");
        }

        public async Task<string> SetDataAsync(MyData data)
        {
            await this.StateManager.SetStateAsync<MyData>("my_data", data);
            return "Success";
        }
        /// <summary>
        /// Registers a reminder with the actor
        /// </summary>
        /// <returns></returns>
        public async Task RegisterReminder()
        {
            await this.RegisterReminderAsync("MyReminer"
                ,null
                ,TimeSpan.FromSeconds(5)
                ,TimeSpan.FromSeconds(5));
        }

        public Task UnregisterReminder()
        {
            Console.WriteLine("Unregistering MyReminder...");
            return this.UnregisterReminderAsync("MyReminder");
        }

        /// <summary>
        /// call back invoked when an actor reminder is triggered
        /// </summary>
        /// <param name="reminderName"></param>
        /// <param name="state"></param>
        /// <param name="dueTime"></param>
        /// <param name="period"></param>
        /// <returns></returns>
        public Task ReceiveReminderAsync(string reminderName, byte[] state, TimeSpan dueTime, TimeSpan period)
        {
            Console.WriteLine("ReceiveReminder is called");
            return Task.CompletedTask;
        }        

        public Task RegisterTimer()
        {
            return this.RegisterTimerAsync("MyTimer",
                this.OnTimerCallBack,
                null,
                TimeSpan.FromSeconds(5),// Time to delay before the async callback is first invoked
                TimeSpan.FromSeconds(5)); // Time interval between invocations of the async callback
            
        }

        private Task OnTimerCallBack(object data)
        {
            Console.WriteLine("OnTimerCallback is called!!");
            return Task.CompletedTask;
        }

        public Task UnregisterTimer()
        {
            Console.WriteLine("Unregistering MyTimer");
            return this.UnregisterTimerAsync("MyTimer");
        }
    }
}
