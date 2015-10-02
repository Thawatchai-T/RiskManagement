using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Ktbl.RiskManagement.Domain;
using Com.Ktbl.RiskManagement.Domain.Common;

namespace Com.Ktbl.RiskManagement.Map.Repository
{
    public interface IPositionRepository
    {
        bool Insert(PositionDomain entity);
        bool Update(PositionDomain entity);
        bool Delete(PositionDomain entity);
        List<PositionDomain> GetAll();
    }

    public class PositionRepository : NhRepository, IPositionRepository
    {
        public bool Insert(PositionDomain entity){

            try
            {
                Insert<PositionDomain>(entity);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return false;
            }

        }

        public bool Update(PositionDomain entity)
        {

            try
            {
                Update<PositionDomain>(entity);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return false;
            }

        }

        public bool Delete(PositionDomain entity)
        {

            try
            {
                Delete<PositionDomain>(entity);
                return true;
                
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return false;
            }

        }

        public List<PositionDomain> GetAll(){
            try
            {
                var result = this.ExecuteICriteria<PositionDomain>();
                return result as List<PositionDomain>;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

    }
}
