using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Ktbl.RiskManagement.Domain
{
    public class ApplicationNameDomain
    {
        
        public virtual string AppName { get; set; }
        public virtual string AppKey { get; set; }
        public virtual DateTime CraeteDate { get; set; }
        public virtual DateTime UpdateDate
        {
            get;
            set;
        }
        public virtual bool Active { get; set; }
        
    }
}
