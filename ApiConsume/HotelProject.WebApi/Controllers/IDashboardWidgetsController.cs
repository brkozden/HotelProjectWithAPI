using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    public interface IDashboardWidgetsController
    {
        IActionResult BookingCount();
        IActionResult StaffCount();
    }
}