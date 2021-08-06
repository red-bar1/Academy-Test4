using AcademyC.Week4.Test.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyC.Week4.Test.CoreEF.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client").HasKey(c => c.ID);
            builder.Property("ID").HasColumnType("int");
            builder.Property("ClientCode").IsRequired();
            builder.Property("FirstName").IsRequired();
            builder.Property("LastName").IsRequired();
            builder.HasMany(c => c.Orders).WithOne(o => o.Client);
        }
    }
}
