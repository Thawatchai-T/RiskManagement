using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Ktbl.RiskManagement.Domain
{
    public class BatchRiskDomain
    {
        public virtual int Id { get; set; }
        public virtual string CId { get; set; }
        public virtual string OccupationCatelogy { get; set; }
        public virtual string OccupationGroup { get; set; }
        public virtual string OccupationType { get; set; }
        public virtual string Position { get; set; }
        public virtual string BusinessType { get; set; }
        public virtual DateTime UpdateDate { get; set; }
        public virtual string UpdateBy { get; set; }
        public virtual DateTime? CreateDate { get; set; }
        public virtual string CreateBy { get; set; }
        public virtual string RefFile { get; set; }
    }
}
