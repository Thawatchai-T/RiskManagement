using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Ktbl.RiskManagement.Process
{
    public class Entitys
    {
        public virtual int ProductID { get; set; }
        public virtual string ProductName { get; set; }
        public virtual int SupplierID { get; set; }
        public virtual string CategoryID { get; set; }
        public virtual string QuantityPerUnit { get; set; }
        public virtual string UnitPrice { get; set; }
        public virtual int UnitsInStock { get; set; }
        public virtual string UnitsOnOrder { get; set; }
        public virtual int ReorderLevel { get; set; }
        public virtual string Discontinued { get; set; }
    }
}
