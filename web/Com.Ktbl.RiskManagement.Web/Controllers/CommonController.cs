using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using log4net;
using System.Reflection;

namespace Com.Ktbl.RiskManagement.Web.Controllers
{
    public class CommonController : ApiController
    {
        public static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        
        public string Title { get; set; }

        // GET api/common
        public IEnumerable<string> Get()
        {
            try
            {
                
                 throw new Exception("error");
                 return new string[] { "value1", "xys" };
            }
            catch (Exception e)
            {
                Logger.Error(e);    
              //  throw;
                return null;
            }
            
        }

        // GET api/common/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/common
        public void Post([FromBody]string value)
        {
        }

        // PUT api/common/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/common/5
        public void Delete(int id)
        {
        }

        #region Combobox 

        //public string Get(int[] ids)
        //{
        //    switch (ids.Length)
        //    {
        //        case 0:
        //            return "all";

        //        default:
        //            return "multiple";
        //    }
        //}

        //[HttpGet]
        public string GetBusinessType([FromUri] int type)
        {
            return "";
        }

        public string GetCommitteeType()
        {
            return Title;
        }

        public string GetIsicCode()
        {
            return Title;
        }

        //public string GetLocationInCome()
        //{
        //    return Title;
        //}

        //public string GetOccupation(string type)
        //{
        //    switch (type)
        //    {
        //        default:
        //            break;
        //    }
        //    return Title;
        //}

        //public string GetPosition(){
        //    return Title;
        //}

        //public string GetRegion(){
        //    return Title;
        //}

        //public string GetSourceOfIncome(){
        //    return Title;
        //}
        #endregion
    }
}
