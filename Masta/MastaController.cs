using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Sub;

namespace Masta
{
    [ApiController]
    [Route("api/[controller]")]
    public class MastaController : ControllerBase
    {
        private readonly IHubContext<MastaHub> _hubContext;

        public MastaController(IHubContext<MastaHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await _hubContext.Clients.All.SendAsync("Message", new Message("Elo"));
            await _hubContext.Clients.All.SendAsync("Foo", new Foo {Body = ":)", Time = DateTime.UtcNow});
            return Ok();
        }
    }
}