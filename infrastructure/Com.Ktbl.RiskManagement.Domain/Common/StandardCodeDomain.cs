using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Ktbl.RiskManagement.Domain.Common
{
    public class StandardCodeDomain
    {
        public virtual string StandardType { get; set; }
        public virtual string StandardCode { get; set; }
        public virtual string StandardName { get; set; }
        public virtual string Attribute1 { get; set; }
        public virtual string Attribute2 { get; set; }
        public virtual string Attribute3 { get; set; }
        public virtual string Attribute4 { get; set; }
        public virtual string Attribute5 { get; set; }
        public virtual DateTime? CreateDate { get; set; }
        public virtual string CreateUser { get; set; }
        public virtual DateTime? ModifyDate { get; set; }
        public virtual string ModifyUser { get; set; }
        public virtual bool? Active { get; set; }
        public virtual string Attribute6 { get; set; }
        #region NHibernate Composite Key Requirements
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var t = obj as StandardCodeDomain;
            if (t == null) return false;
            if (StandardType == t.StandardType
             && StandardCode == t.StandardCode)
                return true;

            return false;
        }
        public override int GetHashCode()
        {
            int hash = GetType().GetHashCode();
            hash = (hash * 397) ^ StandardType.GetHashCode();
            hash = (hash * 397) ^ StandardCode.GetHashCode();

            return hash;
        }
        #endregion
    }
}