using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Com.Ktbl.RiskManagement.Web.Controllers
{
    public class CorporationController : ApiController
    {
        // GET api/corporation
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/corporation/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/corporation
        public void Post([FromBody]string value)
        {
        }

        // PUT api/corporation/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/corporation/5
        public void Delete(int id)
        {
        }
    }
}
