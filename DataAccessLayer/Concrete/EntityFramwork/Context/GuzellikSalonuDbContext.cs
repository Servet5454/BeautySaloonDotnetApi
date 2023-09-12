using DataEntitiesLayer.Entities;
using DataEntitiesLayer.Entities.Costumers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramwork.Context
{
    public class GuzellikSalonuDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }
        public virtual DbSet<Costumer> Costumers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source =DESKTOP-F43C5LA\\SQLEXPRESS; Initial Catalog=GuzellikSalonuDotNetCoreBigProject; User ID=sa;password=servet;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Costumer>().HasData(
          new Costumer
          {
              Id = 1,
              CostumerName = "Müşteri 1",
              CostumerSurname = "Soyadı 1",
              CostumerEmail = "musteri1@example.com",
              CostumerPhone = "555-111-1111",
              Point = 100,
              Balance = 500
          },
          new Costumer
          {
              Id = 2,
              CostumerName = "Müşteri 2",
              CostumerSurname = "Soyadı 2",
              CostumerEmail = "musteri1@example.com",
              CostumerPhone = "555-111-1111",
              Point = 100,
              Balance = 500

          },
          new Costumer
          {
              Id = 3,
              CostumerName = "Müşteri 3",
              CostumerSurname = "Soyadı 3",
              CostumerEmail = "musteri1@example.com",
              CostumerPhone = "555-111-1111",
              Point = 100,
              Balance = 500
          },
           new Costumer
           {
               Id = 4,
               CostumerName = "Müşteri 4",
               CostumerSurname = "Soyadı 4",
               CostumerEmail = "musteri1@example.com",
               CostumerPhone = "555-111-1111",
               Point = 100,
               Balance = 500
           },
            new Costumer
            {
                Id = 5,
                CostumerName = "Müşteri 5",
                CostumerSurname = "Soyadı 5",
                CostumerEmail = "musteri1@example.com",
                CostumerPhone = "555-111-1111",
                Point = 100,
                Balance = 500
            },
             new Costumer
             {
                 Id = 6,
                 CostumerName = "Müşteri 6",
                 CostumerSurname = "Soyadı 6",
                 CostumerEmail = "musteri1@example.com",
                 CostumerPhone = "555-111-1111",
                 Point = 100,
                 Balance = 500
             },
              new Costumer
              {
                  Id = 7,
                  CostumerName = "Müşteri 7",
                  CostumerSurname = "Soyadı 7",
                  CostumerEmail = "musteri1@example.com",
                  CostumerPhone = "555-111-1111",
                  Point = 100,
                  Balance = 500
              }, new Costumer
              {
                  Id = 8,
                  CostumerName = "Müşteri 8",
                  CostumerSurname = "Soyadı 8",
                  CostumerEmail = "musteri1@example.com",
                  CostumerPhone = "555-111-1111",
                  Point = 100,
                  Balance = 500
              }, new Costumer
              {
                  Id = 9,
                  CostumerName = "Müşteri 9",
                  CostumerSurname = "Soyadı 9",
                  CostumerEmail = "musteri1@example.com",
                  CostumerPhone = "555-111-1111",
                  Point = 100,
                  Balance = 500
              }, new Costumer
              {
                  Id = 10,
                  CostumerName = "Müşteri 10",
                  CostumerSurname = "Soyadı 10",
                  CostumerEmail = "musteri1@example.com",
                  CostumerPhone = "555-111-1111",
                  Point = 100,
                  Balance = 500
              });
              
        }

    }
}
