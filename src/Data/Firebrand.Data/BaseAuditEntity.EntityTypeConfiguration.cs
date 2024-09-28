using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Firebrand.Data;

/// <summary>
/// Provides a base implementation for configuring database entities with audit and tracking.
/// </summary>
/// <typeparam name="TEntity">The type of entity being configured.</typeparam>
public abstract class BaseAuditEntityTypeConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
    where TEntity : BaseAuditEntity
{
    /// <summary>
    /// Configures the entity using the specified entity type builder.
    /// </summary>
    /// <param name="builder">The entity type builder to use.</param>
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.Property(p => p.CreatedBy).HasMaxLength(50);
        builder.Property(p => p.ModifiedBy).HasMaxLength(50);
        builder.HasQueryFilter(p => p.Status != EntityStatus.Removed);

        ConfigureEntity(builder);
    }

    /// <summary>
    /// Gets the name of the table for the entity.
    /// </summary>
    /// <returns>The name of the table.</returns>
    protected virtual string GetTableName()
    {
        var tableName = typeof(TEntity).Name;

        if (tableName.EndsWith(FbDataConstants.FirebrandEntitySuffix))
            tableName = tableName[..^FbDataConstants.FirebrandEntitySuffix.Length];
        return tableName;
    }

    /// <summary>
    /// Configures the entity using the specified entity type builder.
    /// </summary>
    /// <param name="builder">The entity type builder to use.</param>
    protected abstract void ConfigureEntity(EntityTypeBuilder<TEntity> builder);
}
