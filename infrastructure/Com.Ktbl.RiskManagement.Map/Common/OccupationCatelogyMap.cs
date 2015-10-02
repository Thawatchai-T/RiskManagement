using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Com.Ktbl.RiskManagement.Domain;

namespace Com.Ktbl.RiskManagement.Map.Common
{
    public class OccupationCatelogyMap : ClassMap<OccupationCatelogyDomain>
    {
        public OccupationCatelogyMap()
        {
            Table("View_OccupationCatelogy");
            //LazyLoad();
            Id(x => x.Id, "Category_ID").GeneratedBy.Assigned();
            Map(x => x.Name).Column("Category_Name").Length(200);
            HasMany(x => x.OccupationGroups).KeyColumn("Category_ID").Inverse();

            //Table("OccupationCatelogy");
            //LazyLoad();
            //Id(x => x.Id, "ID").GeneratedBy.Increment();
            //Map(x => x.Name).Column("Name");
            //HasMany(x => x.OccupationGroups).KeyColumn("CategoryId");
            //Map(x => x.IsActive).Column("IsActive");
            //Map(x => x.CreateBy).Column("CreateBy");
            //Map(x => x.CreateDate).Column("CreateDate");
            //Map(x => x.UpdateBy).Column("UpdateBy");
            //Map(x => x.UpdateDate).Column("UpdateDate");

        }
            
    }
}
