using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Firebrand.Data;


/// <summary>
/// Contains methods that handle entity events for a <see cref="DbContext"/>.
/// </summary>
public static class ContextEvents
{
    /// <summary>
    /// Handles the SavingChanges event of the <paramref name="sender"/> <see cref="DbContext"/>.
    /// This method updates the <see cref="BaseAuditEntity.CreatedDate"/> and <see cref="BaseAuditEntity.CreatedBy"/> properties
    /// of all newly added entities that inherit from <see cref="BaseAuditEntity"/>,
    /// and updates the <see cref="BaseAuditEntity.ModifiedDate"/> and <see cref="BaseAuditEntity.ModifiedBy"/> properties
    /// of all modified entities that inherit from <see cref="BaseAuditEntity"/>.
    /// </summary>
    /// <param name="sender">The sender of the event.</param>
    /// <param name="e">The event arguments.</param>
    /// <exception cref="ArgumentException">Thrown when <paramref name="sender"/> is not a <see cref="DbContext"/>.</exception>
    public static void BaseAuditEntity_SavingChanges(object? sender, SavingChangesEventArgs e)
    {
        if (sender is not DbContext context)
            throw new ArgumentException("sender must be DbContext", nameof(sender));

        DateTime utcNow = DateTime.UtcNow;

        foreach (var entry in context.ChangeTracker.Entries())
        {
            if (entry.Entity is BaseAuditEntity auditEntity)
            {
                if (entry.State == EntityState.Added)
                {
                    auditEntity.CreatedDate = utcNow;

                    if (auditEntity.CreatedBy is { Length: 0 })
                        auditEntity.CreatedBy = "System";
                }
                else if (entry.State == EntityState.Modified)
                {

                    auditEntity.ModifiedDate = utcNow;

                    if (entry.OriginalValues.GetValue<string>(nameof(BaseAuditEntity.ModifiedBy)) == auditEntity.ModifiedBy)
                        auditEntity.ModifiedBy = "System";
                }
            }
        }
    }

    public static void BaseEntity_Tracked(object? sender, EntityTrackedEventArgs e)
    {
        if (e.Entry.State == EntityState.Deleted && e.Entry.Entity is BaseEntity baseEntity)
        {
            baseEntity.Status = EntityStatus.Removed;
            e.Entry.State = EntityState.Modified;
        }
    }

}
