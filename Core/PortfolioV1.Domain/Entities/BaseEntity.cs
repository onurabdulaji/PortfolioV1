using NanoidDotNet;
using PortfolioV1.Domain.Entities.IBase;

namespace PortfolioV1.Domain.Entities;

public abstract class BaseEntity : IBaseEntity
{
    public string Id { get; set; }
    public DateTime? CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
    public bool? Status { get; set; } = true;

    protected BaseEntity()
    {
        Id = Nanoid.Generate();

    }
}
