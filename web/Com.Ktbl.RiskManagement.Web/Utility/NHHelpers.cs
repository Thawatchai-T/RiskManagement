using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Com.Ktbl.RiskManagement.Map.Common;

namespace Com.Ktbl.RiskManagement.Web.Utility
{
    public class NHHelpers
    {
        private string Server { get; set; }
        private string ServerRisk { get; set; }
        private string ServerCCI { get; set; }
        private int Port { get; set; }
        private string Username { get; set; }
        private string Password { get; set; }
        
        private string Instance { get; set; }

        private string Database { get; set; }
        private string DatabaseCCI { get; set; }
        private string DatabaseRISK { get; set; }
 
        public ISessionFactory CreateSessionFactory()
        {
            try
            {
                var sessionf = Fluently.Configure()
                    //.ProxyFactoryFactory<ProxyFactoryFactory>()
                    .Database(MsSqlConfiguration.MsSql2008
                        .ConnectionString(c => c
                            .Server(Server)
                            .Database(Database)
                            .Username(Username)
                            .Password(Password)
                        )
                    )
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CommonMap>())
                    .ExposeConfiguration(c => c.SetProperty("current_session_context_class", "thread_static"))
                    .BuildSessionFactory();
                return sessionf;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message); //ex.Message;
                //  return null;
            }
        }

        public ISessionFactory CreateSessionFactoryCCI()
        {
            try
            {
                var sessionf = Fluently.Configure()
                    //.ProxyFactoryFactory<ProxyFactoryFactory>()
                    .Database(MsSqlConfiguration.MsSql2008
                        .ConnectionString(c => c
                            .Server(ServerCCI)
                            .Database(DatabaseCCI)
                            .Username(Username)
                            .Password(Password)
                        )
                    )
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CommonMap>())
                    .ExposeConfiguration(c => c.SetProperty("current_session_context_class", "thread_static"))
                    .BuildSessionFactory();
                return sessionf;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message); //ex.Message;
                //  return null;
            }
        }

        public ISessionFactory CreateSessionFactoryRisk()
        {
            try
            {
                var sessionf = Fluently.Configure()
                    //.ProxyFactoryFactory<ProxyFactoryFactory>()
                    .Database(MsSqlConfiguration.MsSql2008
                        .ConnectionString(c => c
                            .Server(ServerRisk)
                            .Database(DatabaseRISK)
                            .Username(Username)
                            .Password(Password)
                        )
                    )
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CommonMap>())
                    .ExposeConfiguration(c => c.SetProperty("current_session_context_class", "thread_static"))
                    .BuildSessionFactory();
                return sessionf;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message); //ex.Message;
                //  return null;
            }
        }
    }
}