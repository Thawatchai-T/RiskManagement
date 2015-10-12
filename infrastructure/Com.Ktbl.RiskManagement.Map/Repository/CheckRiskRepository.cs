using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Ktbl.RiskManagement.Domain;

namespace Com.Ktbl.RiskManagement.Map.Repository
{
    public class CheckRiskRepository : NhRepository
    {
        public List<CheckRiskR3Model> GetAllR3()
        {
            try
            {
                //var result = this.ExecuteICriteria<CorporationDomain>();
                //var result = this.GetAll<CorporationDomain>();
                using (var session = SessionFactory.OpenSession())
                using (var tx = session.BeginTransaction())
                {
                    var result = session.QueryOver<CheckRiskR3Model>().List<CheckRiskR3Model>();
                    return result as List<CheckRiskR3Model>;
                }

            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return null;
            }
        }


        public List<CheckRiskR2Model> GetAllR2()
        {
            try
            {
                using (var session = SessionFactory.OpenSession())
                using (var tx = session.BeginTransaction())
                {
                    var result = session.QueryOver<CheckRiskR2Model>().List<CheckRiskR2Model>();
                    return result as List<CheckRiskR2Model>;
                }

            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return null;
            }
        }
    }
}
