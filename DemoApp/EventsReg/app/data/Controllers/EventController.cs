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
            if (id == null) 
            {
                return GetAllJsonEventsAsArray();
            }

            return JObject.Parse(File.ReadAllText(GetTargetFilePath(id)));
        } 
        
        public void Post(string id, JObject eventData) 
        {
            File.WriteAllText(GetTargetFilePath(id), eventData.ToString(Formatting.Indented));
        }

        private static string GetTargetFolderPath() 
        {
            return path + "../app/data/event/";
        }

        private static string GetTargetFilePath(string id) 
        {
            const string fmt = "{0}../app/data/event/{1}.json";
            return string.Format(fmt, path, id);
        }

        private JArray GetAllJsonEventsAsArray() 
        {
            var contents = string.Empty;
            foreach(var file in Directory.GetFiles(GetTargetFolderPath()))
            {
                contents += File.ReadAllText(file) + ",";
            }

            return JArray.Parse("[" + contents.Substring(0, contents.Length - 1) +"]");
        }
    }
}
