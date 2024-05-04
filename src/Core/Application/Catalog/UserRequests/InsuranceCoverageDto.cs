namespace TemplateProject.Application.Catalog.UserRequests;

public class InsuranceCoverageDto : IDto
{
    public InsurenceCover InsurenceCover { get; set; }

    public decimal MinimumAmount { get; set; }

    public decimal MaximumAmount { get; set; }

    public string Description { get; set; }
}