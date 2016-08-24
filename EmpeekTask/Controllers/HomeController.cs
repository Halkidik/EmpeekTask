using System.Web.Http;
using EmpeekTask.Models;
using System.Collections.Generic;

namespace EmpeekTask.Controllers
{
    public class HomeController : ApiController
    {
        static Information information;
        static bool flag;
        // GET: api/Home
        [HttpGet]
        public List<string> Get()
        {
            information = new Information();
            return Information.drivers;
        }
        
        [HttpPost]
        public Information GetFiles( MyPath path)
        {
            string myPath = path.ToString();
            information.isFile = Information.Check(myPath);
            if (information.isFile)
                information.GetCurrentFiles(myPath);
            return information;
        }

        [HttpGet]
        [Route("api/Home/Counter")]
        public int[] Counter()
        {
            return new Counter().Count(information.currentPath);
        }


    }

}
