using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        //List<PersonalModel> ChaeckTypeR2();

    }
    public class PersonalRepository : NhRepository, IPersonalRepository
    {
        public bool Insert(PersonalModel entity){

            try
            {
                entity.CreateBy = entity.UserId;
                entity.CreateDate = DateTime.Now;
                entity.UpdateBy = entity.UserId;
                entity.UpdateDate = DateTime.Now;
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

        private void SqlCopy(){
            //using (CsvDataReader csvData = new CsvDataReader(new StreamReader(fileUpload.PostedFile.InputStream, true)))
            //{
            //    using (var session = SessionFactory.OpenSession())
            //    using (var transaction = session.BeginTransaction())
            //    {
            //        using (var cmd = new SqlCommand())
            //        {
            //            transaction.Enlist(cmd);

            //            using (var bulk = new SqlBulkCopy((SqlConnection)session.Connection,
            //                                         SqlBulkCopyOptions.CheckConstraints | SqlBulkCopyOptions.FireTriggers,
            //                                         (SqlTransaction)cmd.Transaction))
            //            {
            //                bulk.DestinationTableName = "Table";
            //                bulk.WriteToServerAsync(csvdata);
            //            }
            //        }


            //        transaction.Commit();
            //    }
            //}
        }


        //public List<PersonalModel> ChaeckTypeR2(){
        //
        //    //using(var session = SessionFactory.OpenStatelessSession())
        //    //using(var tx = session.BeginTransaction())
        //    //{
        //    //    try
        //    //    {
        //    //        var datan = DateTime.Now;
        //    //        var result = session.QueryOver<PersonalModel>().Where(x => (x.Result == "R2"
        //    //                && (datan.Subtract(x.UpdateDate).Days / (365.25 / 12) <= 24)
        //    //            ).List<PersonalModel>();                        
        //    //            
        //    //        return result as List<PersonalModel>;
        //    //    }
        //    //    catch (Exception ex)
        //    //    {
        //    //        Logger.Error(ex.Message);
        //    //        throw;
        //    //    }
        //    //}
        //
        //}
    }
}
