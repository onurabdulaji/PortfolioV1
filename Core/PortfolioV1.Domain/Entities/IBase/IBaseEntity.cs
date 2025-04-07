namespace PortfolioV1.Domain.Entities.IBase;

public interface IBaseEntity
{
    Guid Id { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
    public bool? Status { get; set; }
}
