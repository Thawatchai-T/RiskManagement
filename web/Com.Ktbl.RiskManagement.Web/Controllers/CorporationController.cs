#define DEBUG
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Com.Ktbl.RiskManagement.Domain;
using Com.Ktbl.RiskManagement.Map.Repository;
using Com.Ktbl.RiskManagement.Process;
using Newtonsoft.Json;

namespace Com.Ktbl.RiskManagement.Web.Controllers
{
    public class CorporationController : ApiController
    {
        private MainProcess MainProcess { get; set; }
        private ICorporationRepository CorporationRepository { get; set; }


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
        public void Post(CorporationDomain value)
        {
            //getAll individual by corporation id
            //check risk with individual id
            //select hight risk 
            //return hight risk to page 
            //var cp = this.CorporationRepository.GetAll().Where(x => x.Id == int.Parse(value)).FirstOrDefault<CorporationDomain>();

            //if (cp != null)
            //{

            //    MainProcess.TakeRisksCorporation(cp);
            //}


           // return "bra";
        }

        // PUT api/corporation/5
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE api/corporation/5
        public void Delete(int id)
        {
        }

        public async Task<HttpResponseMessage> PostFile()
        {
            // Check if the request contains multipart/form-data.
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            string root = HttpContext.Current.Server.MapPath("~/App_Data/Uploads");
            var provider = new MultipartFormDataStreamProvider(root);
            try
            {
                // Read the form data and return an async task.
                await Request.Content.ReadAsMultipartAsync(provider);
                var data = new Dictionary<string, string>();

                foreach (var key in provider.FormData.AllKeys)
                {
                    foreach (var val in provider.FormData.GetValues(key))
                    {
                        if (val.Equals("on"))
                            data.Add(key, true.ToString());
                        else if (val.Equals("off"))
                            data.Add(key, "0");
                        else
                            data.Add(key, val);
                    }
                }

                var objdto = Db2Linq.ConvertToEntity<CorporationDomain>(data);

                // This illustrates how to get the file names for uploaded files.
                int index = 0;
                foreach (var file in provider.FileData)
                {
                    FileInfo fileInfo = new FileInfo(file.LocalFileName);

                    var filename = string.Format("{0}_{1}.{2}", objdto.RegistrationId, DateTime.Now.ToString("ddMMyyyyhhmmss"), (index == 0)?objdto.Extension1:objdto.Extension2);
                    
                    //move to appcode
                    //fileInfo.MoveTo(fileInfo.DirectoryName + "\\" + string.Format("{0}_{1}_{2}.jpg", objdto.CitizenId, DateTime.Now.ToString("ddMMyyyyhhmmss"), index));

                    if (index == 0)
                    {
                        objdto.PathFile = filename;
                        fileInfo.MoveTo("d:\\tmp" + "\\" + objdto.PathFile);

                        index++;
                    }
                    else
                    {
                        objdto.PathFile1 = filename;
                        fileInfo.MoveTo("d:\\tmp" + "\\" + objdto.PathFile);
                    }


                }

                //insert inot risktable
                //PersonalRepository.Insert(objdto);

                //var risk = MainProcess.TakeRisksCorporation(objdto);
                //objdto.Result = risk.Result;


                objdto.CreateDate = DateTime.Now;
                objdto.UpdateDate = DateTime.Now;
                objdto.UpdateBy = "moji";
                objdto.CreateBy = "moji";
                var result = CorporationRepository.Insert(objdto);


                return new HttpResponseMessage()
                {
                    //Content = new StringContent(sb.ToString())
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(JsonConvert.SerializeObject(result))
                };

            }
            catch (System.Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        public string GetRisk([FromUri] int Id)
        {
            //getAll individual by corporation id
            //check risk with individual id
            //select hight risk 
            //return hight risk to page 


            //TODO:  [20150810] Woody debug
            #if DEGUG
                Id = 24;
            #endif

            var cp = this.CorporationRepository.GetAll().Where(x => x.Id == Id).FirstOrDefault<CorporationDomain>();

            if (cp != null)
            {
                var result = MainProcess.TakeRisksCorporation(cp);
                return result.Result;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
