using AcademyC.Week4.Test.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyC.Week4.Test.CoreEF.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order").HasKey(o => o.ID);
            builder.Property("ID").HasColumnType("int");
            builder.Property("OrderDate").HasColumnType("datetime2").IsRequired();
            builder.Property("OrderCode").IsRequired();
            builder.Property("ProductCode").IsRequired();
            builder.Property("Amount").HasColumnType("decimal").IsRequired();
            builder.HasOne(o => o.Client).WithMany(c => c.Orders);
        }
    }
}
