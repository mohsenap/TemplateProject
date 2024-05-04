namespace TemplateProject.Application.Catalog.UserRequests;

public class GetUserRequestRequest : IRequest<UserRequestDto>
{
    public Guid Id { get; set; }

    public GetUserRequestRequest(Guid id) => Id = id;
}

public class UserRequestByIdSpec : Specification<UserRequest, UserRequestDto>, ISingleResultSpecification
{
    public UserRequestByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}

public class GetUserRequestRequestHandler : IRequestHandler<GetUserRequestRequest, UserRequestDto>
{
    private readonly IRepository<UserRequest> _repository;
    private readonly IStringLocalizer _t;

    public GetUserRequestRequestHandler(IRepository<UserRequest> repository, IStringLocalizer<GetUserRequestRequestHandler> localizer) => (_repository, _t) = (repository, localizer);

    public async Task<UserRequestDto> Handle(GetUserRequestRequest request, CancellationToken cancellationToken) =>
        await _repository.FirstOrDefaultAsync(
            (ISpecification<UserRequest, UserRequestDto>)new UserRequestByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(_t["UserRequest {0} Not Found.", request.Id]);
}