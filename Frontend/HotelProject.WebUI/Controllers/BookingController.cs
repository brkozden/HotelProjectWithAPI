using HotelProject.WebUI.Dtos.BookingDto;
using HotelProject.WebUI.Dtos.SubscribeDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class BookingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult AddBooking()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> AddBooking(CreateBookingDto createBooking)
        {
            createBooking.Status = false;
            createBooking.Description = string.Empty;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBooking);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            await client.PostAsync("http://localhost:5233/api/Booking", content);
            return RedirectToAction("Index", "Default");
        }
    }
}
