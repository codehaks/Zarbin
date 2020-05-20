using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portal.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Persistence.Configs
{
    class PanelConfig : IEntityTypeConfiguration<WebPage>
    {
        public void Configure(EntityTypeBuilder<WebPage> builder)
        {
            builder.Property(c => c.Name).HasMaxLength(25);
            builder.Property(c => c.Title).HasMaxLength(25);

            builder.HasKey(c => c.Name);
        }
    }
}
