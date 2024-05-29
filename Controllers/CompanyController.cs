using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SUT23_Labb4.Services;
using SUT23_Labb4Models;

namespace SUT23_Labb4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {

        private ICompany _dbContext;
        public CompanyController(ICompany dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpPost("AddBooking")]
        [Authorize]
        public async Task<IActionResult> AddBooking(int customerId, DateTime startTime, DateTime endTime, int companyId, string createdBy)
        {
            try
            {
                await _dbContext.AddBooking(customerId, startTime, endTime, companyId, createdBy);
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
                await _dbContext.UpdateBooking(bookingId, startTime, endTime, changedBy);
                return Ok(new { message = "Booking updated successfully" });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error occurred while updating booking"});
            }
        }



        [HttpDelete("CancelBooking/{bookingId}")]
        [Authorize]
        public async Task<IActionResult> DeleteBooking(int bookingId, string deletedBy)
        {
            try
            {
                await _dbContext.DeleteBooking(bookingId, deletedBy);
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



        [HttpGet("GetCompanyBookingsForMonth/{companyId}/{year}/{month}")]
        [Authorize]
        public async Task<IActionResult> GetCompanyBookingsForMonth(int companyId, int year, int month)
        {
            try
            {
                var bookings = await _dbContext.GetCompanyBookingsForMonth(companyId, year, month);

                if (bookings == null || !bookings.Any())
                {
                    return NotFound(new { message = "No bookings found for the specified company and month" });
                }

                return Ok(bookings);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error occurred while retrieving bookings"});
            }
        }


        [HttpGet("GetCompanyBookingsForWeek/{companyId}/{year}/{weekNumber}")]
        [Authorize]
        public async Task<IActionResult> GetCompanyBookingsForWeek(int companyId, int year, int weekNumber)
        {
            try
            {
                var bookings = await _dbContext.GetCompanyBookingsForWeek(companyId, year, weekNumber);

                if (bookings == null || !bookings.Any())
                {
                    return NotFound(new { message = "No bookings found for the specified company and week" });
                }

                return Ok(bookings);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error occurred while retrieving bookings" });
            }
        }


        [HttpGet("GetAllBookingHistory")]
        [Authorize]
        public async Task<IActionResult> GetAllBookingHistory()
        {
            try
            {
                var bookingHistory = await _dbContext.GetBookingHistory();

                if (bookingHistory == null || !bookingHistory.Any())
                {
                    return NotFound(new { message = "No booking history found" });
                }

                return Ok(bookingHistory);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error occurred while retrieving booking history", details = ex.Message });
            }
        }

    } 
}
