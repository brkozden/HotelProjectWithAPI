using HotelProject.WebUI.Dtos.DashboardDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;


namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardSubscribeCountPartial:ViewComponent
    {
        public async Task<IViewComponentResult>  InvokeAsync()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://instagram-profile1.p.rapidapi.com/getprofileinfo/hotel"),
                Headers =
    {
        { "X-RapidAPI-Key", "8bb495a98fmshf97fd0e080d789ap1383b3jsnef35517ec6a6" },
        { "X-RapidAPI-Host", "instagram-profile1.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
              ResultInstagramFollowersDto  resultInstagramFollowersDto = JsonConvert.DeserializeObject<ResultInstagramFollowersDto>(body);
                return View(resultInstagramFollowersDto);
            }
         
        }
    }
}
