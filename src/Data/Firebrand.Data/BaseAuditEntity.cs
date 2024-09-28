
namespace Firebrand.Data;

/// <summary>  
/// Represents a base entity with audit information.  
/// </summary>  
public abstract class BaseAuditEntity : BaseEntity
{
    /// <summary>  
    /// Initializes a new instance of the <see cref="BaseAuditEntity"/> class.  
    /// Sets the <see cref="CreatedDate"/> to the current UTC date and time.  
    /// </summary>  
    protected BaseAuditEntity()
    {
        CreatedDate = DateTime.UtcNow;
    }

    /// <summary>  
    /// Gets or sets the date and time when the entity was created.  
    /// </summary>  
    public DateTime CreatedDate { get; set; }

    /// <summary>  
    /// Gets or sets the user who created the entity.  
    /// </summary>  
    public string? CreatedBy { get; set; }

    /// <summary>  
    /// Gets or sets the date and time when the entity was last modified.  
    /// </summary>  
    public DateTime? ModifiedDate { get; set; }

    /// <summary>  
    /// Gets or sets the user who last modified the entity.  
    /// </summary>  
    public string? ModifiedBy { get; set; }
}
