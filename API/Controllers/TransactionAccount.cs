using Application.Transactions;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class TransactionController : BaseApiController
{
    private readonly IMediator _mediator;

    public TransactionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult<Transaction>> AddTransaction(AddTransaction.AddTransactionCommand command)
    {
        return Ok(await _mediator.Send(command));
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<List<Transaction>>> ListTransaction()
    {
        return Ok(await _mediator.Send(new ListTransaction.ListTransactionsQuery()));
    }

    [HttpGet("{TransactionId}")]
    [AllowAnonymous]
    public async Task<ActionResult<Transaction>> GetTransactionById(int transactionId)
    {
        return Ok(
            await _mediator.Send(new GetTransactionById.GetTransactionByIdQuery { TransactionId = transactionId }));
    }
}