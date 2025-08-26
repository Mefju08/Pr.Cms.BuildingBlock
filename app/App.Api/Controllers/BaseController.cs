using App.Api.Commands;
using Microsoft.AspNetCore.Mvc;
using Wolverine;

namespace App.Api.Controllers
{
    [ApiController]
    [Route("")]
    public class BaseController(
        IMessageBus messageBus) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            string name = "Mateusz";
            var command = new RegisterCommand(name);
            var result = await messageBus.InvokeAsync<Guid>(command);

            var response = new { Id = result };
            return Ok(response);
        }
    }
}
