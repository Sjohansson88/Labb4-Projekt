using Microsoft.EntityFrameworkCore;

using SUT23_Labb4Models;

namespace SUT23_Labb4.Data
{
    public class BookingDbContext : DbContext
    {
        public BookingDbContext(DbContextOptions<BookingDbContext> options) : base(options) 
        {
            
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<BookingHistory> BookingHistories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Appointments)
                .WithOne(a => a.Customer)
                .HasForeignKey(a => a.CustomerId);

            modelBuilder.Entity<Company>()
                .HasMany(c => c.Appointments)
                .WithOne(a => a.Company)
                .HasForeignKey(a => a.CompanyId);



           



            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerId = 1, Name = "Åke Svanstedt", Email = "ake@example.com" },
                new Customer { CustomerId = 2, Name = "Björn Goop", Email = "bjorn@example.com" },
                new Customer { CustomerId = 3, Name = "Stig H Johansson", Email = "stig@example.com" },
                new Customer { CustomerId = 4, Name = "Erik Adielsson", Email = "erik@example.com" }
            );


            modelBuilder.Entity<Company>().HasData(
                new Company { CompanyId = 1, Name = "Neptunuskliniken" },
                new Company { CompanyId = 2, Name = "Breareds vårdcentral" },
                new Company { CompanyId = 3, Name = "Wim Hof Terapi" }

            );

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment { AppointmentId = 1, StartTime = new DateTime(2024, 5, 15, 10, 0, 0), EndTime = new DateTime(2024, 5, 15, 11, 0, 0), CustomerId = 1, CompanyId = 1 },
                new Appointment { AppointmentId = 2, StartTime = new DateTime(2024, 5, 16, 13, 0, 0), EndTime = new DateTime(2024, 5, 16, 14, 0, 0), CustomerId = 2, CompanyId = 2 },
                new Appointment { AppointmentId = 3, StartTime = new DateTime(2024, 5, 25, 11, 0, 0), EndTime = new DateTime(2024, 5, 25, 13, 0, 0), CustomerId = 1, CompanyId = 1 },
                new Appointment { AppointmentId = 4, StartTime = new DateTime(2024, 5, 26, 13, 0, 0), EndTime = new DateTime(2024, 5, 26, 14, 0, 0), CustomerId = 3, CompanyId = 3 },
                new Appointment { AppointmentId = 5, StartTime = new DateTime(2024, 5, 27, 14, 0, 0), EndTime = new DateTime(2024, 5, 27, 16, 0, 0), CustomerId = 4, CompanyId = 2 }
            );






        }
        
    }
}
