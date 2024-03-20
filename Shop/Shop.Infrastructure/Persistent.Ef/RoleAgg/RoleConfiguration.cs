using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.RoleAgg;

namespace Shop.Infrastructure.Persistent.Ef.RoleAgg
{
    internal class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles", "role");
            builder.HasIndex(b => b.Title).IsUnique();
            builder.OwnsMany(b => b.Permissions, option =>
            {
                option.ToTable("Permissions", "role");
                option.HasKey(b => b.id);
            });
        }
    }
}
