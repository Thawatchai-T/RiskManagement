using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Com.Ktbl.RiskManagement.Domain;

namespace Com.Ktbl.RiskManagement.Map
{
    public class CheckRiskR2Map : ClassMap<CheckRiskR2Model>
    {
        public CheckRiskR2Map()
        {
            Table("View_Review_R2");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Identity().Column("ID");
            Map(x => x.BusinessId).Column("BusinessId").Precision(10);
            Map(x => x.CitizenId).Column("CitizenId").Length(50);
            Map(x => x.FirstName).Column("FirstName").Length(75);
            Map(x => x.LastName).Column("LastName").Length(75);
            Map(x => x.OccupationCategoryId).Column("OccupationCategoryId").Length(50);
            Map(x => x.OccupationGroupId).Column("OccupationGroupId").Length(50);
            Map(x => x.OccupationTypeId).Column("OccupationTypeId").Length(50);
            Map(x => x.PositionId).Column("PositionId").Length(50);
            Map(x => x.LiveInCountry).Column("LiveInCountry").Precision(10);
            Map(x => x.LocationOfIncome).Column("LocationOfIncome").Precision(10);
            Map(x => x.PoliticianRelationship).Column("PoliticianRelationship").Precision(10);
            Map(x => x.SourceOfIncome).Column("SourceOfIncome").Precision(10);
            Map(x => x.TitleId).Column("TitleId").Precision(10);
            Map(x => x.PathFile).Column("file1").Length(100);
            Map(x => x.PathFile1).Column("file2").Length(100);
            Map(x => x.RequestNo).Column("RequestNo").Length(100);
            Map(x => x.AppKey).Column("AppId").Length(100);
            Map(x => x.Result).Column("Result").Length(100);
            Map(x => x.CreateBy).Column("CreateBy").Length(100);
            Map(x => x.CreateDate).Column("CreateDate").Length(100);
            Map(x => x.UpdateBy).Column("UpdateBy").Length(100);
            Map(x => x.UpdateDate).Column("UpdateDate").Length(100);
            
            
            
            //Table("PersonalRisks");
            //LazyLoad();
            //Id(x => x.Id, "ID").GeneratedBy.Increment();
            //Map(x => x.BusinessId).Column("BusinessId");
            //Map(x => x.CitizenId).Column("CitizenId");
            //Map(x => x.FirstName).Column("FirstName").Length(75);
            //Map(x => x.LastName).Column("LastName").Length(75);
            //Map(x => x.LiveInCountry).Column("LiveInCountry");
            //Map(x => x.LocationOfIncome).Column("LocationOfIncome");
            //Map(x => x.OccupationCategoryId).Column("OccupationCategoryId");
            //Map(x => x.OccupationGroupId).Column("OccupationGroupId");
            //Map(x => x.OccupationTypeId).Column("OccupationTypeId");
            //Map(x => x.PoliticianRelationship).Column("PoliticianRelationship");
            //Map(x => x.PositionId).Column("PositionId");
            //Map(x => x.SourceOfIncome).Column("SourceOfIncome");
            //Map(x => x.TitleId).Column("TitleId");
            //Map(x => x.PathFile).Column("file1");
            //Map(x => x.PathFile).Column("file2");
        }
    }
}
