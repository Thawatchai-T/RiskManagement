using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Com.Ktbl.RiskManagement.Map.Repository;
using Com.Ktbl.RiskManagement.Process;
using Newtonsoft.Json;

namespace Com.Ktbl.RiskManagement.Web.Controllers
{
    public class AdminController : ApiController
    {
        private IBatchFileRepository BatchFileRepository { get; set; }
        // GET api/admin
        public IEnumerable<string> Get()
        {
            var obj = new FileProcess();
            obj.LoadFromFile();
            
            return new string[] { "value1", "value2" };
        }

        // GET api/admin/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/admin
        public void Post([FromBody]string value)
        {
        }

        // PUT api/admin/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/admin/5
        public void Delete(int id)
        {
        }

        public async Task<HttpResponseMessage> GetFile()
        {
            try
            {
                
                
                BatchFileRepository.InsertHead(new Domain.UploadHeaderDomain{
                    CreateBy="woody",
                    CreateDate = DateTime.Now,
                    FileName ="C:\\_Lab\\batch1.csv",
                    Status = "INPROGRESS",
                    UpdateBy="woody",
                    UpdateDate =DateTime.Now
                });

                var obj = new FileProcess();
                var ls =  obj.LoadFromFile();


                BatchFileRepository.SaveOrUpdate(ls);

                return new HttpResponseMessage()
                {
                    //Content = new StringContent(sb.ToString())
                    Content = new StringContent(JsonConvert.SerializeObject(ls))
                };
                
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        public string GetStandardCode(){

            var obj = new FileProcess();
            var ls = obj.LoadFromFileStandardCode();
            BatchFileRepository.Insert(ls);
            return null;
        }
    }
}
