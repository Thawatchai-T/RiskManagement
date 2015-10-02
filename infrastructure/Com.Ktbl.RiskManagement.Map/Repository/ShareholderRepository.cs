using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Ktbl.RiskManagement.Domain;
using NHibernate.Criterion;

namespace Com.Ktbl.RiskManagement.Map.Repository
{
    public interface IShareholderRepository
    {
        object Insert(ShareholdersDomain entity);
        bool Update(ShareholdersDomain entity);
        bool Update(int id);
        List<ShareholdersDomain> GetById(int id);
        bool Delete(ShareholdersDomain entity);
        List<ViewShareholdersDomain> GetViewShareholderWithCoporationId(int id);
    }
    public class ShareholderRepository : NhRepository, IShareholderRepository
    {
        public object Insert(ShareholdersDomain entity){

            try
            {
                //HibernatingRhinos.Profiler.Appender
                //insert set isactive = ture every time
                entity.IsActive = true;
                var obj = Insert<ShareholdersDomain>(entity);
                return obj;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return false;
            }

        }

        public bool Update(ShareholdersDomain entity)
        {

            try
            {
                Update<ShareholdersDomain>(entity);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return false;
            }

        }

        public bool Update(int id){
            
            using(var session = SessionFactory.OpenStatelessSession())
            using(var tx = session.BeginTransaction())
            {
                try
                {
                    var entity = session.Get<ShareholdersDomain>(id);
                    entity.IsActive = false;
                    session.Update(entity);
                    tx.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    Logger.Error(ex);
                    return false;
                }
            }
            
        }

        public List<ShareholdersDomain> GetById(int id)
        {

            try
            {
               using( var session = SessionFactory.OpenStatelessSession())
               using(var tx = session.BeginTransaction())
               {
                   var result = session.QueryOver<ShareholdersDomain>().Where(x=>x.Id == id).List();
                   return result as List<ShareholdersDomain>;
               }

            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return null;
            }

        }

        public bool Delete(ShareholdersDomain entity)
        {

            try
            {
                Delete<ShareholdersDomain>(entity);
                return true;
                
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return false;
            }

        }

        public List<ViewShareholdersDomain> GetViewShareholderWithCoporationId(int id)
        {
            try
            {
                using(var session = SessionFactory.OpenStatelessSession())
                using(var tx = session.BeginTransaction())
                {
                    var reslut = session.QueryOver<ViewShareholdersDomain>().Where(x => x.CorporationId == id ).List<ViewShareholdersDomain>();
                    return reslut as List<ViewShareholdersDomain>;
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
