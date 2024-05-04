using TemplateProject.Application.Catalog.Products;
using TemplateProject.Application.Catalog.UserRequests;

namespace TemplateProject.Host.Controllers.Catalog;

public class UserRequstController : VersionedApiController
{
    [HttpPost("search")]
    [OpenApiOperation("Search UserRequests using available filters.", "")]
    public Task<PaginationResponse<UserRequestDto>> SearchAsync(SearchUserRequestRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPost]
    [OpenApiOperation("Create a new UserRequest.", "")]
    public Task<Guid> CreateAsync(CreateUserRequestRequest request)
    {
        return Mediator.Send(request);
    }

}