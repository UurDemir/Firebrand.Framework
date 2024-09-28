using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Firebrand.Data.PostgreSQL;

public abstract class EFEntityTypeConfiguration<TEntity> : BaseEntityTypeConfiguration<TEntity>
where TEntity : BaseEntity
{
    /// <summary>
    /// The default schema name for the entity.
    /// </summary>
    protected virtual string Schema => "public";

    public sealed override void Configure(EntityTypeBuilder<TEntity> builder)
    {
        var tableName = GetTableName();

        builder.ToTable(tableName, Schema);
        base.Configure(builder);
    }
}