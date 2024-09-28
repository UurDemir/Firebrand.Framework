using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Firebrand.Data.EF;

public abstract class EFAuditEntityTypeConfiguration<TEntity> : BaseAuditEntityTypeConfiguration<TEntity>
    where TEntity : BaseAuditEntity
{
    /// <summary>
    /// The default schema name for the entity.
    /// </summary>
    protected virtual string Schema => "dbo";

    /// <summary>
    /// Whether the entity is temporal or not.
    /// </summary>
    protected virtual bool IsTemporal => false;

    public sealed override void Configure(EntityTypeBuilder<TEntity> builder)
    {
        var tableName = GetTableName();

        builder.ToTable(tableName, Schema, t => t.IsTemporal(IsTemporal));
        base.Configure(builder);
    }
}