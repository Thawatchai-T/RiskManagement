using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Ktbl.RiskManagement.Domain.Common;

namespace Com.Ktbl.RiskManagement.Map.Repository
{
    public interface ICountryRepository
    {
        bool Insert(CountryDomain entity);
        bool Update(CountryDomain entity);
        List<CountryDomain> GetAll();
        bool Delete(CountryDomain entity);

        bool CheckCountry(int id);
    }
    public class CountryRepository : NhRepository, ICountryRepository
    {
        public bool Insert(CountryDomain entity)
        {

            try
            {
                Insert<CountryDomain>(entity);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return false;
            }

        }

        public bool Update(CountryDomain entity)
        {

            try
            {
                Update<CountryDomain>(entity);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return false;
            }

        }

        public List<CountryDomain> GetAll()
        {
            try
            {
                var result = this.ExecuteICriteria<CountryDomain>().ToList<CountryDomain>();
                return result as List<CountryDomain>;

            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return null;
            }
        }

        public bool Delete(CountryDomain entity)
        {

            try
            {
                Delete<CountryDomain>(entity);
                return true;

            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return false;
            }

        }

        public bool CheckCountry(int id){

            using(var session = SessionFactory.OpenStatelessSession())
            {
                var result = session.QueryOver<CountryDomain>().Where(x=>x.Id == id && x.IsActive == true && x.Levels>0).List<CountryDomain>();

                return result.Count > 0 ? true : false;

            }

        }


    }
}
