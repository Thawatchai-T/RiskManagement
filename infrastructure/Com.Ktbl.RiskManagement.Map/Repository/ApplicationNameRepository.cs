using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Ktbl.RiskManagement.Domain;
using Com.Ktbl.RiskManagement.Domain.Common;
using Com.Ktbl.RiskManagement.Map.Helpers;

namespace Com.Ktbl.RiskManagement.Map.Repository
{

    public interface IApplicationNameRepository
    {
        bool Insert(ApplicationNameDomain entity);
        bool Update(ApplicationNameDomain entity);
        bool CheckAppName(string appname);
        string GetAppNameWithKey(string key);
        string GetKeyWithAppName(string appname);
        bool CheckKey(string key);
    }

    public class ApplicationNameRepository : NhRepository, IApplicationNameRepository
    {
        public bool Insert(ApplicationNameDomain entity){

            try
            {
                entity.UpdateDate = DateTime.Now;
                entity.CraeteDate = DateTime.Now;
                entity.AppKey = NHelper.ToMD5(entity.AppName).Replace("-",string.Empty);
                Insert<ApplicationNameDomain>(entity);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return false;
            }

        }

        public bool Update(ApplicationNameDomain entity)
        {

            try
            {
                Update<ApplicationNameDomain>(entity);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return false;
            }

        }

        public bool CheckAppName(string appname){

            try
            {
                using(var session =SessionFactory.OpenStatelessSession())
                using(var tx = session.BeginTransaction())
                {
                    var reslut = session.QueryOver<ApplicationNameDomain>().Where(x => x.AppName == NHelper.ToMD5(appname)).List<ApplicationNameDomain>();
                    return (reslut.Count > 0) ? true : false;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                throw;
            }
        }

        public string GetAppNameWithKey(string key)
        {
            try
            {
                using (var session = SessionFactory.OpenStatelessSession())
                using (var tx = session.BeginTransaction())
                {
                    
                    var reslut = session.QueryOver<ApplicationNameDomain>().Where(x => x.AppKey == key).List<ApplicationNameDomain>().FirstOrDefault();
                    return (reslut ==null)?"App name not found.":reslut.AppName;

                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                throw;
            }
        }

        public string GetKeyWithAppName(string appname)
        {
            try
            {
                using (var session = SessionFactory.OpenStatelessSession())
                using (var tx = session.BeginTransaction())
                {
                    var reslut = session.QueryOver<ApplicationNameDomain>().Where(x => x.AppName == appname).List<ApplicationNameDomain>().FirstOrDefault();
                    return (reslut == null) ? "App name not found." : reslut.AppKey;

                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                throw;
            }
        }

        public bool CheckKey(string key){

            try
            {
                using(var session = SessionFactory.OpenStatelessSession())
                using(var tx = session.BeginTransaction())
                {
                    var result = session.Get<ApplicationNameDomain>(key);
                    return (!string.IsNullOrEmpty(result.AppKey)) ? true : false;
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
