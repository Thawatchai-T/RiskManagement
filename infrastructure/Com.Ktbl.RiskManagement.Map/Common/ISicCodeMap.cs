﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Com.Ktbl.RiskManagement.Domain;

namespace Com.Ktbl.RiskManagement.Map.Common
{
    public class ISicCodeMap : ClassMap<ISicCodeDomain>
    {
        public ISicCodeMap()
        {
            Table("ISicCode");
            LazyLoad();
            Id(x => x.Id, "ID").GeneratedBy.Increment();
            Map(x => x.Name).Column("Name");
            Map(x => x.IsActive).Column("IsActive");
            Map(x => x.CreateBy).Column("CreateBy");
            Map(x => x.CreateDate).Column("CreateDate");
            Map(x => x.UpdateBy).Column("UpdateBy");
            Map(x => x.UpdateDate).Column("UpdateDate");
        }
            
    }
}
