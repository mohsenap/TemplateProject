namespace TemplateProject.Application.Catalog.UserRequests;

public class UserRequestDto : IDto
{
    public string Title { get; private set; }
    public string? Description { get; private set; }
    public ICollection<InsuranceCoverage> InsuranceCoverage { get; set; }
    public string? Amount { get; set; }
}