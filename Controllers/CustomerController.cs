using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SUT23_Labb4.Services;

namespace SUT23_Labb4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private ICustomer _customer;

        public CustomerController(ICustomer customer)
        {
            _customer = customer;
        }



        [HttpPost("AddBooking")]
        public async Task<IActionResult> AddBooking(int customerId, DateTime startTime, DateTime endTime, int companyId)
        {
            try
            {
                await _customer.AddBooking(customerId, startTime, endTime, companyId);
                return Ok(new { message = "Booking added successfully" });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to add Data to Database");
            }
        }


        [HttpPut("UpdateBooking/{bookingId}")]
        public async Task<IActionResult> UpdateBooking(int bookingId, DateTime startTime, DateTime endTime)
        {
            try
            {
                await _customer.UpdateBooking(bookingId, startTime, endTime);
                return Ok(new { message = "Booking updated successfully" });
            }
            catch (Exception ex)
            {
                if (ex.Message == "Booking not found")
                {
                    return NotFound(new { message = ex.Message });
                }
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to update Data from Database");
            }
        }



        [HttpDelete("CancelBooking/{bookingId}")]
        public async Task<IActionResult> CancelBooking(int bookingId)
        {
            try
            {
                await _customer.CancelBooking(bookingId);
                return Ok(new { message = "Booking cancelled successfully" });
            }
            catch (Exception ex)
            {
                if (ex.Message == "Booking not found")
                {
                    return NotFound(new { message = ex.Message });
                }
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }






        [HttpGet("Customer{id:int}")]  //Funkar
        public async Task<IActionResult> GetCustomerById(int id)
        {
            try
            {
                var customer = await _customer.GetCustomerById(id);
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
    }
}
