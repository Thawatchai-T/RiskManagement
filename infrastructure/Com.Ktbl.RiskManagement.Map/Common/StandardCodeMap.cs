using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Ktbl.RiskManagement.Domain.Common;
using FluentNHibernate.Mapping;

namespace Com.Ktbl.RiskManagement.Map.Common
{
    public class StandardCodeMap : ClassMap<StandardCodeDomain>
    {

        public StandardCodeMap()
        {
            Table("Standard_Code");
            LazyLoad();
            CompositeId().KeyProperty(x => x.StandardType, "Standard_Type")
                         .KeyProperty(x => x.StandardCode, "Standard_Code");
            Map(x => x.StandardName).Column("Standard_Name").Length(100);
            Map(x => x.Attribute1).Column("Attribute1").Length(50);
            Map(x => x.Attribute2).Column("Attribute2").Length(50);
            Map(x => x.Attribute3).Column("Attribute3").Length(50);
            Map(x => x.Attribute4).Column("Attribute4").Length(50);
            Map(x => x.Attribute5).Column("Attribute5").Length(50);
            Map(x => x.CreateDate).Column("Create_Date");
            Map(x => x.CreateUser).Column("Create_User").Length(10);
            Map(x => x.ModifyDate).Column("Modify_Date");
            Map(x => x.ModifyUser).Column("Modify_User").Length(10);
            Map(x => x.Active).Column("Active");
            Map(x => x.Attribute6).Column("Attribute6").Length(10);
        }
    }
}
