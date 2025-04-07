using PortfolioV1.Domain.Entities.IBase;

namespace PortfolioV1.Domain.Entities;

public abstract class BaseEntity : IBaseEntity
{
    public Guid Id { get; set; }
    public DateTime? CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedDate { get; set; } = DateTime.UtcNow;
    public DateTime? DeletedDate { get; set; } = DateTime.UtcNow;
    public bool? Status { get; set; } = true;
}
