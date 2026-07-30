using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Extensions;

public static class PropertyBuilderExtensions
{
    public static PropertyBuilder<decimal?> HasPrecision(this PropertyBuilder<decimal?> builder, int precision, int scale) => builder.HasColumnType($"decimal({precision},{scale})");

    public static PropertyBuilder<decimal> HasPrecision(this PropertyBuilder<decimal> builder, int precision, int scale) => builder.HasColumnType($"decimal({precision},{scale})");
}
