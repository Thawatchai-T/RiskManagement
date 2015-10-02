//using Com.Ktbl.RiskManagement.Map.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Com.Ktbl.RiskManagement.Domain;
using System.Collections.Generic;
using NHibernate.Cfg;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Context;
using NHibernate.Tool.hbm2ddl;
using System.IO;
using Com.Ktbl.RiskManagement.Map.Repository;
using HibernatingRhinos.Profiler.Appender.NHibernate;
using NHibernate;
using Com.Ktbl.RiskManagement.Map.Common;

namespace TestProject
{
    
    
    /// <summary>creawte
    ///This is a test class for PersonalRepositoryTest and is intended
    ///to contain all PersonalRepositoryTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PersonalRepositoryTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for PersonalRepository Constructor
        ///</summary>
        [TestMethod()]
        public void PersonalRepositoryConstructorTest()
        {
            PersonalRepository target = new PersonalRepository();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Delete
        ///</summary>
        [TestMethod()]
        public void DeleteTest()
        {
            PersonalRepository target = new PersonalRepository(); // TODO: Initialize to an appropriate value
            PersonalModel entity = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.Delete(entity);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetById
        ///</summary>
        [TestMethod()]
        public void GetByIdTest()
        {
            PersonalRepository target = new PersonalRepository(); // TODO: Initialize to an appropriate value
            int id = 0; // TODO: Initialize to an appropriate value
            List<PersonalModel> expected = null; // TODO: Initialize to an appropriate value
            List<PersonalModel> actual;
            actual = target.GetById(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Insert
        ///</summary>
        [TestMethod()]
        public void InsertTest()
        {
            PersonalRepository target = new PersonalRepository(); // TODO: Initialize to an appropriate value
            PersonalModel entity = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.Insert(entity);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Update
        ///</summary>
        [TestMethod()]
        public void UpdateTest()
        {
            PersonalRepository target = new PersonalRepository(); // TODO: Initialize to an appropriate value
            PersonalModel entity = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.Update(entity);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod]
        public void CreateDb(){

            try
            {
                var session = Utility.CreateSessionFactory();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [TestMethod]
        public void ExportScheme()
        {
            try
            {
                //NHibernateProfiler.Initialize();

                Configuration config = Fluently.Configure()
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
                    .ExposeConfiguration(c => c.SetProperty("current_session_context_class", "thread_static")).
                BuildConfiguration();

                var schemaExport = new SchemaExport(config);
                //schemaExport..Drop(false, true);
                schemaExport.Create(false, true);

                Action<string> updateExport = x =>
                {
                    using (var file = new FileStream("c:/text.text", FileMode.Append))
                    using (var sw = new StreamWriter(file))
                    {
                        sw.Write(x);
                    }
                };
                new SchemaUpdate(config).Execute(updateExport, true);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        [TestMethod]
        public void TestGetCommons(){

            //NHibernateProfiler.Initialize();
            var target = new CommonsRepository();
            target.SessionFactory = this.CreateSessionFactory();
            try
            {
                var result = target.GetCommon();
                Assert.AreEqual(true, result.Count > 0);
            }catch(Exception){
                throw;
            }

        }

        [TestMethod]
        public void TestPoliticianRelationship(){
            var target = new PoliticianRelationshipRepository();
            target.SessionFactory = this.CCICreateSessionFactory();

            var result = target.GetAll();

            Assert.AreEqual(true, result.Count > 0);
        }

        [TestMethod]
        public void TestCCISource()
        {
            var target = new CCISourceRepository();
            target.SessionFactory = this.CCICreateSessionFactory();
            var result = target.GetAll();
            Assert.AreEqual(true, result.Count > 0);
        }


        [TestMethod]
        public void TestCatelogy(){

            HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();
            var target = new OccupationRepository();
            target.SessionFactory = this.NHPCreateSessionFactory();
            
            var result = target.GetOccupationCatelogy();
           
            var group = target.GetOccupationGroup();
         
            var type = target.GetOccupationType();
            
            Assert.AreEqual(true, result.Count>0);
        }

        private ISessionFactory CreateSessionFactory()
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


        public ISessionFactory CCICreateSessionFactory()
        {
            try
            {
                var config = Fluently.Configure()
                    //.ProxyFactoryFactory<NHibernate.Bytecode.IProxyFactoryFactory>()
                    .Database(MsSqlConfiguration.MsSql2008
                        .ConnectionString(c => c
                            .Server("221.23.4.64")
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

        public ISessionFactory NHPCreateSessionFactory()
        {
            try
            {
                var config = Fluently.Configure()
                    //.ProxyFactoryFactory<NHibernate.Bytecode.IProxyFactoryFactory>()
                    .Database(MsSqlConfiguration.MsSql2008
                        .ConnectionString(c => c
                            .Server("221.23.4.64")
                            .Database("NHP_DEV")
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
    }
}
