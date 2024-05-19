using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SUT23_Labb4.Services;

namespace SUT23_Labb4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneralController : ControllerBase
    {
        private IGeneralService _generalService;

        public GeneralController(IGeneralService generalService)
        {
            _generalService = generalService;
        }


        [HttpGet("All Customer")] //Funkar bra. 
        public async Task<IActionResult> GetAllCustomer()
        {
            try
            {
                return Ok(await _generalService.GetAllCustomers());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to get Data from Database");
            }
        }

        [HttpGet("Customer{id:int}")]  //Funkar
        public async Task<IActionResult> GetCustomerById(int id)
        {
            try
            {
                var customer = await _generalService.GetCustomerById(id);
                if (customer == null)
                {
                    return NotFound();
                }
                return Ok(customer);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to get Data from Database");
            }
        }

        [HttpGet("CustomersWithBookingsNext7Days")]
        public async Task<IActionResult> GetCustomersWithBookingsNext7Days()
        {
            try
            {
                var customers = await _generalService.GetCustomersWithBookingsNext7Days();

                
                var result = customers.Select(c => new { Id = c.CustomerId, Name = c.Name });

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to get Data from Database");
            }
        }



        [HttpGet("NumberOfBookingsForCustomerInWeek")]
        public async Task<IActionResult> GetNumberOfBookingsForCustomerInWeek(int customerId, int weekNumber)
        {
            try
            {
                var numberOfBookings = await _generalService.GetNumberOfBookingsForCustomerInWeek(customerId, weekNumber);

                return Ok(numberOfBookings);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to get Data from Database");
            }
        }
    }
}
