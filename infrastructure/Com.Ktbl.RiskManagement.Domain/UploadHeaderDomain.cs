using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Ktbl.RiskManagement.Domain
{
    public class UploadHeaderDomain
    {
        public virtual int Id { get; set; }
        public virtual string FileName { get; set; }
        public virtual string Status { get; set; }
        public virtual string Message { get; set; }
        public virtual DateTime CreateDate { get; set; }
        public virtual string CreateBy { get; set; }
        public virtual DateTime UpdateDate { get; set; }
        public virtual string UpdateBy { get; set; }
    }
}
