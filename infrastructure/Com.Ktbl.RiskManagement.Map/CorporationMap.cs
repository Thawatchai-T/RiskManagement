using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Com.Ktbl.RiskManagement.Domain;

namespace Com.Ktbl.RiskManagement.Map
{
    public class CorporationMap : ClassMap<CorporationDomain>
    {
        public CorporationMap()
        {
            Table("Corporation");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Identity().Column("Id");
            Map(x => x.Nationality).Column("Nationality").Length(50);
            Map(x => x.IsRegistrationThai).Column("IsRegistrationThai").Length(50);
            Map(x => x.RegistrationId).Column("RegistrationId").Length(50);
            Map(x => x.RegistrationType).Column("RegistrationType").Precision(10);
            Map(x => x.CompanyName).Column("CompanyName").Length(150);
            Map(x => x.OccupationCategoryId).Column("OccupationCategoryId").Length(50);
            Map(x => x.OccupationGroupId).Column("OccupationGroupId").Length(50);
            Map(x => x.OccupationTypeId).Column("OccupationTypeId").Length(50);
            Map(x => x.PositionId).Column("PositionId").Length(50);
            Map(x => x.BusinessId).Column("BusinessId").Precision(10);
            Map(x => x.SourceOfIncome).Column("SourceOfIncome").Precision(10);
            Map(x => x.LocationOfIncome).Column("LocationOfIncome").Precision(10);
            Map(x => x.LiveInCountry).Column("LiveInCountry").Precision(10);
            Map(x => x.PoliticianRelationship).Column("PoliticianRelationship").Precision(10);
            Map(x => x.PathFile).Column("PathFile").Length(150);
            Map(x => x.PathFile1).Column("PathFile1").Length(150);
            Map(x => x.Result).Column("Result").Length(50);
            Map(x => x.IsActive).Column("IsActive");
            Map(x => x.CreateBy).Column("CreateBy").Length(75);
            Map(x => x.UpdateBy).Column("UpdateBy").Length(75);
            Map(x => x.CreateDate).Column("CreateDate");
            Map(x => x.UpdateDate).Column("UpdateDate");
        }
    }
}
