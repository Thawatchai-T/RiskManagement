using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Ktbl.RiskManagement.Domain;
using FluentNHibernate.Mapping;

namespace Com.Ktbl.RiskManagement.Map
{
    public class DecisionTableMap: ClassMap<DecisionTable>
    {
        public DecisionTableMap(){
            Table("DecisionTable");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Identity().Column("ID");
            Map(x => x.PEPs).Column("PEPs");
            Map(x => x.Amlo).Column("Amlo");
            Map(x => x.Country).Column("Country");
            Map(x => x.Occupation).Column("Occupation");
            Map(x => x.Type).Column("Types").Length(10);
            Map(x => x.Result).Column("Result").Length(50);
            Map(x => x.IsActive).Column("IsActive");
            Map(x => x.Level).Column("Levels");
        }
        
    }
}
