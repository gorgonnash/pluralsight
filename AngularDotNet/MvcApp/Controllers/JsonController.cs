using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Web.Mvc;
using static System.Net.WebRequestMethods;

namespace MvcApp.Controllers
{
    public class JsonController : Controller
    {
        public ContentResult Json2(object data, JsonRequestBehavior behavior = JsonRequestBehavior.DenyGet)
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            if (Request.RequestType == Http.Get && behavior == JsonRequestBehavior.DenyGet) 
            {
                throw new InvalidOperationException("GET is not permitted for this request.");
            }

            return new ContentResult
            {
                Content = JsonConvert.SerializeObject(data, settings),
                ContentType = "application/json"
            };
        }
    }
}