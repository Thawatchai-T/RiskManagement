using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Ktbl.RiskManagement.Domain;
using Com.Ktbl.RiskManagement.Domain.Common;

namespace Com.Ktbl.RiskManagement.Map.Repository
{
    public interface ICCISourceRepository
    {
        bool Insert(CCISourceDomain entity);
        bool Update(CCISourceDomain entity);
        List<CCISourceDomain> GetAll();
        bool Delete(CCISourceDomain entity);

        bool CheckCCI(string cid, string fname, string lname);
    }

    public class CCISourceRepository : NhRepository, ICCISourceRepository
    {
        public bool Insert(CCISourceDomain entity){

            try
            {
                Insert<CCISourceDomain>(entity);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return false;
            }

        }

        public bool Update(CCISourceDomain entity)
        {

            try
            {
                Update<CCISourceDomain>(entity);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return false;
            }

        }

        public List<CCISourceDomain> GetAll(){
            try
            {
                var result = this.ExecuteICriteria<CCISourceDomain>();
                return result as List<CCISourceDomain>;

            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return null;
            }
        }

        public bool Delete(CCISourceDomain entity)
        {

            try
            {
                Delete<CCISourceDomain>(entity);
                return true;
                
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return false;
            }

        }

        public bool CheckCCI(string cid, string fname, string lname){
            
            string fullname = string.Format("{0} {1}",fname,lname);

            using( var session = SessionFactory.OpenStatelessSession())
            {
                var result = session.QueryOver<CCISourceDomain>().Where(x =>
                    (x.SingleStringName == fullname && x.FirstName == fname)
                    ||
                    (x.SingleStringName == fullname && x.Surname == lname)).List<CCISourceDomain>();
                return (result.Count > 0) ? true : false;
            }
        }
    }
}
