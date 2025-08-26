using App.Api.Models;

namespace App.Api.DAL
{
    public class CarRepository(
        Db context) : ICarRepository
    {
        public async Task AddAsync(User user)
        {
            context.Add(user);
            await context.SaveChangesAsync();
        }
    }
}
