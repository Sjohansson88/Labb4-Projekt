using SUT23_Labb4Models;

namespace SUT23_Labb4.Services
{
    public interface ICompany
    {
        Task AddBooking(int customerId, DateTime startTime, DateTime endTime, int companyId, string createdBy);
        Task UpdateBooking(int bookingId, DateTime startTime, DateTime endTime, string changedBy);
        Task DeleteBooking(int bookingId, string deletedBy);
        Task<IEnumerable<Appointment>> GetCompanyBookingsForMonth(int companyId, int year, int month);
        Task<IEnumerable<Appointment>> GetCompanyBookingsForWeek(int companyId, int year, int weekNumber);
        Task<IEnumerable<BookingHistory>> GetBookingHistory(int bookingId);

    }
}
