using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using API.Infrastructure.Queries.Order;
using API.Application.Dtos;
using API.Infrastructure.Commands.Order;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrderDto orderDto)
        {
            try
            {
                var command = new CreateOrderCommand(orderDto);
                await _mediator.Send(command);
                return NoContent();
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            try
            {
                var objectResult = await _mediator.Send(new GetAllOrdersQuery());
                return Ok(objectResult);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetOrderById([FromQuery] int id)
        {
            try
            {
                var objectResult = await _mediator.Send(new GetOrderByIdQuery(id));
                return Ok(objectResult);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder([FromBody] OrderDto orderDto)
        {
            try
            {
                var objectResult = await _mediator.Send(new UpdateOrderCommand(orderDto));
                return Ok(objectResult);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteOrder([FromQuery] int id)
        {
            try
            {
                var objectResult = await _mediator.Send(new DeleteOrderCommand(id));
                if (!objectResult) throw new Exception($"Order with Id {id} cannot be removed");
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
