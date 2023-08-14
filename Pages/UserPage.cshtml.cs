using Microsoft.AspNetCore.Mvc.RazorPages;
using MotivWebApp.Models;
using MotivWebApp.Source.Products;
using Newtonsoft.Json;

namespace MotivWebApp.Pages
{
    public class UserPageModel : PageModel
    {
        
        private readonly ProductRegistry productRegistry;

        public UserPageModel(ProductRegistry productRegistry) 
        {
            this.productRegistry = productRegistry;
        }

        public User? CurrentUser { get; private set; } = null;

        public async Task OnGetAsync()
        {
            if (CurrentUser == null) {
                var httpClient = new HttpClient();
                HttpResponseMessage response = await httpClient.GetAsync("https://randomuser.me/api/");
                dynamic? jsonData = JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());
                if (jsonData != null) {
                    CurrentUser = new User(jsonData.results[0], productRegistry.GetRandomProduct());
                }
            }
        }
    }
}