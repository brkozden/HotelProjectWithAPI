using HotelProject.BusinessLayer.Abstrack;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardWidgetsController : ControllerBase, IDashboardWidgetsController
    {
        private readonly IStaffService _staffService;
        private readonly IBookingService _bookingService;
        private readonly IContactService _contactService;
        private readonly ISubscribeService _subscribeService;

        public DashboardWidgetsController(IStaffService staffService, IBookingService bookingService, IContactService contactService, ISubscribeService subscribeService)
        {
            _staffService = staffService;
            _bookingService = bookingService;
            _contactService = contactService;
            _subscribeService = subscribeService;
        }
        [HttpGet("StaffCount")]
        public IActionResult StaffCount()
        {
            var value = _staffService.TGetStaffCount();
            return Ok(value);
        }
        [HttpGet("BookingCount")]
        public IActionResult BookingCount()
        {
            var value = _bookingService.TGetBookingCount();
            return Ok(value);
        }
        [HttpGet("ContactCount")]
        public IActionResult ContactCount()
        {
            var value = _contactService.TGetContactCount();
            return Ok(value);
        }
        [HttpGet("SubscribeCount")]
        public IActionResult SubscribeCount()
        {
            var value = _subscribeService.TGetSubscribeCount();
            return Ok(value);
        }
    }
}
