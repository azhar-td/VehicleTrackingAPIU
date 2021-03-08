using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace VehicleData.Models
{
    public class VehicleTrackingContext: DbContext
    {
        public VehicleTrackingContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> User { get; set; }
        public DbSet<UserLogin> UserLogin { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<VehicleLogin> VehicleLogin { get; set; }
        public DbSet<VehiclePosition> VehiclePosition { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    // configures one-to-many relationship
        //    modelBuilder.Entity<UserLogin>()
        //        .HasRequired<User>(s => s.User)
        //        .WithMany(g => g.UserLogin)
        //        .HasForeignKey<int>(s => s.UserId);
        //    // configures one-to-many relationship
        //    modelBuilder.Entity<VehicleLogin>()
        //        .HasRequired<Vehicle>(s => s.Vehicle)
        //        .WithMany(g => g.VehicleLogin)
        //        .HasForeignKey<int>(s => s.VehicleId);
        //    // configures one-to-many relationship
        //    modelBuilder.Entity<VehiclePosition>()
        //        .HasRequired<Vehicle>(s => s.Vehicle)
        //        .WithMany(g => g.VehiclePosition)
        //        .HasForeignKey<int>(s => s.VehicleId);
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                Name = "Azhar",
                Email = "azhar.teradata@gmail.com",
                Password="azhar123",
                CreationDT=DateTime.Now
            });
            modelBuilder.Entity<Vehicle>().HasData(new Vehicle
            {
                Id = 1,
                RegNum="LEE-09-1208",
                Model="2009",
                Password = "azhar123",
                CreationDT = DateTime.Now
            });
            modelBuilder.Entity<VehiclePosition>().HasData(new VehiclePosition
            {
                Id = 1,
                VehicleId = 1,
                Longitude=decimal.Parse("-74.00"),
                Latitude= decimal.Parse("40.73"),
                TimeStamp = DateTime.Now
            });
            modelBuilder.Entity<VehiclePosition>().HasData(new VehiclePosition
            {
                Id = 2,
                VehicleId = 1,
                Longitude = decimal.Parse("72.67"),
                Latitude = decimal.Parse("32.09"),
                TimeStamp = DateTime.Now.AddMinutes(-10)
            });
        }
    }
}
