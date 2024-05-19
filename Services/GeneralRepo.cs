using Microsoft.EntityFrameworkCore;
using SUT23_Labb4.Data;
using SUT23_Labb4Models;

namespace SUT23_Labb4.Services
{
    public class GeneralRepo : IGeneralService
    {
        private BookingDbContext _dbContext;

        public GeneralRepo(BookingDbContext bookingDbContext)
        {
            _dbContext = bookingDbContext;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return await _dbContext.Customers.ToListAsync();
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            return await _dbContext.Customers.Include(c => c.Appointments).FirstOrDefaultAsync(c => c.CustomerId == id);
        }

        public async Task<IEnumerable<Customer>> GetCustomersWithBookingsNext7Days()
        {
            var today = DateTime.Today;
            var nextWeek = today.AddDays(7);

            return await _dbContext.Customers
                .Include(c => c.Appointments)
                .Where(c => c.Appointments.Any(a => a.StartTime >= today && a.EndTime <= nextWeek))
                .ToListAsync();
        }

        public async Task<int> GetNumberOfBookingsForCustomerInWeek(int customerId, int weekNumber)
        {
            DateTime startDateOfWeek = GetStartDateOfWeek(weekNumber);
            DateTime endDateOfWeek = startDateOfWeek.AddDays(7);

            int numberOfBookings = await _dbContext.Appointments
        .CountAsync(a => a.CustomerId == customerId && a.StartTime >= startDateOfWeek && a.EndTime < endDateOfWeek);

            return numberOfBookings;
        }


        private DateTime GetStartDateOfWeek(int weekNumber)
        {

            DateTime startOfYear = new DateTime(DateTime.Now.Year, 1, 1);


            DateTime startDateOfWeek = startOfYear.AddDays((weekNumber - 1) * 7);


            startDateOfWeek = startDateOfWeek.AddDays(-(int)startDateOfWeek.DayOfWeek + (int)DayOfWeek.Monday);

            return startDateOfWeek;
        }


     
    }
}
