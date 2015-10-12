using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Ktbl.RiskManagement.Domain;
using Com.Ktbl.RiskManagement.Domain.Common;

namespace Com.Ktbl.RiskManagement.Map.Repository
{
    public interface IBatchFileRepository
    {
        bool SaveOrUpdate(List<BatchRiskDomain> list);
        void InsertHead(UploadHeaderDomain entity);
        void UpdateHeaderUpload(UploadHeaderDomain entity);
        bool Insert(List<StandardCodeDomain> list);
    }
    public class BatchFileRepository : NhRepository, IBatchFileRepository
    {
        public bool SaveOrUpdate(List<BatchRiskDomain> list)
        {
            using(var session = SessionFactory.OpenSession())
            using(var tx = session.BeginTransaction())
            {
                tx.Begin(System.Data.IsolationLevel.ReadCommitted);
                try
                {
                    session.SetBatchSize(list.Count);
                    list.ForEach(x =>
                    {
                        session.SaveOrUpdate(x);
                    });
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

        public void InsertHead(UploadHeaderDomain entity){
            using(var session = SessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                try
                {
                    session.Save(entity);
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    Logger.Error(ex.Message);
                    throw;
                }
                
            }
        }

        public void UpdateHeaderUpload(UploadHeaderDomain entity)
        {
            using(var session = SessionFactory.OpenSession())
            using(var tx = session.BeginTransaction())
            {
                try
                {
                    session.Update(entity);
                }
                catch (Exception)
                {
                    throw;
                }
            }

        }

        public bool Insert(List<StandardCodeDomain> list)
        {
            using (var session = SessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                tx.Begin(System.Data.IsolationLevel.ReadCommitted);
                try
                {
                    session.SetBatchSize(list.Count);
                    list.ForEach(x =>
                    {
                        session.SaveOrUpdate(x);
                    });
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
    }
}
