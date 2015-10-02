using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Ktbl.RiskManagement.Domain;
using Com.Ktbl.RiskManagement.Map.Repository;

namespace Com.Ktbl.RiskManagement.Process
{
    public class MainProcess
    {
        #region Repository
        private IPoliticianRelationshipRepository PoliticianRepository{get;set;}
        private ICCISourceRepository CCISourceRepository { get; set; }
        private IDecisionTableRepository DecisionTableRepository { get; set; }
        private ICountryRepository CountryRepository { get; set; }
        private IShareholderRepository ShareholderRepository { get; set; }
        private ICorporationRepository CorporationRepository { get; set; }
        #endregion
        public List<DecisionTable> DecisionTable { get; set; }
        public DecisionTable DecisionEntity { get; set; }

        public void TakeRisks(string type){
            
           try{

               if (type.Equals(TypeRiskPersonal.R3paoc))
               {
                   //check type personal

                   this.PersonalProcess();
               }
               else if (type.Equals(""))
               {
                   this.CorporationProcess();
               }

           }catch(Exception  e){
           
           }
        }

        #region Main Process
        /// <summary>
        /// 1. check Politician relationship 
        /// 2.
        /// </summary>
        protected void PersonalProcess(){
            DecisionEntity = new DecisionTable();
           

        }

        protected void CorporationProcess(){
            try
            {

            }
            catch (Exception)
            {
                
                throw;
            }
        }
        #endregion
        #region Sub Process
        protected bool IsPolitician(int politician){
            try
            {
                var result = this.PoliticianRepository.GetAll().Where(x => (x.SingleStringName == "" && x.FirstName == "") || (x.SingleStringName == "" && x.Surname == ""));
                return (result.Count() > 0) ? true : false;
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }
        /// <summary>
        /// Check cci 
        /// </summary>
        /// <param name="amlo"></param>
        /// <returns></returns>
        protected bool CheckAmlo(int amlo){
            try
            {
                var reslut = this.CCISourceRepository.GetAll().Where(x => x.Id == ""
                    || (x.FirstName == "" && x.Surname == "")
                    || x.SingleStringName == "");
                return (reslut.Count() > 0) ? true : false;
            }
            catch (Exception)
            {
                
                throw;
            }
            
            return (amlo == 0) ? true : false;
        }

        protected bool CheckRiskOccupation(int occupation){
            return (occupation==0)?true:false;
        }

        protected bool CheckCountr(int country)
        {
            return (country == 0) ? true : false;
        }

        protected bool CheckSourceOfIncome(int sourceofincome){
            return (sourceofincome == 0) ? true : false;
        }

        protected bool CheckOrgPolitician(List<int> list){

            return false;
        }
        #endregion

        public List<DecisionTable> Dummy(){

            var dt = new DecisionTable{
                Id =1 ,
                Amlo = true,
                Country = true,
                Occupation = true,
                PEPs = true
            };

            List<DecisionTable> list = new List<DecisionTable>();

            list.Add(dt);

            return list;

        }

        public PersonalModel TakeRisksPersonal(PersonalModel objdto)
        {
            try
            {
                Random gen = new Random();
                
                var amlo = CCISourceRepository.CheckCCI(objdto.CitizenId, objdto.FirstName, objdto.LastName);
                var peps = PoliticianRepository.CheckPolitician(objdto.FirstName, objdto.LastName);
                //ref HR07 in table OccupationCatelogy
                var occupation = (gen.Next(100) < 20) ? true : false;
                bool country = this.CountryRepository.CheckCountry(objdto.SourceOfIncome);

                DecisionEntity = new DecisionTable
                {
                    Amlo = amlo,
                    PEPs = peps,
                    Occupation = occupation,
                    Country = country
                };

                string result =  this.DecisionTableRepository.TaskRisk(DecisionEntity);

                objdto.Result = result;

                  return objdto;
            }
            catch (Exception)
            {
                throw;
            }
            //throw new NotImplementedException();
        }
        /// <summary>
        /// 1. นิติบุคคลตามที่กำหนดในเอกสารแนบ 1 เป็น R1
        /// 2. 16-25 check register company in thai? 
        ///    2.1 case register in thai is true, check PES = true  return R3
        ///    2.2 case no register in thai not accept 
        /// 
        /// </summary>
        /// <param name="objdto"></param>
        /// <returns></returns>
        public CorporationDomain TakeRisksCorporation(CorporationDomain objdto)
        {
            try
            {
                Random gen = new Random();
                Dictionary<int, DecisionTable> risk = new Dictionary<int, DecisionTable>();
                string result = "";
                //var amlo = CCISourceRepository.CheckCCI(objdto.CitizenId, objdto.FirstName, objdto.LastName);
                //var peps = PoliticianRepository.CheckPolitician(objdto.FirstName, objdto.LastName);
                
                /*case seq 1-15 Ref เอกสารแนบหนึ่ง
                 * รายชื่อ
                 */
                if ((gen.Next(100) % 2) == 0)
                {
                    result = "R1";

                }
                else if ((gen.Next(100) % 2) == 0) //16-25
                {
                    //eject not registration in thailand
                    if (objdto.IsRegistrationThai)
                    {
                        //get shareholder by corporation id
                        CheckRisk(objdto, gen, risk);

                    }
                    else//
                    {
                        objdto.Result = "ปฏิเสธการให้สินเชื่อเพราะตามนโยบายสินเชื่อจะรับเฉพราะลูกค้านิติบุคคลที่จดทะเบียนในประเทศไทยเท่านั้น";
                        //return
                    }
                }
                else
                {
                    CheckRisk(objdto, gen, risk);
                }

               // var occupation = (gen.Next(100) < 20) ? true : false;
               // bool country = this.CountryRepository.CheckCountry(objdto.SourceOfIncome);

                // TODO select worst case in the shareholder 
                if (risk.Count > 0)
                {
                    var riskresult = risk.Select(x => new { id = x.Key, x.Value.Result, x.Value.Level }).OrderByDescending(x => x.Level);
                    objdto.Result = riskresult.Select(x => x.Result).First();
                }
                else
                {
                    objdto.Result = result;
                }
                return objdto;
            }
            catch (Exception)
            {
                throw;
            }
            return new CorporationDomain();

        }

        private void CheckRisk(CorporationDomain objdto, Random gen, Dictionary<int, DecisionTable> risk)
        {
            var sdr = CorporationRepository.GetShareholdersWithCoporationId(objdto.Id);

            string levelrisk = "";

            bool peps, amlo, occupation, country;

            foreach (var item in sdr)
            {

                peps = PoliticianRepository.CheckPolitician(item.FirstName, item.LastName);
                amlo = CCISourceRepository.CheckCCI(item.CitizenId, item.FirstName, item.LastName);
                occupation = (gen.Next(100) < 20) ? true : false;
                country = this.CountryRepository.CheckCountry(item.SourceOfIncome);
                DecisionEntity = new DecisionTable
                {
                    Amlo = amlo,
                    PEPs = peps,
                    Occupation = occupation,
                    Country = country
                };
                DecisionTable data = this.DecisionTableRepository.TaskRiskCorporation(DecisionEntity);

                //add level risk to dc
                risk.Add(item.Id, data);
            }
        }
    }
}