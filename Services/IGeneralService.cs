using SUT23_Labb4Models;

namespace SUT23_Labb4.Services
{
    public interface IGeneralService
    {
        Task<IEnumerable<Customer>> GetAllCustomers();
        Task<Customer> GetCustomerById(int id);
        Task<IEnumerable<Customer>> GetCustomersWithBookingsNext7Days();
        Task<int> GetNumberOfBookingsForCustomerInWeek(int customerId, int weekNumber);
    }
}
