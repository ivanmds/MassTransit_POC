using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Onboar.Api.Model;

namespace Onboar.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IBusControl _bus;
        public CustomersController(IBusControl bus)
            => _bus = bus;

        [HttpPost]
        public IActionResult AddCustomer(Customer customer)
        {
            _bus.Publish(customer);
            return Ok();
        }
    }
}