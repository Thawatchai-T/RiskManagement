using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Com.Ktbl.RiskManagement.Map.Repository;
using Com.Ktbl.RiskManagement.Domain;

namespace TestProject
{
    [TestClass()]
    public class InitData
    {
        // Fields...
        private NhRepository _NhRepository;

        public NhRepository NhRepository
        {
            get { return _NhRepository; }
            set
            {
                _NhRepository = value;
            }
        }
        
        //[TestMethod]
        //public void OccupationCatelogy(){

        //    NhRepository = new NhRepository();
        //    NhRepository.SessionFactory = Utility.CreateSessionFactory();
        //    var obj = new List<OccupationGroupDomain>();
        //    obj.Add(new OccupationGroupDomain{
        //            IsActive = true,
        //            CreateBy = "moji",
        //            CreateDate = DateTime.Now,
        //            OccupationCatelogy = new OccupationCatelogyDomain{Id=1}
        //        });

        //    var enity = new OccupationCatelogyDomain
        //    {
        //        Id = 1,
        //        Name = "Testcast",
        //        OccupationGroups = obj,
        //        //CreateBy = "moji",
        //        //CreateDate = DateTime.Now,
        //        //UpdateBy = "moji",
        //        //UpdateDate = DateTime.Now,
        //        //IsActive = true
        //    };
        //    
        //    try
        //    {
        //        NhRepository.Insert<OccupationCatelogyDomain>(enity);
        //        NhRepository.Insert<OccupationGroupDomain>(
        //            new OccupationGroupDomain
        //            {
        //                Name = "Testgroup",
        //                OccupationCatelogy =new OccupationCatelogyDomain{Id=1},
        //                CreateBy = "moji",
        //                CreateDate = DateTime.Now,
        //                UpdateBy = "moji",
        //                UpdateDate = DateTime.Now,
        //                IsActive = true
        //            }
        //            );

        //        var list = NhRepository.CreateCriteria<OccupationCatelogyDomain>();
        //        var a = list.List();

        //    }
        //    catch (Exception)
        //    {
        //        
        //        throw;
        //    }
        //}
    }
}
