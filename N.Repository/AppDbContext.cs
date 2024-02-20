﻿using Microsoft.EntityFrameworkCore;
using N.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace N.Repository;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductFeature> ProductFeatures { get; set; }




    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.Entity<ProductFeature>().HasData(new ProductFeature()
        {
            Id = 1,
            Color = "Beyaz",
            Height = 200,
            Width = 100,
            ProductId = 1,
        },
        new ProductFeature()
        {
            Id = 2,
            Color = "Siyah",
            Height = 300,
            Width = 200,
            ProductId = 2,
        });

        base.OnModelCreating(modelBuilder);
    }

}
