using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Ktbl.RiskManagement.Domain
{
    public class TypeOfRisks
    {
        public int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual string CreateBy { get; set; }
        public virtual string UpdateBy { get; set; }
        public virtual DateTime CreateDate { get; set; }
        public virtual DateTime UpdateDate { get; set; }

    }
}
