using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Ktbl.RiskManagement.Domain;
using HibernatingRhinos.Profiler.Appender.NHibernate;

namespace Com.Ktbl.RiskManagement.Map.Repository
{

    public interface ICommonsRepository
    {
        List<CommonDomain> GetCommon();
        List<BusinessTypeDomain> GetBusinessType();
        List<RegistrationTypeDomain> GetRegistrationType();
    }

    public class CommonsRepository : NhRepository, ICommonsRepository
    {
        public List<CommonDomain> GetCommon(){
            
            using(var session = SessionFactory.OpenStatelessSession())
            {
                NHibernateProfiler.Initialize();
                var result = session.QueryOver<CommonDomain>().List<CommonDomain>();
               //var XY = session.CreateSQLQuery("select * from commons").List();
                
                return result as List<CommonDomain>;
                //return null;
            }
            
        }

        public List<BusinessTypeDomain> GetBusinessType(){
            using(var session = SessionFactory.OpenStatelessSession())
            using(var tx = session.BeginTransaction())
            {
                try
                {
                    var result = session.QueryOver<BusinessTypeDomain>().List<BusinessTypeDomain>();
                    return result as List<BusinessTypeDomain>;
                }
                catch (Exception ex)
                {
                    Logger.Error(ex);
                    throw;
                }
            }
        }

        public List<RegistrationTypeDomain> GetRegistrationType(){

            using (var session = SessionFactory.OpenStatelessSession())
            using (var tx = session.BeginTransaction())
            {
                try
                {
                    var result = session.QueryOver<RegistrationTypeDomain>().List<RegistrationTypeDomain>();
                    return result as List<RegistrationTypeDomain>;
                }
                catch (Exception ex)
                {
                    Logger.Error(ex);
                    throw;
                }
            }
        }

    }
}
