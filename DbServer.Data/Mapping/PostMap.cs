using DbServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbServer.Data.Mapping
{
    public class PostMap : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.IDOriginAccount)
                .IsRequired();
            builder.Property(c => c.IDDestinationAccount)
               .IsRequired();
            builder.Property(c => c.Value)
               .IsRequired();
        }
    }
}
