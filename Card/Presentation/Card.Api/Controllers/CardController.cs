using Card.Application.Features.Commands.Definitions.Card.Create;
using Card.Application.Features.Commands.Definitions.Card.Delete;
using Card.Application.Features.Commands.Definitions.Card.Update;
using Card.Application.Features.Queries.Definitions.Card.GetAll;
using Card.Application.Features.Queries.Definitions.Card.GetById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Utilities.Core.UtilityApplication.Abstractions.Services.RabbitMQ;

namespace Card.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    //[Authorize(AuthenticationSchemes = "Admin")]
    public class CardController : ControllerBase
    { 
        readonly IMediator _mediator;
        readonly IRabbitMQProducer _rabbitmqProducer;
        public CardController(IMediator mediator, IRabbitMQProducer rabbitmqProducer)
        {
            _mediator = mediator;
            _rabbitmqProducer = rabbitmqProducer;
            _rabbitmqProducer.SendMessage("test message");
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllCardRequest request)
        {
            GetAllCardResponse response = await _mediator.Send(request);
            _rabbitmqProducer.SendMessage(response);

            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdCardRequest request)
        {
            GetByIdCardResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateCardRequest request)
        {
            CreateCardResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateCardRequest request)
        {
            UpdateCardResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteCardRequest request)
        {
            DeleteCardResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
