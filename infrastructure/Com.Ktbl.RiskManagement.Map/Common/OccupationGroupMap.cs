using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Com.Ktbl.RiskManagement.Domain;

namespace Com.Ktbl.RiskManagement.Map.Common
{
    public class OccupationGroupMap : ClassMap<OccupationGroupDomain>
    {
        public OccupationGroupMap()
        {
            Table("View_OccupationGroup");
            LazyLoad();
            Id(x => x.Id, "Group_ID").GeneratedBy.Assigned();
            References(x => x.OccupationCatelogy).Column("Category_ID");
            HasMany(x => x.OccupationTypes).KeyColumn("Group_ID");
            Map(x => x.Name).Column("Group_Name").Length(200);
            
           
        }
            
    }
}
