using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Firebrand.Data;

public abstract class BaseEntityTypeConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
    where TEntity : BaseEntity
{

    protected BaseEntityTypeConfiguration()
    {
    }


    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasQueryFilter(p => p.Status != EntityStatus.Removed);
        ConfigureEntity(builder);
    }

    protected virtual string GetTableName()
    {
        var tableName = typeof(TEntity).Name;

        if (tableName.EndsWith(FbDataConstants.FirebrandEntitySuffix))
            tableName = tableName[..^FbDataConstants.FirebrandEntitySuffix.Length];
        return tableName;
    }
    
    protected abstract void ConfigureEntity(EntityTypeBuilder<TEntity> builder);
}