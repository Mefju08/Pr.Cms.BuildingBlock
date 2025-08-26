namespace App.Api.Events
{
    public sealed class UserRegisterEventHandler
    {
        public async Task Handle(UserRegisteredEvent notification)
        {
            Console.WriteLine("Succes");
            await Task.CompletedTask;
        }
    }
}
