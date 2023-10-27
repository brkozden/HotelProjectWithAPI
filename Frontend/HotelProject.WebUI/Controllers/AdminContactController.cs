using HotelProject.WebUI.Dtos.ContactDto;
using HotelProject.WebUI.Dtos.SendMessageDto;
using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class AdminContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Inbox()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5233/api/Contact");
            var responseMessage2 = await client.GetAsync("http://localhost:5233/api/Contact/GetContactCount");
            var responseMessage3 = await client.GetAsync("http://localhost:5233/api/SendMessage/GetSendMessageCount");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<InboxContactDto>>(jsonData);
                ViewBag.getContactCount = jsonData2;
                ViewBag.getSendCount = jsonData3;
                return View(values);
            }
        
           
            return View();
       
        }
        public async Task<IActionResult> SendBox()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5233/api/SendMessage");
            var responseMessage2 = await client.GetAsync("http://localhost:5233/api/Contact/GetContactCount");
            var responseMessage3 = await client.GetAsync("http://localhost:5233/api/SendMessage/GetSendMessageCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSendboxDto>>(jsonData);
                ViewBag.getContactCount = jsonData2;
                ViewBag.getSendCount = jsonData3;
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddSendMessage()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage2 = await client.GetAsync("http://localhost:5233/api/Contact/GetContactCount");
            var responseMessage3 = await client.GetAsync("http://localhost:5233/api/SendMessage/GetSendMessageCount");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.getContactCount = jsonData2;
            ViewBag.getSendCount = jsonData3;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddSendMessage(CreateSendMessage createSendMessage)
        {
            createSendMessage.SenderMail = "admin@gmail.com";
            createSendMessage.SenderName = "Admin";
            createSendMessage.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createSendMessage);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5233/api/SendMessage", content);
            if (responseMessage.IsSuccessStatusCode) {
               
                return RedirectToAction("SendBox"); }

            return View();
        }

        public async Task<IActionResult> MessageDetailsBySendbox(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5233/api/SendMessage/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetMessageByIdDto>(jsonData);
                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> MessageDetailsByInbox(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5233/api/Contact/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<InboxContactDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public async Task<PartialViewResult> SidebarAdminContactPartial()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5233/api/Contact/GetContactCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                ViewBag.getContactCount = jsonData;
             
            }
            return PartialView(ViewBag.getContactCount);
        }
        public PartialViewResult SidebarAdminContactCategoryPartial()
        {
            return PartialView();
        }

    
    }

}
