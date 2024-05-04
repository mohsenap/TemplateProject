using TemplateProject.Application.Catalog.UserRequests;
using TemplateProject.Application.Common.Models;

namespace TemplateProject.Application.Catalog.UserRequests;

public class SearchUserRequestRequest : PaginationFilter, IRequest<PaginationResponse<UserRequestDto>>
{
}

public class UserRequestsBySearchRequestSpec : EntitiesByPaginationFilterSpec<UserRequest, UserRequestDto>
{
    public UserRequestsBySearchRequestSpec(SearchUserRequestRequest request)
        : base(request) =>
        Query.OrderBy(c => c.Title, !request.HasOrderBy());
}

public class SearchUserRequestsRequestHandler : IRequestHandler<SearchUserRequestRequest, PaginationResponse<UserRequestDto>>
{
    private readonly IReadRepository<UserRequest> _repository;
    private readonly IReadRepository<InsuranceCoverage> _repositoryInsuranceCoverage;

    public SearchUserRequestsRequestHandler(IReadRepository<UserRequest> repository, IReadRepository<InsuranceCoverage> repositoryInsuranceCoverage)
    {
        _repository = repository;
        _repositoryInsuranceCoverage = repositoryInsuranceCoverage;
    }

    public async Task<PaginationResponse<UserRequestDto>> Handle(SearchUserRequestRequest request, CancellationToken cancellationToken)
    {

        var spec = new UserRequestsBySearchRequestSpec(request);
        return await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken);
    }
}