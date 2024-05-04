namespace TemplateProject.Domain.Catalog;

public class InsuranceCoverage : AuditableEntity, IAggregateRoot
{
    public InsurenceCover InsurenceCover { get; set; }

    public decimal MinimumAmount { get; set; }

    public decimal MaximumAmount { get; set; }

    public string? Description { get; set; }

    public ICollection<UserRequest>? UserRequest { get; set; }
}

public enum InsurenceCover
{
    Surgery = 1,
    Dentith = 2,
    Hospitalization = 3

}

public class UserRequestInsuranceCoverage
{
    public Guid UserRequestId { get; set; }
    public int InsuranceCoverageId { get; set; }
    public InsuranceCoverage? InsuranceCoverage { get; set; }
    public UserRequest? UserRequest { get; set; }
}