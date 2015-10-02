using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Ktbl.RiskManagement.Domain;
using Com.Ktbl.RiskManagement.Domain.Common;

namespace Com.Ktbl.RiskManagement.Map.Repository
{
    public interface IPoliticianRelationshipRepository
    {
        bool Insert(PoliticianRelationshipDomain entity);
        bool Update(PoliticianRelationshipDomain entity);
        List<PoliticianRelationshipDomain> GetById(int id);
        bool Delete(PoliticianRelationshipDomain entity);
        List<PoliticianRelationshipDomain> GetAll();

        bool CheckPolitician(string p1, string p2);
    }

    public class PoliticianRelationshipRepository : NhRepository, IPoliticianRelationshipRepository
    {
        public bool Insert(PoliticianRelationshipDomain entity){

            try
            {
                Insert<PoliticianRelationshipDomain>(entity);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return false;
            }

        }

        public bool Update(PoliticianRelationshipDomain entity)
        {

            try
            {
                Update<PoliticianRelationshipDomain>(entity);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return false;
            }

        }

        public List<PoliticianRelationshipDomain> GetById(int id)
        {

            try
            {
               using( var session = SessionFactory.OpenStatelessSession())
               using(var tx = session.BeginTransaction())
               {
                   var result = session.QueryOver<PoliticianRelationshipDomain>().Where(x=>x.Id == id).List();
                   return result as List<PoliticianRelationshipDomain>;
               }

            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return null;
            }

        }

        public bool Delete(PoliticianRelationshipDomain entity)
        {

            try
            {
                Delete<PoliticianRelationshipDomain>(entity);
                return true;
                
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return false;
            }

        }

        public List<PoliticianRelationshipDomain> GetAll(){
            try
            {
                var result = this.ExecuteICriteria<PoliticianRelationshipDomain>();
                return result as List<PoliticianRelationshipDomain>;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public bool CheckPolitician(string fname, string lname){
            try
            {
                var fullname = string.Format("{0} {1}",fname,lname);

                using (var session = SessionFactory.OpenStatelessSession())
                {
                    var result = session.QueryOver<PoliticianRelationshipDomain>().Where(x =>
                        (x.SingleStringName == fullname && x.FirstName == fname)
                        ||
                        (x.SingleStringName == fullname && x.Surname == lname)).List<PoliticianRelationshipDomain>();

                    return (result.Count > 0) ? true : false;

                }
            }
            catch (Exception)
            {
                
                throw;
            }
        
        }


    }
}
