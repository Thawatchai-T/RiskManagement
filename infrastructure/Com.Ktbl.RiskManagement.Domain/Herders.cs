using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Ktbl.RiskManagement.Domain
{
    public class Herders
    {
        public virtual string CreateBy { get; set; }
        public virtual string UpdateBy { get; set; }
        public virtual DateTime CreateDate { get; set; }
        private DateTime _CreateDate;
        public virtual DateTime UpdateDate {
            get{
                return this._CreateDate;
            }
            
            set{
                this._CreateDate = DateTime.Now;
            }
        }
       
    }
}
