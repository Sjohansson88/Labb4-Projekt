using Microsoft.EntityFrameworkCore;
using SUT23_Labb4.Data;
using SUT23_Labb4Models;

namespace SUT23_Labb4.Services
{
    public class CustomerRepo : ICustomer
    {

        private BookingDbContext _dbContext;
        private readonly ILogger<CustomerRepo> _logger;

        public CustomerRepo(BookingDbContext bookingDbContext, ILogger<CustomerRepo> logger)
        {
            _dbContext = bookingDbContext;
            _logger = logger;
        }
        public async Task AddBooking(int customerId, DateTime startTime, DateTime endTime, int companyId, string createdBy)
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

                var history = new BookingHistory
                {
                    BookingId = newBooking.AppointmentId,
                    OldStartTime = null,
                    OldEndTime = null,
                    NewStartTime = newBooking.StartTime,
                    NewEndTime = newBooking.EndTime,
                    ChangedAt = DateTime.Now,
                    ChangedBy = createdBy
                };

                _dbContext.BookingHistories.Add(history);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                _logger.LogError("Error occurred while adding booking");
                throw new Exception("Error occurred while adding booking: ");
            }
        }

        public async Task DeleteBooking(int bookingId, string deletedBy)
        {
            try
            {
                var booking = await _dbContext.Appointments.FindAsync(bookingId);

                if (booking == null)
                {
                    throw new Exception("Booking not found");
                }


                var bookingHistory = new BookingHistory
                {
                    BookingId = bookingId,
                    OldStartTime = booking.StartTime,
                    OldEndTime = booking.EndTime,

                    ChangedAt = DateTime.UtcNow,
                    ChangedBy = deletedBy
                };

                _dbContext.BookingHistories.Add(bookingHistory);
                _dbContext.Appointments.Remove(booking);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new Exception("Error occurred while cancelling booking");
            }
        }

        public async Task UpdateBooking(int bookingId, DateTime startTime, DateTime endTime, string changedBy)
        {
            try
            {
                var booking = await _dbContext.Appointments.FindAsync(bookingId);

                if (booking == null)
                {
                    throw new Exception("Booking not found");
                }


                var bookingHistory = new BookingHistory
                {
                    BookingId = bookingId,
                    OldStartTime = booking.StartTime,
                    OldEndTime = booking.EndTime,
                    NewStartTime = startTime,
                    NewEndTime = endTime,
                    ChangedAt = DateTime.UtcNow,
                    ChangedBy = changedBy
                };

                _dbContext.BookingHistories.Add(bookingHistory);


                booking.StartTime = startTime;
                booking.EndTime = endTime;

                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new Exception("Error occurred while updating booking");
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
