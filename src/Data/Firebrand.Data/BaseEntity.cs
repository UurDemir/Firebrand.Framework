namespace Firebrand.Data;

public abstract class BaseEntity
{
    public EntityStatus Status { get; set; }

    public BaseEntity()
    {
        Status = EntityStatus.Active;
    }
}