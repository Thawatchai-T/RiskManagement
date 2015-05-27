using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Com.Ktbl.RiskManagement.Web.Controllers
{
    public class IndividualController : ApiController
    {
        // GET api/individual
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/individual/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/individual
        public void Post([FromBody]string value)
        {
        }

        // PUT api/individual/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/individual/5
        public void Delete(int id)
        {
        }

        /// <summary>
        /// personal
        /// </summary>
        public string GetPersonal(){

            return null;
        }

    }
}
