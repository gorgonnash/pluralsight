using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Web.Hosting;
using System.Web.Http;

namespace AppData.Controllers
{
    //[Authorize]
    public class EventController : ApiController
    {
        private static string path {
            get {
                return HostingEnvironment.MapPath("/");
            }
        }

        public JToken Get(string id = null)
        {
            return JObject.Parse(File.ReadAllText(GetTargetPath(id)));
        } 
        
        public void Post(string id, JObject eventData) 
        {
            File.WriteAllText(GetTargetPath(id), eventData.ToString(Formatting.Indented));
        }

        private static string GetTargetPath(string id) 
        {
            const string fmt = "{0}../app/data/event/{1}.json";
            return string.Format(fmt, path, id);
        }
    }
}
