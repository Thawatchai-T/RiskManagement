using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Com.Ktbl.RiskManagement.Domain.Common;

namespace Com.Ktbl.RiskManagement.Map.Common
{
    class PoliticianRelationshipMap : ClassMap<PoliticianRelationshipDomain>
    {
        public PoliticianRelationshipMap() {
            Table("View_PoliticianRelationship");
            LazyLoad();
            //Map(x => x.Id).Column("Name_ID").Not.Nullable().Precision(19);
            Id(x => x.Id, "Name_ID").GeneratedBy.Assigned();
            Map(x => x.FirstName).Column("FIRST_NAME").Length(200);
            Map(x => x.Surname).Column("SURNAME").Length(200);
            Map(x => x.SingleStringName).Column("SINGLE_STRING_NAME").Length(400);
        }
    }
}
