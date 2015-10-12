using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Ktbl.RiskManagement.Domain;
using Com.Ktbl.RiskManagement.Domain.Common;

namespace Com.Ktbl.RiskManagement.Map.Repository
{
    public interface IBatchTBRepository
    {
        List<BatchTBViewModel> GetResultPosanal();
    }
    public class BatchTBRepository : NhRepository, IBatchTBRepository
    {
        public List<BatchTBViewModel> GetResultPosanal()
        {
            List<BatchTBViewModel> list = new List<BatchTBViewModel>();

            using(var session = SessionFactory.OpenSession())
            using(var tx = session.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted))
            {
                var result = session.QueryOver<BatchtbDomain>().Select(x=>new BatchTBViewModel{
                    Agrcode = x.Agrcode,
                    Cuscode = x.Cuscode,
                    Cusname = x.Cusname
                }).List<BatchTBViewModel>();

                var stdc = session.QueryOver<StandardCodeDomain>().Where(x=>x.Active == true).List<StandardCodeDomain>();

                if(!result.Equals(null) && result.Count() >0){

                    list = (from x in result
                                  join y in stdc on x.TitleTH equals y.StandardName
                                  select new BatchTBViewModel
                                  {
                                      Agrcode = x.Agrcode,
                                      Cuscode = x.Cuscode,
                                      Cusname = x.Cusname,
                                      StandardCode = y.StandardCode,
                                      StandardType = y.StandardType,
                                      TitleTH = x.TitleTH
                                  }).ToList<BatchTBViewModel>();

                }

                return list;
            }
        }
    }
}
