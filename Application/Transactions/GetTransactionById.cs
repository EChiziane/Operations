using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Transactions;

public class GetTransactionById
{
    public class GetTransactionByIdQuery : IRequest<Transaction>
    {
        public int TransactionId { get; set; }
    }

    public class GetTransactionQueryHandler : IRequestHandler<GetTransactionByIdQuery, Transaction>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTransactionQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Transaction> Handle(GetTransactionByIdQuery request, CancellationToken cancellationToken)
        {
            var transaction = await _unitOfWork.Repository<Transaction>().GetByIdAsync(request.TransactionId);
            return transaction;
        }
    }
}