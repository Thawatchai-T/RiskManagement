using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using System.IO;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Text;
using Com.Ktbl.RiskManagement.Domain;
using Newtonsoft.Json;
using AutoMapper;
using System.Reflection;
using Com.Ktbl.RiskManagement.Map.Repository;
using Com.Ktbl.RiskManagement.Process;


namespace Com.Ktbl.RiskManagement.Web.Controllers
{
    public class IndividualController : ApiController
    {
        private PersonalModel Personal { get; set; }
        private IPersonalRepository PersonalRepository { get; set; }
        private ICCISourceRepository CCIRepository { get; set; }

        private MainProcess MainProcess { get; set; }

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

        //// POST api/individual
        //public void Post([FromBody]string value)
        //{
        //}

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

        //[HttpPost]
        public string Post(IEnumerable<HttpPostedFileBase> files)
        {
            try
            {
                foreach (var file in files)
                {
                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                       var path = Path.Combine("~/App_Data/Uploads/"+fileName);
                        file.SaveAs("");
                    }
                }
                //return Json(new { success = true, message = "อัพโหลดไฟล์เรียบร้อยแล้ว" }, JsonRequestBehavior.AllowGet);
                return "";
            }
            catch (Exception ex)
            {
                //return Json(new { success = false, message = "ไม่สามารถอัพโหลดไฟล์" }, JsonRequestBehavior.AllowGet);
                return ex.Message;
            }
        }

        public string PostData(PersonalModel data){
            try{
                var d = data;

                return "";
            }catch(Exception)
            {
                throw;
            }

        
        }

        /// <summary>
        /// jsonmap 
        /// http://stackoverflow.com/questions/7310533/dictionary-string-string-map-to-an-object-using-automapper
        /// </summary>
        /// <returns></returns>
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
                StringBuilder sb = new StringBuilder(); // Holds the response body

                await Request.Content.ReadAsMultipartAsync(provider);
              
                var data = new Dictionary<string, string>();

                // This illustrates how to get the form data.
                foreach (var key in provider.FormData.AllKeys)
                {
                    foreach (var val in provider.FormData.GetValues(key))
                    {
                        data.Add(key, val);
                    }
                }

                var objdto = Db2Linq.ConvertToEntity<PersonalModel>(data);

                // This illustrates how to get the file names for uploaded files.
                int index = 0;
                foreach (var file in provider.FileData)
                {
                    FileInfo fileInfo = new FileInfo(file.LocalFileName);

                    var extension = fileInfo.Extension;

                    
                    sb.Append(string.Format("Uploaded file: {0} ({1} bytes)\n", fileInfo.Name, fileInfo.Length));
                    if (index == 0)
                    {
                        //File.Move(
                        objdto.PathFile = string.Format("{0}_{1}_{2}{3}", objdto.CitizenId, DateTime.Now.ToString("ddMMyyyyhhmmss"), index, objdto.Extension1);
                        fileInfo.MoveTo("d:\\tmp" + "\\" + objdto.PathFile);
                        
                       
                        index++;
                    }
                    else
                    {
                        objdto.PathFile1 = string.Format("{0}_{1}_{2}{3}", objdto.CitizenId, DateTime.Now.ToString("ddMMyyyyhhmmss"), index, objdto.Extension2);
                        fileInfo.MoveTo("d:\\tmp" + "\\" + objdto.PathFile1);

                    }


                }
                
                var risk = MainProcess.TakeRisksPersonal(objdto);
                
                //insert risk table
                PersonalRepository.Insert(risk);

                return new HttpResponseMessage()
                {
                    //Content = new StringContent(sb.ToString())
                    Content = new StringContent(JsonConvert.SerializeObject(risk))
                };


            }
            catch (System.Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        public List<PersonalModel> GetCheck(string type)
        {

            if (type.Equals("r2"))
            {
               //return this.PersonalRepository.ChaeckTypeR2();
                return null;
            }
            else
            {
                return null;
            }
           //check cci 
            bool cciStatus = this.CCIRepository.CheckCCI("", "", "");
            
        }

        public void GetResult(string key,string user,string requestno){
            try
            {

            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
