// Author: Mohamed
// Purpose: Database context for managing Orders and Spices tables in an Sqlite database
using Microsoft.EntityFrameworkCore;
using SpiceFlow_Stock_Manager.Entities;

namespace SpiceFlow_Stock_Manager.Services
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options) { }

        // Orders table data
        public DbSet<Order> Orders { get; set; }
        // Spices table data
        public DbSet<Spice> Spices { get; set; }
        // Users table data
        public DbSet<User> Users { get; set; }

        // Seeding the tables with default data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seeding Spices table
            modelBuilder.Entity<Spice>().HasData(
                new Spice
                {
                    SpiceId = 1,
                    SpiceName = "Habanero",
                    Stock = 150,
                    Sales = 75,
                    Origin = "Mexico",
                    Price = 15,
                    ImageUrl = "https://i.imgur.com/beHWs9b.jpeg",
                    ScovilleRating = 100000,
                    ExpiryDate = new DateTime(2026, 5, 30)
                },
                new Spice
                {
                    SpiceId = 2,
                    SpiceName = "Jalapeno",
                    Stock = 300,
                    Sales = 120,
                    Origin = "Mexico",
                    ImageUrl = "https://i.imgur.com/8NQXwNE.jpeg",
                    ScovilleRating = 8000,
                    ExpiryDate = new DateTime(2026, 7, 30)
                },
                new Spice
                {
                    SpiceId = 3,
                    SpiceName = "Ghost Pepper",
                    Stock = 50,
                    Sales = 30,
                    Price = 14,
                    Origin = "India",
                    ImageUrl = "https://i.imgur.com/OxvJXwy.jpeg",
                    ScovilleRating = 1000000,
                    ExpiryDate = new DateTime(2026, 3, 30)
                },
                new Spice
                {
                    SpiceId = 4,
                    SpiceName = "Cayenne",
                    Stock = 200,
                    Sales = 90,
                    Price = 9,
                    Origin = "French Guiana",
                    ImageUrl = "https://i.imgur.com/QaeGKvO.jpeg",
                    ScovilleRating = 50000,
                    ExpiryDate = new DateTime(2026, 4, 30)
                },
                new Spice
                {
                    SpiceId = 5,
                    SpiceName = "Serrano",
                    Stock = 180,
                    Sales = 60,
                    Price = 8,
                    Origin = "Mexico",
                    ImageUrl = "https://i.imgur.com/wcnPUFM.jpeg",
                    ScovilleRating = 2500,
                    ExpiryDate = new DateTime(2026, 6, 30)
                }
            );

            // Seeding Users table
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
                    UserName = "spicelover99",
                    Email = "spicelover99@hotmail.com",
                    Password = "1234",
                    PhoneNumber = "555-123-2020",
                    Address = "123 Spice St, Flavor Town",
                    PostalCode = "L2D 3D1",
                    IsManager = false,
                    Cart = ""
                },
                new User
                {
                    UserId = 2,
                    UserName = "pepperenjoyer",
                    Email = "pepperenjoyer@gmail.com",
                    Password = "1234",
                    PhoneNumber = "647-090-2383",
                    Address = "456 Heat Ave, Spice City",
                    PostalCode = "R3C 8N9",
                    IsManager = false,
                    Cart = ""
                },
                new User
                {
                    UserId = 3,
                    UserName = "heatfan",
                    Email = "heatfanatic@hotmail.com",
                    Password = "1234",
                    PhoneNumber = "401-398-3874",
                    Address = "789 Fire Blvd, Pepperville",
                    PostalCode = "U2C 9A7",
                    IsManager = false,
                    Cart = ""
                },
                new User
                {
                    UserId = 4,
                    UserName = "spiceman",
                    Email = "spicyguy@spicemail.ca",
                    Password = "1234",
                    PhoneNumber = "212-932-5294",
                    Address = "321 Flame Rd, Chili Town",
                    PostalCode = "X8N 6F5",
                    IsManager = false,
                    Cart = ""
                },
                new User
                {
                    UserId = 5,
                    UserName = "saffronman",
                    Email = "zestfest@mail.ca",
                    Password = "1234",
                    PhoneNumber = "901-219-7391",
                    Address = "654 Zest Ln, Aroma City",
                    PostalCode = "Z1Z 2M3",
                    IsManager = false,
                    Cart = ""
                }
            );

            // Seeding Orders table
            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    OrderId = 1,
                    SpiceId = 1,
                    UserId = 1,
                    OrderDate = new DateTime(2025, 11, 20),
                    ETA = new DateTime(2025, 12, 5)
                },
                new Order
                {
                    OrderId = 2,
                    SpiceId = 3,
                    UserId = 2,
                    OrderDate = new DateTime(2025, 11, 23),
                    ETA = new DateTime(2025, 12, 3)
                },
                new Order
                {
                    OrderId = 3,
                    SpiceId = 2,
                    UserId = 3,
                    OrderDate = new DateTime(2025, 11, 25),
                    ETA = new DateTime(2025, 12, 2)
                },
                new Order
                {
                    OrderId = 4,
                    SpiceId = 4,
                    UserId = 4,
                    OrderDate = new DateTime(2025, 11, 27),
                    ETA = new DateTime(2025, 12, 4)
                },
                new Order
                {
                    OrderId = 5,
                    SpiceId = 5,
                    UserId = 5,
                    OrderDate = new DateTime(2025, 11, 29),
                    ETA = new DateTime(2025, 12, 6)
                }
            );
        }
    }
}
