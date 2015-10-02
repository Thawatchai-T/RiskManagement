using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Ktbl.RiskManagement.Domain.Common
{
    public class CountryDomain
    {
        public virtual int Id { get; set; }
        public virtual string NameTH { get; set; }
        public virtual string NameENG { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual int Levels { get; set; }

    }
}
