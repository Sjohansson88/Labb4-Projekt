using Microsoft.EntityFrameworkCore;
using SUT23_Labb4.Data;
using SUT23_Labb4Models;
using System.Globalization;

namespace SUT23_Labb4.Services
{
    public class CompanyRepo : ICompany
    {

        private BookingDbContext _dbContext;
        private readonly ILogger<CompanyRepo> _logger;

        public CompanyRepo(BookingDbContext dbContext, ILogger<CompanyRepo> logger)
        {
            _dbContext = dbContext;
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

        public async Task<IEnumerable<BookingHistory>> GetBookingHistory()
        {
            try
            {
                var bookingHistory = await _dbContext.BookingHistories
                    .OrderByDescending(bh => bh.ChangedAt)
                    .ToListAsync();

                return bookingHistory;
            }
            catch (Exception)
            {
                throw new Exception("Error occurred while retrieving booking history");
            }
        }

        public async Task<IEnumerable<Appointment>> GetCompanyBookingsForMonth(int companyId, int year, int month)
        {
            try
            {
                var startDate = new DateTime(year, month, 1);
                var endDate = startDate.AddMonths(1).AddDays(-1);

                var bookings = await _dbContext.Appointments
                    .Where(a => a.CompanyId == companyId && a.StartTime >= startDate && a.StartTime <= endDate)
                    .ToListAsync();

                return bookings;
            }
            catch (Exception)
            {
                throw new Exception("Error occurred while retrieving bookings");
            }
        }

       public async Task<IEnumerable<Appointment>> GetCompanyBookingsForWeek(int companyId, int year, int weekNumber)
{
    try
    {
        
        var startDateOfWeek = GetStartDateOfWeek(weekNumber);

      
        var endDateOfWeek = startDateOfWeek.AddDays(6).AddHours(23).AddMinutes(59).AddSeconds(59);

       
        var bookings = await _dbContext.Appointments
            .Where(a => a.CompanyId == companyId && a.StartTime >= startDateOfWeek && a.StartTime <= endDateOfWeek)
            .ToListAsync();

        return bookings;
    }
    catch (Exception)
    {
        throw new Exception("Error occurred while retrieving bookings");
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

        private DateTime GetStartDateOfWeek(int weekNumber)
        {
            DateTime startOfYear = new DateTime(DateTime.Now.Year, 1, 1);
            DateTime startDateOfWeek = startOfYear.AddDays((weekNumber - 1) * 7);
            startDateOfWeek = startDateOfWeek.AddDays(-(int)startDateOfWeek.DayOfWeek + (int)DayOfWeek.Monday);
            return startDateOfWeek;
        }
    }
}
