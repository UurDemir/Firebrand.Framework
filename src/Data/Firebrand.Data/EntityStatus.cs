
namespace Firebrand.Data;

/// <summary>  
/// Represents the status of an entity.  
/// </summary>  
public enum EntityStatus
{
    /// <summary>  
    /// The status of the entity is undefined.  
    /// </summary>  
    Undefined,

    /// <summary>  
    /// The entity is active.  
    /// </summary>  
    Active,

    /// <summary>  
    /// The entity is passive.  
    /// </summary>  
    Passive,

    /// <summary>  
    /// The entity is in draft state.  
    /// </summary>  
    Draft,

    /// <summary>  
    /// The entity has been removed.  
    /// </summary>  
    Removed
}
