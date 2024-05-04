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
    private readonly IReadRepository<InsuranceCoverage> _repositoryInsuranceCoverage;


    public CreateUserRequestRequestHandler(IRepositoryWithEvents<UserRequest> repository, IReadRepository<InsuranceCoverage> repositoryInsuranceCoverage)
    {
        _repository = repository;
        _repositoryInsuranceCoverage = repositoryInsuranceCoverage;
    }
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

        var list = await _repositoryInsuranceCoverage.ListAsync();
        decimal sumMinValue = 0;
        decimal sumMaxValue = 0;
        foreach (var item in request.InsurenceCovers)
        {
            var coverItem = list.FirstOrDefault(t => t.InsurenceCover == item);
            sumMinValue += coverItem.MinimumAmount;
            sumMaxValue += coverItem.MaximumAmount;
            if (request.Amount < sumMinValue || request.Amount > sumMaxValue)
            {
                throw new InternalServerException("The amount is not in correct range");
            }
            entity.InsuranceCoverage.Add(coverItem);
        }
        await _repository.AddAsync(entity, cancellationToken);
        return entity.Id;

    }

}