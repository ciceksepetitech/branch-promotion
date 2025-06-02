using BranchPromotion.Domain.Entities.Bars;
using BranchPromotion.Domain.Repositories.Bars;
using FluentValidation;
using MediatR;

namespace BranchPromotion.Application.Commands.Bars;

public record CreateBarCommand : IRequest<CreateBarCommandResult>
{
    public string Name { get; init; }
}

public record CreateBarCommandResult
{
    public int Id { get; init; }
}

public class CreateBarCommandValidator : AbstractValidator<CreateBarCommand>
{
    public CreateBarCommandValidator()
    {
        RuleFor(b => b.Name).NotEmpty();
    }
}

public class CreateBarCommandHandler : IRequestHandler<CreateBarCommand, CreateBarCommandResult>
{
    private readonly IBarRepository _barRepository;

    public CreateBarCommandHandler(IBarRepository barRepository)
    {
        _barRepository = barRepository;
    }

    public async Task<CreateBarCommandResult> Handle(CreateBarCommand request, CancellationToken cancellationToken)
    {
        var bar = new Bar
        {
            Name = request.Name
        };

        await _barRepository.Create(bar);

        return new CreateBarCommandResult { Id = bar.Id };
    }
}
