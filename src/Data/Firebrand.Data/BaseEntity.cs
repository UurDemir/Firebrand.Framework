namespace Firebrand.Data;

public abstract class BaseEntity
{
    public EntityStatus Status { get; set; }

    protected BaseEntity()
    {
        Status = EntityStatus.Active;
    }
}