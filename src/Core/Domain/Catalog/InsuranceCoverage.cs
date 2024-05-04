namespace TemplateProject.Domain.Catalog;

public class InsuranceCoverage : AuditableEntity, IAggregateRoot
{
    public InsurenceCover InsurenceCover { get; set; }

    public decimal MinimumAmount { get; set; }

    public decimal MaximumAmount { get; set; }

    public string Description { get; set; }

    public ICollection<UserRequest> UserRequest { get; set; }
}

public enum InsurenceCover
{
    Surgery,
    Dentith,
    Hospitalization

}

public class UserRequestInsuranceCoverage
{
    public int UserRequestId { get; set; }
    public int InsuranceCoverageId { get; set; }
    public InsuranceCoverage InsuranceCoverage { get; set; } = null!;
    public UserRequest UserRequest { get; set; } = null!;
}