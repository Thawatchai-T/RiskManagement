using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Ktbl.RiskManagement.Domain;
using FluentNHibernate.Mapping;

namespace Com.Ktbl.RiskManagement.Map
{
    public class ViewShareholderMap : ClassMap<ViewShareholdersDomain>
    {

        public ViewShareholderMap()
        {
            Table("View_Shareholder");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Identity().Column("ID");
            Map(x => x.CorporationId).Column("CorporationId").Precision(10);
            Map(x => x.CitizenId).Column("CitizenId").Length(50);
            Map(x => x.CommitteeType).Column("CommitteeType").Precision(10);
            Map(x => x.CommitteeTypeName).Column("CommitteeTypeName").Length(255);
            Map(x => x.BusinessId).Column("BusinessId").Precision(10);
            Map(x => x.BusinessName).Column("BusinessName").Length(255);
            Map(x => x.SourceOfIncome).Column("SourceOfIncome").Precision(10);
            Map(x => x.SourceOfIncomeName).Column("SourceOfIncomeName").Length(255);
            Map(x => x.PoliticianRelationship).Column("PoliticianRelationship").Precision(10);
            Map(x => x.PoliticianRelationshipName).Column("PoliticianRelationshipName").Length(255);
            Map(x => x.OccupationTypeId).Column("OccupationTypeId");
        }
    }
}
