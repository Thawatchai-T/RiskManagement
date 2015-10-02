using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Ktbl.RiskManagement.Domain;
using FluentNHibernate.Mapping;

namespace Com.Ktbl.RiskManagement.Map
{
    public class ShareholderMap : ClassMap<ShareholdersDomain> 
    {
        public ShareholderMap()
        {
            Table("Shareholders");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Identity().Column("Id");
            Map(x => x.CorporationId).Column("CorporationId").Precision(10);
            Map(x => x.CommitteeType).Column("CommitteeType").Precision(10);
            Map(x => x.CitizenId).Column("CitizenId").Length(50);
            Map(x => x.TitleId).Column("TitleId").Precision(10);
            Map(x => x.FirstName).Column("FirstName").Length(75);
            Map(x => x.LastName).Column("LastName").Length(75);
            Map(x => x.OccupationCategoryId).Column("OccupationCategoryId").Length(50);
            Map(x => x.OccupationGroupId).Column("OccupationGroupId").Length(50);
            Map(x => x.OccupationTypeId).Column("OccupationTypeId").Length(50);
            Map(x => x.PositionId).Column("PositionId").Length(50);
            Map(x => x.BusinessId).Column("BusinessId").Precision(10);
            Map(x => x.SourceOfIncome).Column("SourceOfIncome").Precision(10);
            Map(x => x.LocationOfIncome).Column("LocationOfIncome").Precision(10);
            Map(x => x.LiveInCountry).Column("LiveInCountry").Precision(10);
            Map(x => x.PoliticianRelationship).Column("PoliticianRelationship").Precision(10);
            Map(x => x.PathFile).Column("PathFile").Length(50);
            Map(x => x.PathFile1).Column("PathFile1").Length(50);
            Map(x => x.Result).Column("result").Length(50);
            Map(x => x.CreateBy).Column("CreateBy").Length(75);
            Map(x => x.CreateDate).Column("CreateDate");
            Map(x => x.UpdateBy).Column("UpdateBy").Length(75);
            Map(x => x.UpdateDate).Column("UpdateDate");
            Map(x => x.IsActive).Column("IsActive");
        }
    }
}
