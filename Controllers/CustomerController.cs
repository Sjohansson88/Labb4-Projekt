using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        [Authorize]
        public async Task<IActionResult> AddBooking(int customerId, DateTime startTime, DateTime endTime, int companyId, string createdBy)
        {
            try
            {
                await _customer.AddBooking(customerId, startTime, endTime, companyId, createdBy);
                return Ok(new { message = "Booking added successfully" });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error occurred while adding booking" });
            }
        }

        [HttpPut("UpdateBooking/{bookingId}")]
        [Authorize]
        public async Task<IActionResult> UpdateBooking(int bookingId, DateTime startTime, DateTime endTime, string changedBy)
        {
            try
            {
                await _customer.UpdateBooking(bookingId, startTime, endTime, changedBy);
                return Ok(new { message = "Booking updated successfully" });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error occurred while updating booking" });
            }
        }

        [HttpDelete("CancelBooking/{bookingId}")]
        [Authorize]
        public async Task<IActionResult> DeleteBooking(int bookingId, string deletedBy)
        {
            try
            {
                await _customer.DeleteBooking(bookingId, deletedBy);
                return Ok(new { message = "Booking cancelled successfully" });
            }
            catch (Exception ex)
            {
                if (ex.Message == "Booking not found")
                {
                    return NotFound(new { message = ex.Message });
                }
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to delete Data from Database");
            }
        }

        [HttpGet("Customer{id:int}")]  //Funkar
        [Authorize]
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
