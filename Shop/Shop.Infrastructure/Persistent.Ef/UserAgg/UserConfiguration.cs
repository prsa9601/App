using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.UserAgg;

namespace Shop.Infrastructure.Persistent.Ef.UserAgg
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users", "user");
            builder.HasIndex(b => b.PhoneNumber).IsUnique();
            builder.HasIndex(b => b.UserName).IsUnique();

            builder.Property(b => b.Password)
                .IsRequired()
                .HasMaxLength(50); 
            builder.Property(b => b.PhoneNumber)
                .IsRequired()
                .HasMaxLength(11);
            builder.Property(b => b.UserName)
                .IsRequired()
                .HasMaxLength(100);

            builder.OwnsMany(b => b.Tokens, option =>
            {
                option.ToTable("Tokens", "user");
                option.HasKey(b => b.id);

                option.Property(b => b.HashJwtToken)
                    .IsRequired()
                    .HasMaxLength(250);

                option.Property(b => b.HashRefreshToken)
                    .IsRequired()
                    .HasMaxLength(250);

                option.Property(b => b.Device)
                    .IsRequired()
                    .HasMaxLength(100);
            });
            builder.OwnsMany(b => b.Roles, option =>
            {
                option.ToTable("Roles", "user");
                option.HasKey(b => b.id);

                option.Property(b => b.RoleId)
                    .IsRequired()
                    .HasMaxLength(250);

                option.Property(b => b.UserId)
                    .IsRequired()
                    .HasMaxLength(250);

            });

        }
    }
}
