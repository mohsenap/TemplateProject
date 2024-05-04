namespace TemplateProject.Application.Catalog.UserRequests;

public class UserRequestDto : IDto
{
    public string Title { get; set; }
    public ICollection<InsuranceCoverageDto> InsuranceCoverage { get; set; }
    public string? Amount { get; set; }
}