using App.Api.Models;
using Microsoft.EntityFrameworkCore;
using Pr.Cms.BuildingBlock.Infrastructure.Persistance.Repositories;

namespace App.Api.DAL
{
    public class CarRepository : Repository<Car, CarId>, ICarRepository
    {
        public CarRepository(DbContext context) : base(context)
        {
        }
    }
}
