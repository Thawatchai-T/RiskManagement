using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Ktbl.RiskManagement.Domain;
using FluentNHibernate.Mapping;

namespace Com.Ktbl.RiskManagement.Map
{
    class BatchRiskMap: ClassMap<BatchRiskDomain> {

        public BatchRiskMap()
        {
            Table("BatchRisk");
            LazyLoad();
            //Id(x => x.Id).GeneratedBy.Identity().Column("Id");
            Id(x => x.CId, "CID").GeneratedBy.Assigned();
            //Map(x => x.CId).Column("CID").Length(100);
            Map(x => x.OccupationCatelogy).Column("OccupationCatelogy").Length(75);
            Map(x => x.OccupationGroup).Column("OccupationGroup").Length(75);
            Map(x => x.OccupationType).Column("OccupationType").Length(75);
            Map(x => x.Position).Column("Position").Length(75);
            Map(x => x.BusinessType).Column("BusinessType").Length(75);
            Map(x => x.UpdateDate).Column("UpdateDate").Not.Nullable();
            Map(x => x.UpdateBy).Column("UpdateBy").Length(100);
            Map(x => x.CreateDate).Column("CreateDate");
            Map(x => x.CreateBy).Column("CreateBy").Length(100);
            Map(x => x.RefFile).Column("RefFile").Length(100);
        }
    }
}
