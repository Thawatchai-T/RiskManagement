using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Ktbl.RiskManagement.Domain;

namespace Com.Ktbl.RiskManagement.Map.Repository
{
    public interface IOccupationRepository
    {
        List<OccupationCatelogyDomain> GetOccupationCatelogy();
        List<OccupationGroupDomain> GetOccupationGroup();
        List<OccupationTypeDomain> GetOccupationType();
    }

    public class OccupationRepository : NhRepository, IOccupationRepository
    {
        public List<OccupationCatelogyDomain> GetOccupationCatelogy(){
            try
            {
                using( var session = SessionFactory.OpenStatelessSession())
                using(var tx = session.BeginTransaction())
                {
                    var result = session.CreateCriteria<OccupationCatelogyDomain>();
                    
                    return result.List<OccupationCatelogyDomain>() as List<OccupationCatelogyDomain>;
                }

            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return null;
            }
        }

        public List<OccupationGroupDomain> GetOccupationGroup()
        {
            try
            {
                using (var session = SessionFactory.OpenStatelessSession())
                using (var tx = session.BeginTransaction())
                {
                    var result = session.CreateCriteria<OccupationGroupDomain>();

                    return result.List<OccupationGroupDomain>() as List<OccupationGroupDomain>;
                }

            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return null;
            }
        }


        public List<OccupationTypeDomain> GetOccupationType()
        {
            try
            {
                using (var session = SessionFactory.OpenStatelessSession())
                using (var tx = session.BeginTransaction())
                {
                    //var result = session.CreateCriteria<OccupationTypeDomain>();
                    var result = session.QueryOver<OccupationTypeDomain>().List<OccupationTypeDomain>();

                    return result as List<OccupationTypeDomain>;
                }

            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return null;
            }
        }
    }
}
