using System.Web.Http;
using EmpeekTask.Models;
using System.Collections.Generic;

namespace EmpeekTask.Controllers
{
    public class HomeController : ApiController
    {
        Information information;
        // GET: api/Home
        [HttpGet]
        public List<string> Get()
        {
            information = new Information();
            return information.drivers;
        }
        
        [HttpPost]
        public Information GetFiles( MyPath path)
        {
            information = new Information();
            string myPath = path.ToString();
            information.isFile = Information.Check(myPath);
            if (information.isFile)
                information.GetCurrentFiles(myPath);
            return information;
        }

        [HttpPost]
        [Route("api/Home/Counter")]
        public int[] Counter(MyPath path)
        {
            return new Counter().Count(path.ToString());
        }


    }

}
