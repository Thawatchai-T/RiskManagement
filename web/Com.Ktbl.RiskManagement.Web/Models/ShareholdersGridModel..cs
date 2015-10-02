using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Com.Ktbl.RiskManagement.Web.Models
{
    public class ShareholdersGridView
    {
        public int Id { get; set; }
        public int CorporationId { get; set; }
        public int CommitteeType { get; set; }
        public string CommitteeTypeName { get; set; }
        public string IdCard { get; set; }
        public string OccupationTypeName { get; set; }
        public string BusinessType { get; set; }
        public string LocationIncomeName { get; set; }
        public string PoliticianRelationship { get; set; }
    }
}