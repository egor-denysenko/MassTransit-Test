using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedEvents;

namespace Publisher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestConsoleEvent : ControllerBase
    {
        private IPublishEndpoint _publishEndpoint;

        public TestConsoleEvent(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }
        [HttpPost]
        public async Task<ActionResult> SendCommand()
        {
            await _publishEndpoint.Publish(
                new ConsoleMessage()
                {
                    Numerone = 25,
                    Stringa = "Pluto"
                }
                ).ConfigureAwait(false); //

            return StatusCode(204);
        }
    }
}
