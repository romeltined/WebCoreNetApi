using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;

namespace WebCoreNetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public ValuesController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {

            //string request = Request.Body..ToString(); //.ToString();
            var webRoot = _hostingEnvironment.WebRootPath;

            string pathString = @"C:\inetpub\wwwroot\WebNetCoreApi\DataFile";
            //string pathString = webRoot + @"\DataFile";

            string fileName = System.IO.Path.GetRandomFileName();
            pathString = System.IO.Path.Combine(pathString, fileName);
            if (!System.IO.File.Exists(pathString))
            {
                using (System.IO.FileStream fs = System.IO.File.Create(pathString))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(value);
                    fs.Write(info, 0, info.Length);
                }
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
