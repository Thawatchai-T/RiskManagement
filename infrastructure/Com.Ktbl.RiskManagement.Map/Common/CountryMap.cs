using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Ktbl.RiskManagement.Domain.Common;
using FluentNHibernate.Mapping;

namespace Com.Ktbl.RiskManagement.Map.Common
{
    public class CountryMap : ClassMap<CountryDomain>
    {
        public CountryMap(){
            Table("Country");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Identity().Column("Id");
            Map(x => x.NameTH).Column("Name_Th").Length(100);
            Map(x => x.NameENG).Column("Name_Eng").Length(100);
            Map(x => x.IsActive).Column("Active");
            Map(x => x.Levels).Column("Levels").Precision(10);
        }

    }
}
