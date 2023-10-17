using Application.Interfaces;
using Domain;
using FluentValidation;
using MediatR;

namespace Application.Transactions;

public class AddTransaction
{
    public class AddTransactionCommand : IRequest<Transaction>
    {
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public TransactionType Type { get; set; }
    }

    public class AddTransactionValidator : AbstractValidator<AddTransactionCommand>
    {
        public AddTransactionValidator()
        {
            RuleFor(x => x.Description).NotEmpty().NotNull();
            RuleFor(x => x.Amount).NotEmpty().NotNull();
            RuleFor(x => x.Type).NotEmpty().NotNull();
        }
    }

    public class AddTransactionCommandRequest : IRequestHandler<AddTransactionCommand, Transaction>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddTransactionCommandRequest(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Transaction> Handle(AddTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = new Transaction
            {
                Amount = request.Amount,
                Type = request.Type,
                Description = request.Description
            };
            _unitOfWork.Repository<Transaction>().Add(transaction);
            var result = await _unitOfWork.Complete() > 0;
            if (result)
                return transaction;

            throw new Exception("Failed Saving Transaction");
        }
    }
}