using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using FluentNHibernate.Cfg;

using FluentNHibernate.Cfg.Db;
using Com.Ktbl.RiskManagement.Domain;
using NHibernate.Context;
using NHibernate.Bytecode;
using Com.Ktbl.RiskManagement.Map.Common;

namespace TestProject
{
    public static class Utility
    {
        public static ISessionFactory CreateSessionFactory()
        {
            try
            {
                var config = Fluently.Configure()
                    //.ProxyFactoryFactory<NHibernate.Bytecode.IProxyFactoryFactory>()
                    .Database(MsSqlConfiguration.MsSql2008
                        .ConnectionString(c => c
                            .Server("localhost")
                            .Database("RiskManagement")
                            .Username("sa")
                            .Password("ktblitadmin")
                        )
                    )
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CommonMap>())
                    .ExposeConfiguration(c => c.SetProperty("current_session_context_class", "thread_static"))
                    .BuildSessionFactory();
                return config;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message); //ex.Message;
                //  return null;
            }
        }

        public static ISessionFactory CCICreateSessionFactory()
        {
            try
            {
                var config = Fluently.Configure()
                    //.ProxyFactoryFactory<NHibernate.Bytecode.IProxyFactoryFactory>()
                    .Database(MsSqlConfiguration.MsSql2008
                        .ConnectionString(c => c
                            .Server("221.23.4.78")
                            .Database("KTBLCCI")
                            .Username("sa")
                            .Password("ktblitadmin")
                        )
                    )
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CommonMap>())
                    .ExposeConfiguration(c => c.SetProperty("current_session_context_class", "thread_static"))
                    .BuildSessionFactory();
                return config;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message); //ex.Message;
                //  return null;
            }
        }


        //public static ISessionFactory CCICreateSessionFactory()
        //{
        //    try
        //    {
        //        var config = Fluently.Configure()
        //            //.ProxyFactoryFactory<NHibernate.Bytecode.IProxyFactoryFactory>()
        //            .Database(MsSqlConfiguration.MsSql2008
        //                .ConnectionString(c => c
        //                    .Server("221.23.4.78")
        //                    .Database("KTBLCCI")
        //                    .Username("sa")
        //                    .Password("ktblitadmin")
        //                )
        //            )
        //            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CommonMap>())
        //            .ExposeConfiguration(c => c.SetProperty("current_session_context_class", "thread_static"))
        //            .BuildSessionFactory();
        //        return config;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message); //ex.Message;
        //        //  return null;
        //    }
        //}
    }
}
