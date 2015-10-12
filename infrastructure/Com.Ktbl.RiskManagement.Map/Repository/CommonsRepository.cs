using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Ktbl.RiskManagement.Domain;
using Com.Ktbl.RiskManagement.Domain.Common;
using HibernatingRhinos.Profiler.Appender.NHibernate;

namespace Com.Ktbl.RiskManagement.Map.Repository
{

    public interface ICommonsRepository
    {
        List<CommonDomain> GetCommon();
        List<BusinessTypeDomain> GetBusinessType();
        List<RegistrationTypeDomain> GetRegistrationType();

        List<StandardCodeDomain> GetTitleName();

        List<RelationshipDomain> GetRelationship();

        bool CheckRelationship(int id);
        bool CheckBusinessType(int id);
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

        public List<StandardCodeDomain> GetTitleName()
        {

            using (var session = SessionFactory.OpenStatelessSession())
            {
                NHibernateProfiler.Initialize();
                var result = session.QueryOver<StandardCodeDomain>().List<StandardCodeDomain>();
                //var XY = session.CreateSQLQuery("select * from commons").List();

                return result as List<StandardCodeDomain>;
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

        public bool CheckBusinessType(int id)
        {
            using (var session = SessionFactory.OpenStatelessSession())
            using (var tx = session.BeginTransaction())
            {
                try
                {
                    var result = session.QueryOver<BusinessTypeDomain>().Where(x=>x.Id ==id && x.Id !=10 ).List<BusinessTypeDomain>();
                    return (result.Count == 1) ? true : false;
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


        public List<RelationshipDomain> GetRelationship()
        {

            using (var session = SessionFactory.OpenStatelessSession())
            using (var tx = session.BeginTransaction())
            {
                try
                {
                    var result = session.QueryOver<RelationshipDomain>().Where(x => x.Types == "PoliticianRelationship").List<RelationshipDomain>();

                    return result as List<RelationshipDomain>;
//                    return new List<CommonDomain>();

                }
                catch (Exception ex)
                {
                    Logger.Error(ex);
                    throw;
                }
            }

        }


        public bool CheckRelationship(int id){

            using (var session = SessionFactory.OpenStatelessSession())
            using (var tx = session.BeginTransaction())
            {
                try
                {
                    var result = session.QueryOver<RelationshipDomain>().Where(x => x.Types == "PoliticianRelationship" && x.Id != 6 && x.Id == id ).RowCount();

                    // row count == 1 meaning ไม่มีความสัมพันธ์กับนักการเมื่อง
                    return (result == 0)?false:true;
                 
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
