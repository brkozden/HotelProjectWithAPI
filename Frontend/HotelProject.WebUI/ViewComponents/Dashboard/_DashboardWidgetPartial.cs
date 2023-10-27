using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardWidgetPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardWidgetPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5233/api/DashboardWidgets/StaffCount");
            var responseMessage2 = await client.GetAsync("http://localhost:5233/api/DashboardWidgets/BookingCount");
            var responseMessage3 = await client.GetAsync("http://localhost:5233/api/DashboardWidgets/ContactCount");
            var responseMessage4 = await client.GetAsync("http://localhost:5233/api/DashboardWidgets/SubscribeCount");


            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
            var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
            ViewBag.StaffCount = jsonData;
            ViewBag.BookingCount = jsonData2;
            ViewBag.ContactCount = jsonData3;
            ViewBag.SubscribeCount = jsonData4;

            return View();
        }
    }
}
