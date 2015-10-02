using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Com.Ktbl.RiskManagement.Web.Models
{
    public class ShareholdersModel
    {
        public int Id { get; set; }
        public int CorporationId { get; set; }
        public int CommitteeType { get; set; }
        public string IdCard { get; set; }
        public int TitleName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int OccupationCatelogy { get; set; }
        public int OccupationGroup { get; set; }
        public int OccupationType { get; set; }
        public string Position { get; set; }
        public string BusinessType { get; set; }
        public string SourceOfIncome { get; set; }
        public string LocationIncome { get; set; }
        public string CurrentlyLives { get; set; }
        public string PoliticianRelationship { get; set; }
    }
}