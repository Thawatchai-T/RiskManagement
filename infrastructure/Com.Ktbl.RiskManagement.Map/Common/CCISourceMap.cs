using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Ktbl.RiskManagement.Domain;
using FluentNHibernate.Mapping;

namespace Com.Ktbl.RiskManagement.Map.Common
{
    public class CCISourceMap : ClassMap<CCISourceDomain>
    {

        public CCISourceMap()
        {
            Table("View_CCISource");
            LazyLoad();
            //Map(x => x.IdValue).Column("ID_VALUE").Not.Nullable().Length(100);
            Id(x => x.Id, "ID_VALUE").GeneratedBy.Assigned();
            Map(x => x.FirstName).Column("FIRST_NAME").Length(200);
            Map(x => x.Surname).Column("SURNAME").Length(200);
            Map(x => x.SingleStringName).Column("SINGLE_STRING_NAME").Length(400);
        }
    }
}
