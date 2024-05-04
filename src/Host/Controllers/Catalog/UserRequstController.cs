using TemplateProject.Application.Catalog.UserRequests;

namespace TemplateProject.Host.Controllers.Catalog;

public class UserRequstController : VersionedApiController
{
    //[HttpPost("search")]
    //[OpenApiOperation("Search UserRequests using available filters.", "")]
    //public Task<PaginationResponse<UserRequestDto>> SearchAsync(SearchUserRequestsRequest request)
    //{
    //    return Mediator.Send(request);
    //}

    [HttpGet("{id:guid}")]
    [OpenApiOperation("Get UserRequest details.", "")]
    public Task<UserRequestDto> GetAsync(Guid id)
    {
        return Mediator.Send(new GetUserRequestRequest(id));
    }

    [HttpPost]
    [OpenApiOperation("Create a new UserRequest.", "")]
    public Task<Guid> CreateAsync(CreateUserRequestRequest request)
    {
        return Mediator.Send(request);
    }

}