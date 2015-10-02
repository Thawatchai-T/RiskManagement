using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Ktbl.RiskManagement.Domain
{
    public class OccupationGroupDomain //: CommonDomain
    {
        public OccupationGroupDomain(){
            this.OccupationCatelogy = new OccupationCatelogyDomain();
            OccupationTypes = new List<OccupationTypeDomain>();
        }

        public virtual string Id { get; set; }
        public virtual string Name { get; set; }
        public virtual OccupationCatelogyDomain OccupationCatelogy { get; set; }

        public virtual IList<OccupationTypeDomain> OccupationTypes { get; set; }

    }
}
