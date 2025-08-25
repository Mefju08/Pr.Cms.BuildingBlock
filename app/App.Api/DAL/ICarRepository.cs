using App.Api.Models;
using Pr.Cms.BuildingBlock.Abstractions.Persistance;

namespace App.Api.DAL
{
    public interface ICarRepository : IGenericRepository<Car, CarId>
    {
    }
}