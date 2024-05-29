using SUT23_Labb4Models;

namespace SUT23_Labb4.Services
{
    public interface ICustomer
    {
        Task AddBooking(int customerId, DateTime startTime, DateTime endTime, int companyId, string createdBy);
        Task UpdateBooking(int bookingId, DateTime startTime, DateTime endTime, string changedBy);
        Task DeleteBooking(int bookingId, string deletedBy);
        Task<Customer> GetCustomerById(int id);
    }
}
