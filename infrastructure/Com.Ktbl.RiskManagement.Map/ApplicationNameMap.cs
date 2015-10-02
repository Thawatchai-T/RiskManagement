using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Ktbl.RiskManagement.Domain;
using FluentNHibernate.Mapping;

namespace Com.Ktbl.RiskManagement.Map
{
    public class ApplicationNameMap: ClassMap<ApplicationNameDomain>
    {
        public ApplicationNameMap()
        {
            Table("ApplicationName");
            LazyLoad();
            Id(x => x.AppKey, "AppKey").GeneratedBy.Assigned();
            Map(x => x.AppName).Column("AppName");
            Map(x => x.CraeteDate).Column("CraeteDate");
            Map(x => x.UpdateDate).Column("UpdateDate");
            Map(x => x.Active).Column("Active");
        }
    }
}