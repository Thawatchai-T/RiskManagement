/**
 *   Ref: http://ayende.com/blog/4023/nhibernate-queries-examples
 *   Examples 
     Execut CreateCriteria
 *****************************************************************************************************    
 *    var blogs = s.CreateCriteria<Blog>()
 *   .Add(Restrictions.Eq("Title","Ayende @ Rahien"))
 *   .Add(Restrictions.Eq("Subtitle", "Send me a patch for that"))
 *   .List<Blog>();
 *****************************************************************************************************  
 *   Join========
 *   ProjectionList projectionList = Projections.ProjectionList();
 *   projectionList.Add(Projections.Property("EmployeeID"), "Id");
 *   projectionList.Add(Projections.Property("EmployeePosition"), "Label");
 *   var x = DetachedCriteria.For(Employee);
 *   x.SetProjection(projectionList);
 *   x.SetResultTransformer(Transformers.AliasToBean(SimpleType)));
 *   return x.GetExecutableCriteria(UnitOfWork.CurrentSession).List<SimpleType>();
 *****************************************************************************************************
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.AdoNet.Util;
using NHibernate.Criterion;
using log4net;
using System.Reflection;

namespace Com.Ktbl.RiskManagement.Map.Repository
{
    public class 
        NhRepository : IDisposable
    {
        public static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
        }
        ~NhRepository()
        {
            Dispose(false);
        }

        public NhRepository()
        {
            
        }

        private ISessionFactory _sessionFactory = null;
        public static string NHibernateGeneratedSQL { get; set; }
        public static int QueryCounter { get; set; }
        public static string FormatSQL()
        {
            BasicFormatter formatter = new BasicFormatter();
            return formatter.Format(NHibernateGeneratedSQL.ToUpper());
        }

        public ISessionFactory SessionFactory
        {
            protected get { return _sessionFactory; }
            set { _sessionFactory = value; }
        }

        public IList<T> ExecuteICriteria<T>()
        {
            //using (ITransaction transaction = Session.BeginTransaction())
            using (var Session = SessionFactory.OpenStatelessSession())
            using (var tx = Session.BeginTransaction())
            {
                try
                {
                    IList<T> result = Session.CreateCriteria(typeof(T)).List<T>();
                    return result;
                }
                catch (Exception ex)
                {
                    Logger.Error(ex);
                    throw;
                }
            }
        }


        public ICriteria CreateCriteria<T>()
        {
            //using (ITransaction transaction = Session.BeginTransaction())
            using (var Session = SessionFactory.OpenStatelessSession())
            {
                try
                {
                    var result = Session.CreateCriteria(typeof(T));
                    var list = result.List<T>();
                    return result;
                }
                catch (Exception ex)
                {
                    Logger.Error(ex);
                    return null;
                }
            }
        }

        public void Update<T>(T enity)
        {
            using (var Session = SessionFactory.OpenStatelessSession())
            using (var tran = Session.BeginTransaction())
            {
                
                try
                {
                    Session.Update(enity);
                    tran.Commit();
                }
                catch (Exception executeICriteria)
                {
                    tran.Rollback();
                    Logger.Error(executeICriteria);
                    throw executeICriteria;

                }
            }
        }

        public object Insert<T>(T entity)
        {
            using (var Session = SessionFactory.OpenStatelessSession())
            using (var tran = Session.BeginTransaction())
            {
                try
                {
                    var obj = Session.Insert(entity);
                    tran.Commit();
                    return obj;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Logger.Error(ex);
                    throw;
                }
            }
        }

        public void SaveOrUpdate<T>(T entity)
        {
            using (var Session = SessionFactory.OpenSession())
            using (var tran = Session.BeginTransaction())
            {
                try
                {
                    Session.SaveOrUpdate(entity);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Logger.Error(ex);
                }
                

            }

        }

        public void Delete<T>(T entity)
        {
            using (var Session = SessionFactory.OpenSession())
            using (var ts = Session.BeginTransaction())
            {
                try
                {
                    Session.Delete(entity);
                    ts.Commit();
                }
                catch (Exception ex)
                {
                    ts.Rollback();
                    Logger.Error(ex);
                    throw;
                }
            }
        }

        public IList<T> ExecuteICriteriaOrderBy<T>(T entity, string orderBy)
        {
            using (var Session = SessionFactory.OpenStatelessSession())
            using (ITransaction transaction = Session.BeginTransaction())
            {
                try
                {
                    IList<T> result = Session.CreateCriteria(typeof(T))
                    .AddOrder(Order.Asc(orderBy))
                    .List<T>();
                    transaction.Commit();
                    return result;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Logger.Error(ex);
                    throw;
                }
            }
        }
    }
}
