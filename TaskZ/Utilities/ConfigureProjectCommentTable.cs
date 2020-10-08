using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskZ.Models;

namespace TaskZ.Utilities
{
    public class ConfigureTaskCommentTable : IEntityTypeConfiguration<TaskComment>
    {
        public void Configure(EntityTypeBuilder<TaskComment> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.Comment)
                    .IsRequired();

            builder.HasOne(p => p.User)
                .WithMany(u => u.TaskComments)
                .HasForeignKey(p => p.UserId);

            builder.HasOne(p => p.Parent);                
        }


    }
}
