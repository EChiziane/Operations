using Application.Interfaces;
using Domain;
using FluentValidation;
using MediatR;

namespace Application.Books;

public class CreateBook
{
    public class CreateBookCommand : IRequest<Book>
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public string Category { get; set; }

        public bool? IsAvailable { get; set; }
        public DateTime ReleaseDate { get; set; }
    }

    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(x => x.Author).NotEmpty().NotNull();
            RuleFor(x => x.Category).NotEmpty().NotNull();
            RuleFor(x => x.Title).NotEmpty().NotNull();
            RuleFor(x => x.ReleaseDate).NotEmpty().NotNull();
        }
    }

    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Book>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateBookCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Book> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Book
            {
                Title = request.Title,
                Author = request.Author,
                Category = request.Category,
                IsAvailable = request.IsAvailable
            };

            _unitOfWork.Repository<Book>().Add(book);
            var result = await _unitOfWork.Complete() > 0;

            if (result)
                return book;
            throw new Exception("Failed Saving Book");
        }
    }
}