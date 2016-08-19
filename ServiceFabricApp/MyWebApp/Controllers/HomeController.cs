using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ServiceFabric.Services.Client;
using Microsoft.ServiceFabric.Services.Remoting.Client;

using MyStatefulService.Interfaces;

namespace MyWebApp.Controllers
{
    public class CountModel
    {
        public long Count { get; set; }

        public string Timestamp { get; set; }
    }

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Count()
        {
            ICounter counter = ServiceProxy.Create<ICounter>(new Uri("fabric:/ServiceFabricApp/MyStatefulService"), new ServicePartitionKey(0));
            long count = await counter.GetCountAsync();

            var model = new CountModel
            {
                Count = count,
                Timestamp = DateTime.UtcNow.ToLongDateString()
            };

            return View(model);
        }
    }
}
