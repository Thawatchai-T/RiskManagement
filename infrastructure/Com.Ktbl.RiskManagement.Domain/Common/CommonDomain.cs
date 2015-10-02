using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Ktbl.RiskManagement.Domain
{
    public class CommonDomain
    {
        private DateTime _UpdateDate;
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual bool IsActive { get; set; }
        public virtual string CreateBy { get; set; }
        public virtual string UpdateBy { get; set; }
        public virtual DateTime CreateDate { get; set; }
        public virtual DateTime UpdateDate {
            get { return _UpdateDate; }
            set{
                _UpdateDate = DateTime.Now;    
            } 
        }

        
        //private DateTime _CreateDate;
        //public virtual DateTime UpdateDate
        //{
        //    get
        //    {
        //        return this._CreateDate;
        //    }

        //    set
        //    {
        //        this._CreateDate = DateTime.Now;
        //    }
        //}
    }
}
