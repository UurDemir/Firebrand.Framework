using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Firebrand.Data.PostgreSQL;

public abstract class EFAuditEntityTypeConfiguration<TEntity> : BaseAuditEntityTypeConfiguration<TEntity>
    where TEntity : BaseAuditEntity
{
    /// <summary>
    /// The default schema name for the entity.
    /// </summary>
    protected virtual string Schema => PostgreSqlConstants.Schema;

    public sealed override void Configure(EntityTypeBuilder<TEntity> builder)
    {
        var tableName = GetTableName();

        builder.ToTable(tableName, Schema);
        base.Configure(builder);
    }
}
