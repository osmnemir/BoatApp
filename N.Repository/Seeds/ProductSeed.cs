using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N.Repository.Seeds
{
    internal class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(new Product
            {
                Id = 1,
                CategoryId = 1,
                Name ="Tekne 1",
                Price = 1000,
                Stock = 2,
                CreatedDate = DateTime.Now
            },
            new Product
            {
                Id = 2,
                CategoryId = 1,
                Name = "Tekne 2",
                Price = 900,
                Stock = 5,
                CreatedDate = DateTime.Now
            },
             new Product
             {
                 Id = 3,
                 CategoryId = 2,
                 Name = "Tekne 3",
                 Price = 700,
                 Stock = 4,
                 CreatedDate = DateTime.Now
             },
              new Product
              {
                  Id = 4,
                  CategoryId = 2,
                  Name = "Tekne 4",
                  Price = 600,
                  Stock = 33,
                  CreatedDate = DateTime.Now
              });
        }
    }
}
