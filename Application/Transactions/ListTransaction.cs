using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Transactions;

public class ListTransaction
{
    public class ListTransactionsQuery : IRequest<List<Transaction>>
    {
    }

    public class ListTransactionsHandler : IRequestHandler<ListTransactionsQuery, List<Transaction>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ListTransactionsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Transaction>> Handle(ListTransactionsQuery request, CancellationToken cancellationToken)
        {
            var transactions = await _unitOfWork.Repository<Transaction>().ListAllAsync();
            return transactions;
        }
    }
}