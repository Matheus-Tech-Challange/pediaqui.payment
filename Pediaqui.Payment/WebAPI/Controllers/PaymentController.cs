using Application.Features.Create;
using Application.Features.GetByPedido;
using Application.Features.ReceivePayment;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PaymentController : Controller
{
    private readonly IMediator _mediator;

    public PaymentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePaymentRequest request)
    {
        var p = await _mediator.Send(request);
        return Created("/api/payment", p);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetByPedido([FromRoute] int id)
    {
        GetByPedidoRequest request = new() { PedidoId = id };
        var p = await _mediator.Send(request);
        return Ok(p);
    }

    [HttpPost]
    [Route("receive")]
    public async Task<IActionResult> Receive(ReceivePaymentRequest request)
    {
        var p = await _mediator.Send(request);
        return Ok(p);
    }
}
