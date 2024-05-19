using SUT23_Labb4Models;

namespace SUT23_Labb4.Services
{
    public interface ICustomer
    {
        Task AddBooking(int customerId, DateTime startTime, DateTime endTime, int companyId);
        Task UpdateBooking(int bookingId, DateTime startTime, DateTime endTime);
        Task CancelBooking(int bookingId);
        Task<Customer> GetCustomerById(int id);
    }
}
