using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dtos.Queries;
namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        //localhost:62918/api/values?val1=a&val1=b&val1=d&val2=b
        [HttpGet]
        public IActionResult Get([FromQuery] List<string> Val1,[FromQuery] string Val2="2")
        {
            //rdeturn new string[] { "value1", "value2" };
            string s="";
            foreach(string i in Val1)    s += i + "# ";
            return Ok(s + " " + Val2);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id,[FromQuery]ProductQuery query)
        {
            //return Ok("value");
            return Ok(query.PageSize + " " + query.PageStep);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
