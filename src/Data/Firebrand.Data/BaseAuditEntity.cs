namespace Firebrand.Data;

public class BaseAuditEntity : BaseEntity
{
    public BaseAuditEntity()
    {
        CreatedDate = DateTime.UtcNow;
    }
    
    public DateTime CreatedDate { get; set; }
    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }
    public string? ModifiedBy { get; set; }
}