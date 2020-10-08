using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskZ.Models;

namespace TaskZ.Utilities
{
    public class ConfigureTaskItemTable : IEntityTypeConfiguration<TaskItem>
    {
        public void Configure(EntityTypeBuilder<TaskItem> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.Title)
                    .IsRequired()
                    .HasMaxLength(180);

            builder.Property(p => p.ShortDescription)
                    .HasMaxLength(350);

            builder.HasOne(p => p.AssignedUser)
                .WithMany(u => u.TaskItems);                
        }


    }
}
