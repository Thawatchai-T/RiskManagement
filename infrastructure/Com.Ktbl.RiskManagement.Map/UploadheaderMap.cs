using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Ktbl.RiskManagement.Domain;
using FluentNHibernate.Mapping;

namespace Com.Ktbl.RiskManagement.Map
{
    public class UploadheaderMap : ClassMap<UploadHeaderDomain>
    {

        public UploadheaderMap()
        {
            Table("UploadHeader");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Identity().Column("id");
            Map(x => x.FileName).Column("FileName").Length(100);
            Map(x => x.Status).Column("Status").Length(50);
            Map(x => x.Message).Column("Message").Length(255);
            Map(x => x.CreateDate).Column("CreateDate");
            Map(x => x.CreateBy).Column("CreateBy").Length(10);
            Map(x => x.UpdateDate).Column("UpdateDate");
            Map(x => x.UpdateBy).Column("UpdateBy").Length(100);
        }
    }
}
