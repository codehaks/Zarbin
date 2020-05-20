using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Persistence.Configs
{
    public class DocConfig : IEntityTypeConfiguration<Doc>
    {
        public void Configure(EntityTypeBuilder<Doc> builder)
        {
            builder.Property(d => d.Name).HasMaxLength(20);
            builder.Property(d => d.Description).HasMaxLength(250);
            builder.Property(d => d.Extention).HasMaxLength(10);
            builder.Property(d => d.FileName).HasMaxLength(25);
            builder.Property(d => d.ContentType).HasMaxLength(20);
        }
    }
}
