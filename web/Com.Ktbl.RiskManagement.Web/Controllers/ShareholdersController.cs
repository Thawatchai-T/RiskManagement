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
using Com.Ktbl.RiskManagement.Web.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Com.Ktbl.RiskManagement.Web.Controllers
{
    public class ShareholdersController : ApiController
    {
        private IShareholderRepository ShareholderRepository { get; set; }
        private IOccupationRepository OccupationRepository { get; set; }

        private MainProcess MainProcess { get; set; }

        // GET api/shareholders
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/shareholders/5
        public ShareholdersDomain Get(int id)
        {
            try
            {
                var obj = ShareholderRepository.GetById(id).SingleOrDefault();
                return obj;
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        // POST api/shareholders
        public void Post([FromBody]string value)
        {
        }

        // PUT api/shareholders/5
        public void Put(int id, [FromBody]string value)
        {
            string test = value;
        }

       /// <summary>
       /// update isactive in table  shareholders
       /// </summary>
       /// <param name="id"></param>
        public void Delete(int id)
        {
            try
            {
                this.ShareholderRepository.Update(id);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        /// <summary>
        /// Display grid data form add committee
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="page"></param>
        /// <param name="start"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public PageModel<ViewShareholdersDomain> GetShareholdersGridView(int id, int page, int start, int limit)
        {
            try
            {
                PageModel<ViewShareholdersDomain> pagemodel = new PageModel<ViewShareholdersDomain>();
                
                var result =  this.ShareholderRepository.GetViewShareholderWithCoporationId(id);
                var list = (from x in result
                            join y in OccupationRepository.GetOccupationType()
                                on x.OccupationTypeId equals y.Id
                            select new ViewShareholdersDomain
                            {
                                Id = x.Id,
                                BusinessId = x.BusinessId,
                                BusinessName = x.BusinessName,
                                CitizenId = x.CitizenId,
                                CommitteeType = x.CommitteeType,
                                CommitteeTypeName = x.CommitteeTypeName,
                                CorporationId = x.CorporationId,
                                OccupationTypeId = x.OccupationTypeId,
                                PoliticianRelationship = x.PoliticianRelationship,
                                PoliticianRelationshipName = x.PoliticianRelationshipName,
                                SourceOfIncome = x.SourceOfIncome,
                                SourceOfIncomeName = x.SourceOfIncomeName,
                                OccupationTypeName = y.Name
                            }).Skip(start).Take(limit).ToList<ViewShareholdersDomain>();
                pagemodel.data = list;
                pagemodel.total = result.Count;
                
                return pagemodel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// insert data form add committee 
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
                // Read the form data and return an async task.
                await Request.Content.ReadAsMultipartAsync(provider);
                var data = new Dictionary<string, string>();

                // This illustrates how to get the form data.
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

                //converta data json object to dao object 
                var objdto = Db2Linq.ConvertToEntity<ShareholdersDomain>(data);

                int index = 0;
                foreach (var file in provider.FileData)
                {
                    FileInfo fileInfo = new FileInfo(file.LocalFileName);
                    string filename = string.Format("{0}_{1}_{2}.pdf",objdto.CorporationId,objdto.CitizenId,DateTime.Now.ToShortTimeString());
                    var extension = fileInfo.Extension;
                    //movefile to server
                    //fileInfo.MoveTo(fileInfo.DirectoryName + "\\" + string.Format("{0}_{1}_{2}.jpg", objdto.CitizenId, DateTime.Now.ToString("ddMMyyyyhhmmss"), index));

                    if (index == 0)
                    {
                        //filename 1
                        objdto.PathFile = fileInfo.Name;


                        index++;
                    }
                    else 
                    {
                        //filename 2
                        objdto.PathFile1 = fileInfo.Name;
                    }


                }
                
                #region common field in table 
                objdto.CreateDate = DateTime.Now;
                objdto.UpdateDate = DateTime.Now;
                objdto.UpdateBy = "moji";
                objdto.CreateBy = "moji";
                objdto.IsActive = true;
                #endregion

                var result = ShareholderRepository.Insert(objdto);
                objdto.Id = (int)result;

                return new HttpResponseMessage()
                {
                    //Content = new StringContent(sb.ToString())
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(JsonConvert.SerializeObject(objdto))
                };

            }
            catch (System.Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        public string GetResult(string Agrcode, string Appname, string User){
            try
            {
                return "result";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
        }

    }
}
