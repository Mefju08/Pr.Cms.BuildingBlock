using App.Api.Models;

namespace App.Api.DAL
{
    public interface ICarRepository
    {
        Task AddAsync(User user);
    }
}