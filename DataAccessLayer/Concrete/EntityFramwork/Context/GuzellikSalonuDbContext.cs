using DataEntitiesLayer.Entities;
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


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source =DESKTOP-F43C5LA\\SQLEXPRESS; Initial Catalog=GuzellikSalonuDotNetCoreBigProject; User ID=sa;password=servet;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
