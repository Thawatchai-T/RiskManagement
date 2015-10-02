using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Ktbl.RiskManagement.Domain;
using NHibernate.Criterion;

namespace Com.Ktbl.RiskManagement.Map.Repository
{

    public interface ICorporationRepository
    {
        CorporationDomain Insert(CorporationDomain entity);
        bool Update(CorporationDomain entity);
        List<CorporationDomain> GetAll();
        bool Delete(CorporationDomain entity);

        List<ShareholdersDomain> GetShareholdersWithCoporationId(int id);
    }

    public class CorporationRepository : NhRepository, ICorporationRepository
    {
        public CorporationDomain Insert(CorporationDomain entity)
        {

            try
            {
                var id = Insert<CorporationDomain>(entity);
                entity.Id = (int)id;
                return entity;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return null; ;
            }

        }

        public bool Update(CorporationDomain entity)
        {

            try
            {
                Update<CorporationDomain>(entity);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return false;
            }

        }

        public List<CorporationDomain> GetAll()
        {
            try
            {
                //var result = this.ExecuteICriteria<CorporationDomain>();
                //var result = this.GetAll<CorporationDomain>();
                using(var session = SessionFactory.OpenSession())
                using(var tx = session.BeginTransaction())
                {
                    var result = session.QueryOver<CorporationDomain>().List<CorporationDomain>();
                    return result as List<CorporationDomain>;
                }
                
                

            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return null;
            }
        }

        public bool Delete(CorporationDomain entity)
        {

            try
            {
                Delete<CorporationDomain>(entity);
                return true;

            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return false;
            }

        }

        /// <summary>
        /// Get shareholders with corporation id
        /// </summary>
        /// <param name="id">corporation id</param>
        /// <returns>List of shareholder</returns>
        public List<ShareholdersDomain> GetShareholdersWithCoporationId(int id){
            try
            {
                using(var session = SessionFactory.OpenStatelessSession())
                using(var tx = session.BeginTransaction())
                {
                    var reslut = session.CreateCriteria<ShareholdersDomain>()
                        .Add(Restrictions.Eq("CorporationId", id)).List<ShareholdersDomain>();

                    return reslut as List<ShareholdersDomain>;
                }

            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                throw;
            }
        }

    }
}
