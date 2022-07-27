using Car_Dealership_App.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Car_Dealership_App.Repository.DbContextFolder
{
    public class CarDbContext : DbContext
    {
        public DbSet<Car>? Cars { get; set; }
        public DbSet<CarDealer>? CarDealers { get; set; }

        public DbSet<CarType>? CarTypes { get; set; }

        public CarDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\car.mdf;Integrated Security=True;MultipleActiveResultSets=true";
                builder.UseSqlServer(conn).UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarDealer>(cardealer => cardealer
                .HasMany<Car>().WithOne()
                .HasForeignKey(cart => cart.DealerID));

            modelBuilder.Entity<CarType>(cartype => cartype
                .HasMany<Car>()
                .WithOne()
                .HasForeignKey(carr => carr.CTID));

            modelBuilder.Entity<Car>(car => car.
                HasOne<CarDealer>()
                .WithMany(cars => cars.Cars)
                .HasForeignKey(card => card.DealerID)
                .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Car>(car => car
                .HasOne(carr => carr.CarType)
                .WithMany()
                .HasForeignKey(card => card.CTID));

            modelBuilder.Entity<CarType>().HasData(new CarType[]
                {
                        //CTID#Brand#Type#Fuel#CCM#HP
                    new CarType("1#Mercedes#CLS-200D#Diesel#1998#180"),
                    new CarType("2#Mercedes#CLS-300#Gas#2997#360"),
                    new CarType("3#Mercedes#EQC-100#Electric#0000#350"),
                    new CarType("4#Mercedes#SEC-560#Gas#5578#460"),
                    new CarType("5#Mercedes#G-500#Gas#4996#450")

                });

            modelBuilder.Entity<CarDealer>().HasData(new CarDealer[]
                {            
                            //DealerID#PostalCode#Name#City#Streer#HouseNum
                    new CarDealer("1#5600#Mike-Car#Mezőtúr#Puskin#109"),
                    new CarDealer("2#1204#Csilag_Car#Budapest#Felszabadulás#33"),
                    new CarDealer("3#1540#Mercedes-Hovány#Kecskemét#Petőfi#2"),
                    new CarDealer("4#4500#Tulipán_Autóker#Dunaharaszti#Lenin#8")

                });

            modelBuilder.Entity<Car>().HasData(new Car[]
                {
                    //CarTypeID#DealerID#Km#Price#CCM#HP#ProductionYear-Month#ID
                    new Car("1#1#117067#2000#pink#2017-4#1"),
                    new Car("3#4#317067#3000#red#2022-6#2"),
                    new Car("4#3#417067#6000#red#2004-9#3"),
                    new Car("1#4#17067#17000#red#1980-7#4"),
                    new Car("4#2#117067#2000#blue#2010-6#5"),
                    new Car("2#4#11706#19000#red#1980-12#6"),

                });

        }
    }
}