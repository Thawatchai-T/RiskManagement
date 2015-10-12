using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using log4net;
using System.Reflection;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

using Com.Ktbl.RiskManagement.Web.Models;
using Com.Ktbl.RiskManagement.Map.Repository;
using Com.Ktbl.RiskManagement.Domain.Common;


namespace Com.Ktbl.RiskManagement.Web.Controllers
{
    public class CommonController : ApiController
    {
        public static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private ICCISourceRepository CCISourceRepository { get; set; }
        private IOccupationRepository OccupationRepository { get; set; }
        private IPoliticianRelationshipRepository PoliticianRelationshipRepository { get; set; }
        private IPositionRepository PositionRepository { get; set; }
        private ICountryRepository CountryRepository { get; set; }
        private ICommonsRepository CommonRepository { get; set; }


        public string Title { get; set; }
        
        // GET api/common
        public IEnumerable<string> Get()
        {
            try
            {
                
                 //throw new Exception("error");
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
        //[FromUri] int type
        public List<CommonModel> GetBusinessType()
        {
            try
            {
                var result = CommonRepository.GetBusinessType().Select(x => new CommonModel
                {
                    Id = x.Id,
                    IsActive = x.IsActive,
                    Name = x.Name
                }).ToList();
                return result;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return new List<CommonModel>();
            }
            
        }

        public List<CommonModel> GetCommitteeType()
        {
            try
            {
                List<CommonModel> list = new List<CommonModel>();
                list.Add(new CommonModel {
                    Id = 1,
                    Name = "ผู้มีอำนาจลงนามแทนนิติบุคคล"
                
                });

                list.Add(new CommonModel
                {
                    Id = 2,
                    Name = "ผู้มีตำแหน่งเจ้าหน้าที่บริหารสูงสุด"

                });

                list.Add(new CommonModel
                {
                    Id = 3,
                    Name = "ผู้รับผลประโยชน์ที่แท้จริง"

                });

                list.Add(new CommonModel
                {
                    Id = 4,
                    Name = "ผู้รับมอบอำนาจให้ดำเนินการแทน"

                });

                return list;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return new List<CommonModel>();
            }
        }

        public List<CommonModel> GetIsicCode()
        {
            try
            {
                var result = new List<CommonModel>();
                result.Add(new CommonModel
                {
                    Id = 1,
                    IsActive = true,
                    Name = "ภาครัฐ"
                });

                result.Add(new CommonModel
                {
                    Id = 2,
                    IsActive = true,
                    Name = "รัฐวิสาหกิจ"
                });

                result.Add(new CommonModel
                {
                    Id = 3,
                    IsActive = true,
                    Name = "เอกชน"
                });

                
                return result;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return new List<CommonModel>();
            }
        }

        public List<CommonModel> GetLocationInCome()
        {
            try
            {
                var data = new CommonModel();
                return data.GenDummy(30);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return new List<CommonModel>();
            }
        }

        public JArray GetOccupation(string type)
        {
            //List<CommonModel> list = new List<CommonModel>();
            try
            {
                if (type.Equals("catelogy"))
                {
                    var list = this.OccupationRepository.GetOccupationCatelogy().Select(
                        x=>new{x.Id,x.Name});
                    return JArray.Parse(JsonConvert.SerializeObject(list));
                            
                }
                else if (type.Equals("group"))
                {
                    var list = this.OccupationRepository.GetOccupationGroup().Select(
                        x => new { x.Id, x.Name, CatelogyId= x.OccupationCatelogy.Id });
                    return JArray.Parse(JsonConvert.SerializeObject(list));

                }
                else if (type.Equals("type"))
                {
                    var list = this.OccupationRepository.GetOccupationType().Select(
                        x => new { x.Id, x.Name, GroupId = x.OccupationGroups.Id });
                    return JArray.Parse(JsonConvert.SerializeObject(list));
                }

                return null;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }

        public JArray GetPosition()
        {
            try
            {
                var list = this.PositionRepository.GetAll().Select(x=>new{x.Id,x.Name,TypeId=x.OccupationType.Id});
                return JArray.Parse(JsonConvert.SerializeObject(list));
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return new JArray();
            }
        }

        public JArray GetRegion()
        {
            try
            {
                var result = this.CountryRepository.GetAll();
                return JArray.Parse(JsonConvert.SerializeObject(result.Select(x => new { x.Id, Name = x.NameTH }).OrderBy(x => x.Name)));
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return new JArray();
            }
        }

        public JArray GetSourceOfIncome()
        {
            try
            {
                var result = this.CountryRepository.GetAll().Where(x=>x.IsActive == true);
                return JArray.Parse(JsonConvert.SerializeObject(result.Select(x => new { x.Id, Name = x.NameTH }).OrderBy(x=>x.Name)));
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return new JArray();
            }
        }

        public List<StandardCodeDomain> GetTitleName(){
            try
            {
                var result = this.CommonRepository.GetTitleName();
                return result;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return new List<StandardCodeDomain>();
            }
        }


        //public JArray GetPoliticianRelationship()
        //{
        //    var list = this.PoliticianRelationshipRepository.GetAll();
        //    return JArray.Parse(JsonConvert.SerializeObject(list));
        //}

        #endregion
        public List<CommonModel> GetRegistrationType(){
            try
            {
                var result = this.CommonRepository.GetRegistrationType().Select(x => new CommonModel
                {
                    Id = x.Id,
                    IsActive = x.IsActive,
                    Name = x.Name
                }).ToList();

                return result;
            }
            catch (Exception)
            {
                
                throw;
            }
       }



        public List<CommonModel> GetPoliticianRelationship()
        {

            try
            {
                var result = this.CommonRepository.GetRelationship().Select(x => new CommonModel
                {
                    Id = x.Id,
                    IsActive = x.IsActive,
                    Name = x.Name
                }).ToList();
                return result;
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }
    }
}
