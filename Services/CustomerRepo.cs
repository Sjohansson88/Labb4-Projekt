using Microsoft.EntityFrameworkCore;
using SUT23_Labb4.Data;
using SUT23_Labb4Models;

namespace SUT23_Labb4.Services
{
    public class CustomerRepo : ICustomer
    {

        private BookingDbContext _dbContext;

        public CustomerRepo(BookingDbContext bookingDbContext)
        {
            _dbContext = bookingDbContext;
        }
        public async Task AddBooking(int customerId, DateTime startTime, DateTime endTime, int companyId)
        {
            try
            {
               
                var newBooking = new Appointment
                {
                    CustomerId = customerId,
                    StartTime = startTime,
                    EndTime = endTime,
                    CompanyId = companyId
                };

               
                _dbContext.Appointments.Add(newBooking);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                
                throw new Exception("Error occurred while adding booking");
            }
        }

        public async Task CancelBooking(int bookingId)
        {
            try
            {
               
                var booking = await _dbContext.Appointments.FindAsync(bookingId);

                if (booking == null)
                {
                    throw new Exception("Booking not found");
                }

              
                _dbContext.Appointments.Remove(booking);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
               
                throw new Exception("Error occurred while cancelling booking");
            }
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            return await _dbContext.Customers.Include(c => c.Appointments).FirstOrDefaultAsync(c => c.CustomerId == id);
        }

        public async Task UpdateBooking(int bookingId, DateTime startTime, DateTime endTime)
        {
            try
            {
               
                var booking = await _dbContext.Appointments.FindAsync(bookingId);

                if (booking == null)
                {
                    throw new Exception("Booking not found");
                }

               
                booking.StartTime = startTime;
                booking.EndTime = endTime;

                
                _dbContext.Appointments.Update(booking);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                
                throw new Exception("Error occurred while updating booking");
            }
        }



    }
}
