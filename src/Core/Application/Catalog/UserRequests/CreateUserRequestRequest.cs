using TemplateProject.Application.Catalog.Brands;

namespace TemplateProject.Application.Catalog.UserRequests;

public class CreateUserRequestRequest : IRequest<Guid>
{
    public string Title { get; set; } = default!;
    public decimal? Amount { get; set; }
    public IEnumerable<InsurenceCover> InsurenceCovers { get; set; }
}

public class CreateUserRequestRequestValidator : CustomValidator<CreateUserRequestRequest>
{
    public CreateUserRequestRequestValidator(IReadRepository<UserRequest> repository, IStringLocalizer<CreateBrandRequestValidator> T) =>
        RuleFor(p => p.Title)
            .NotEmpty()
            .MaximumLength(64);
}

public class CreateUserRequestRequestHandler : IRequestHandler<CreateUserRequestRequest, Guid>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<UserRequest> _repository;

    public CreateUserRequestRequestHandler(IRepositoryWithEvents<UserRequest> repository) => _repository = repository;

    public async Task<Guid> Handle(CreateUserRequestRequest request, CancellationToken cancellationToken)
    {
        var entity = new UserRequest
        {
            Title = request.Title,
            Amount = request.Amount
        };
        if (entity.InsuranceCoverage == null)
        {
            entity.InsuranceCoverage = new List<InsuranceCoverage>();
        }

        foreach (var item in request.InsurenceCovers)
        {
            entity.InsuranceCoverage.Add(new InsuranceCoverage { InsurenceCover = item });
        }

        await _repository.AddAsync(entity, cancellationToken);

        return entity.Id;
    }

}