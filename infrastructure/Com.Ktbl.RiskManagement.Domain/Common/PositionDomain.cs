using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Ktbl.RiskManagement.Domain
{
    public class PositionDomain //: CommonDomain
    {
        public PositionDomain(){
            this.OccupationType = new OccupationTypeDomain();
        }
        public virtual string Id { get; set; }
        public virtual string Name { get; set; }
        public virtual OccupationTypeDomain OccupationType { get; set; }
    }
}
