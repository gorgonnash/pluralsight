using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ServiceFabric.Services.Client;
using Microsoft.ServiceFabric.Services.Remoting.Client;

using MyStatefulService.Interfaces;
using MyWebService.Models;

namespace MyWebService.Controllers
{
    public class HelloWorldController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public string Welcome()
        {
            return "This is the Welcome action method...";
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
