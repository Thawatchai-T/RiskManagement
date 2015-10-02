using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Ktbl.RiskManagement.Domain;

namespace Com.Ktbl.RiskManagement.Map.Repository
{



    public interface IDecisionTableRepository
    {
        bool Insert(DecisionTable entity);
        bool Update(DecisionTable entity);
        List<DecisionTable> GetById(int id);
        bool Delete(DecisionTable entity);
        List<DecisionTable> GetAll();
        string TaskRisk(DecisionTable DecisionEntity);
        void InsertInitData();
        DecisionTable TaskRiskCorporation(DecisionTable DecisionEntity);
    }

    public class DecisionTableRepository : NhRepository, IDecisionTableRepository
    {
        public bool Insert(DecisionTable entity)
        {

            try
            {
                Insert<DecisionTable>(entity);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return false;
            }

        }

        public bool Update(DecisionTable entity)
        {

            try
            {
                Update<DecisionTable>(entity);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return false;
            }

        }

        public List<DecisionTable> GetById(int id)
        {

            try
            {
                using (var session = SessionFactory.OpenStatelessSession())
                using (var tx = session.BeginTransaction())
                {
                    var result = session.QueryOver<DecisionTable>().Where(x => x.Id == id).List();
                    return result as List<DecisionTable>;
                }

            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return null;
            }

        }

        public bool Delete(DecisionTable entity)
        {

            try
            {
                Delete<DecisionTable>(entity);
                return true;

            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return false;
            }

        }

        public List<DecisionTable> GetAll(){
            using( var session = SessionFactory.OpenStatelessSession()){

                var result = session.QueryOver<DecisionTable>().List<DecisionTable>();
                return result as List<DecisionTable>;
            }
       }

        
       public string TaskRisk(DecisionTable DecisionEntity){
       
           using(var session = SessionFactory.OpenStatelessSession())
           {
               var result = session.QueryOver<DecisionTable>().Where(x =>
                    x.Amlo == DecisionEntity.Amlo &&
                    x.PEPs == DecisionEntity.PEPs &&
                    x.Occupation == DecisionEntity.Occupation &&
                    x.Country == DecisionEntity.Country
                   ).List<DecisionTable>().FirstOrDefault<DecisionTable>();

               return result.Result;
           }

       }



        public void InsertInitData()
        {
            #region Init data for app
            List<DecisionTable> dc = new List<DecisionTable>();

            dc.Add(new DecisionTable
            {
                PEPs = false,
                Amlo = true,
                Occupation = true,
                Country = true,
                Result = "R2aoc",
                IsActive = true
            });

            dc.Add(new DecisionTable
            {
                PEPs = false,
                Amlo = true,
                Occupation = true,
                Country = false,
                Result = "R3ao",
                IsActive = true
            });

            dc.Add(new DecisionTable
            {
                PEPs = false,
                Amlo = true,
                Occupation = false,
                Country = true,
                Result = "R3ac",
                IsActive = true
            });

            dc.Add(new DecisionTable
            {
                PEPs = false,
                Amlo = true,
                Occupation = false,
                Country = false,
                Result = "R3a",
                IsActive = true
            });

            dc.Add(new DecisionTable
            {
                PEPs = false,
                Amlo = false,
                Occupation = false,
                Country = false,
                Result = "R1",
                IsActive = true
            });

            dc.Add(new DecisionTable
            {
                PEPs = false,
                Amlo = false,
                Occupation = true,
                Country = true,
                Result = "R2oc",
                IsActive = true
            });

            dc.Add(new DecisionTable
            {
                PEPs = false,
                Amlo = false,
                Occupation = true,
                Country = false,
                Result = "R2o",
                IsActive = true
            });

            dc.Add(new DecisionTable
            {
                PEPs = false,
                Amlo = false,
                Occupation = false,
                Country = true,
                Result = "R2c",
                IsActive = true
            });

            dc.Add(new DecisionTable
            {
                PEPs = true,
                Amlo = true,
                Occupation = true,
                Country = true,
                Result = "R3paoc",
                IsActive = true
            });

            dc.Add(new DecisionTable
            {
                PEPs = true,
                Amlo = true,
                Occupation = true,
                Country = false,
                Result = "P3pao",
                IsActive = true
            });

            dc.Add(new DecisionTable
            {
                PEPs = true,
                Amlo = true,
                Occupation = false,
                Country = true,
                Result = "R3pac",
                IsActive = true
            });

            dc.Add(new DecisionTable
            {
                PEPs = true,
                Amlo = true,
                Occupation = false,
                Country = false,
                Result = "R3pa",
                IsActive = true
            });


            dc.Add(new DecisionTable
            {
                PEPs = true,
                Amlo = false,
                Occupation = true,
                Country = true,
                Result = "R3poc",
                IsActive = true
            });


            dc.Add(new DecisionTable
            {
                PEPs = true,
                Amlo = false,
                Occupation = true,
                Country = false,
                Result = "R3po",
                IsActive = true
            });


            dc.Add(new DecisionTable
            {
                PEPs = true,
                Amlo = false,
                Occupation = false,
                Country = true,
                Result = "R3pc",
                IsActive = true
            });


            dc.Add(new DecisionTable
            {
                PEPs = true,
                Amlo = false,
                Occupation = false,
                Country = false,
                Result = "R3p",
                IsActive = true
            });
            #endregion 

            using (var session = SessionFactory.OpenStatelessSession())
            using (var tx = session.BeginTransaction())
            {
                
                try
                {
                    tx.Begin();
                    foreach (var item in dc)
                    {
                        session.Insert(item);
                    }
                    tx.Commit();
                }
                catch (Exception)
                {
                    tx.Rollback();
                    throw;
                }
            }
    
        }

        public DecisionTable TaskRiskCorporation(DecisionTable DecisionEntity)
        {
        
            using(var session = SessionFactory.OpenSession())
            using(var tx = session.BeginTransaction())
            {
                var result = session.QueryOver<DecisionTable>().Where(x =>
                    x.Amlo == DecisionEntity.Amlo &&
                    x.PEPs == DecisionEntity.PEPs &&
                    x.Occupation == DecisionEntity.Occupation &&
                    x.Country == DecisionEntity.Country
                   ).List<DecisionTable>().FirstOrDefault<DecisionTable>();

                return result;
            }
        }
    }
}
