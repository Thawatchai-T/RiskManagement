using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Ktbl.RiskManagement.Domain;

namespace Com.Ktbl.RiskManagement.Map.Repository
{
    public interface IPersonalRepository
    {
        bool Insert(PersonalModel entity);
        bool Update(PersonalModel entity);
        List<PersonalModel> GetById(int id);
        bool Delete(PersonalModel entity);
    }
    public class PersonalRepository : NhRepository, IPersonalRepository
    {
        public bool Insert(PersonalModel entity){

            try
            {
                Insert<PersonalModel>(entity);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return false;
            }

        }

        public bool Update(PersonalModel entity)
        {

            try
            {
                Update<PersonalModel>(entity);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return false;
            }

        }

        public List<PersonalModel> GetById(int id)
        {

            try
            {
               using( var session = SessionFactory.OpenStatelessSession())
               using(var tx = session.BeginTransaction())
               {
                   var result = session.QueryOver<PersonalModel>().Where(x=>x.Id == id).List();
                   return result as List<PersonalModel>;
               }

            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return null;
            }

        }

        public bool Delete(PersonalModel entity)
        {

            try
            {
                Delete<PersonalModel>(entity);
                return true;
                
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return false;
            }

        }
    }
}
