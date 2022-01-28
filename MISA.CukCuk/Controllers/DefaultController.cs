using MISA.CukCuk.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MISA.CukCuk.Controllers
{
    public class DefaultController : ApiController
    {
        // GET: api/Default
        [Route("phuphuc")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Default/5
        public string Get(string name)
        {
            return name;
        }

        // POST: api/Default
        [Route("abc")]
        public Student Post([FromBody]Student student)
        {
            return student;
        }

        // PUT: api/Default/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Default/5
        public void Delete(int id)
        {
        }
    }
}
