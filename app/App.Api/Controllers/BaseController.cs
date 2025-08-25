using App.Api.DAL;
using App.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Pr.Cms.BuildingBlock.Abstractions.Persistance;

namespace App.Api.Controllers
{
    [ApiController]
    [Route("")]
    public class BaseController(
        ICarRepository carRepository,
        IUnitOfWork unitOfWork) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var car = Car.Create();
            await carRepository.AddAsync(car);

            await unitOfWork.SaveChangesAsync(default);
            var response = new { name = "Joe" };
            return Ok(response);
        }
    }
}
