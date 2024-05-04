namespace TemplateProject.Domain.Catalog;

public class UserRequest : AuditableEntity, IAggregateRoot
{
    public string Title { get; set; }
    public ICollection<InsuranceCoverage>? InsuranceCoverage { get; set; }
    public decimal? Amount { get; set; }
}

