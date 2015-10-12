using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Ktbl.RiskManagement.Domain
{
    public class BatchtbDomain
    {
        public virtual string ComId { get; set; }
        public virtual string Agrcode { get; set; }
        public virtual DateTime BatchDd { get; set; }
        public virtual string Cuscode { get; set; }
        public virtual DateTime CreateDt { get; set; }
        public virtual decimal Cost { get; set; }
        public virtual decimal OriAr { get; set; }
        public virtual decimal OsAr { get; set; }
        public virtual decimal OsPr { get; set; }
        public virtual decimal OsPrC { get; set; }
        public virtual decimal UnpaidVat { get; set; }
        public virtual DateTime? LastPaidDd { get; set; }
        public virtual decimal InstPaid { get; set; }
        public virtual decimal Install { get; set; }
        public virtual decimal InstVat { get; set; }
        public virtual decimal Penalty { get; set; }
        public virtual int LateMax { get; set; }
        public virtual short OdueFm { get; set; }
        public virtual decimal Late7 { get; set; }
        public virtual decimal Late30 { get; set; }
        public virtual decimal Late60 { get; set; }
        public virtual decimal Late90 { get; set; }
        public virtual decimal Late180 { get; set; }
        public virtual decimal Late180U { get; set; }
        public virtual decimal LateAll { get; set; }
        public virtual decimal LateAllVat { get; set; }
        public virtual DateTime? StopI { get; set; }
        public virtual DateTime? Dateend { get; set; }
        public virtual DateTime? WoDd { get; set; }
        public virtual string Product { get; set; }
        public virtual string Dept { get; set; }
        public virtual string Zip { get; set; }
        public virtual string Province { get; set; }
        public virtual string Region { get; set; }
        public virtual string Cusname { get; set; }
        public virtual string CusAdr1 { get; set; }
        public virtual string CusTel1 { get; set; }
        public virtual string Contact1 { get; set; }
        public virtual string CusAdr2 { get; set; }
        public virtual string CusTel2 { get; set; }
        public virtual string Contact2 { get; set; }
        public virtual string CusAdr3 { get; set; }
        public virtual string CusTel3 { get; set; }
        public virtual string Contact3 { get; set; }
        public virtual string G1 { get; set; }
        public virtual string G1Adr { get; set; }
        public virtual string G1Tel { get; set; }
        public virtual string G2 { get; set; }
        public virtual string G2Adr { get; set; }
        public virtual string G2Tel { get; set; }
        public virtual string G3 { get; set; }
        public virtual string G3Adr { get; set; }
        public virtual string G3Tel { get; set; }
        public virtual string G4 { get; set; }
        public virtual string G4Adr { get; set; }
        public virtual string G4Tel { get; set; }
        public virtual string Tr { get; set; }
        public virtual string TrFrom { get; set; }
        public virtual string TrTo { get; set; }
        public virtual string G1Name { get; set; }
        public virtual string G2Name { get; set; }
        public virtual string G3Name { get; set; }
        public virtual string G4Name { get; set; }
        public virtual DateTime? ComDd { get; set; }
        public virtual DateTime? First { get; set; }
        public virtual short DueDay { get; set; }
        public virtual short Terms { get; set; }
        public virtual DateTime? LastDd { get; set; }
        public virtual DateTime? TermDd { get; set; }
        public virtual string TypeEnt { get; set; }
        public virtual string Activity { get; set; }
        public virtual short Age { get; set; }
        public virtual string Collect { get; set; }
        public virtual string MktExe { get; set; }
        public virtual string MktName { get; set; }
        public virtual string Typefin { get; set; }
        public virtual string Lease { get; set; }
        public virtual short MetPay { get; set; }
        public virtual decimal IntQuo { get; set; }
        public virtual decimal Eff1 { get; set; }
        public virtual decimal Eff2 { get; set; }
        public virtual string Supcode { get; set; }
        public virtual string Supname { get; set; }
        public virtual string Asset { get; set; }
        public virtual string Brand { get; set; }
        public virtual string Chassis { get; set; }
        public virtual string EngSer { get; set; }
        public virtual string Licence { get; set; }
        public virtual string Eqpcode { get; set; }
        public virtual string Eqpdesc { get; set; }
        public virtual decimal Finance { get; set; }
        public virtual decimal FinVat { get; set; }
        public virtual string Cat9 { get; set; }
        public virtual double Comm { get; set; }
        public virtual double Deduct { get; set; }
        public virtual int InstNo { get; set; }
        public virtual string MktStatus { get; set; }
        public virtual string MktArea { get; set; }
        public virtual string EmpId { get; set; }
        public virtual int CommOdueFm { get; set; }
        public virtual int CommInstNo { get; set; }
        public virtual double CommOdue { get; set; }
        public virtual string Mobile { get; set; }
        public virtual string AgrSts { get; set; }
        public virtual string Ktbsalary { get; set; }
        public virtual double Profit { get; set; }
        public virtual string Model { get; set; }
        public virtual int? LateMaxPrv { get; set; }
        public virtual int? LateMaxNxt { get; set; }
        public virtual double CostVat { get; set; }
        public virtual double Down { get; set; }
        public virtual double DownVat { get; set; }
        public virtual double Depo { get; set; }
        public virtual double DepoVat { get; set; }
        public virtual double Income { get; set; }
        public virtual string RegionDesc { get; set; }
        public virtual string ActivityDesc { get; set; }
        public virtual string MetPayTxt { get; set; }
        public virtual string A01 { get; set; }
        public virtual string A10 { get; set; }
        public virtual string R { get; set; }
        public virtual string Comcode { get; set; }
        public virtual short? OdueTo { get; set; }
        public virtual DateTime? OdueFmDd { get; set; }
        public virtual DateTime? OdueToDd { get; set; }
        public virtual decimal? NoOdue { get; set; }
        public virtual decimal? DnOuts { get; set; }
        public virtual decimal? DnVatOuts { get; set; }
        public virtual decimal? Remain { get; set; }
        public virtual string TitleT { get; set; }
        public virtual decimal? OsPrOld { get; set; }
        public virtual decimal? OsPrCOld { get; set; }
        public virtual string Cbsaccount { get; set; }
        public virtual decimal? WoPrin { get; set; }
        public virtual DateTime? BirthDd { get; set; }
        public virtual string BranchK { get; set; }
        public virtual string CrExe { get; set; }
        public virtual decimal? OsArVat { get; set; }
        public virtual string LastEntry { get; set; }
        public virtual DateTime? LastEntryDd { get; set; }
        public virtual string CollL { get; set; }
        public virtual decimal? SchUnA { get; set; }
        public virtual decimal? ActUn { get; set; }
        public virtual decimal? ComBal { get; set; }
        #region NHibernate Composite Key Requirements
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var t = obj as BatchtbDomain;
            if (t == null) return false;
            if (ComId == t.ComId
             && Agrcode == t.Agrcode
             && BatchDd == t.BatchDd)
                return true;

            return false;
        }
        public override int GetHashCode()
        {
            int hash = GetType().GetHashCode();
            hash = (hash * 397) ^ ComId.GetHashCode();
            hash = (hash * 397) ^ Agrcode.GetHashCode();
            hash = (hash * 397) ^ BatchDd.GetHashCode();

            return hash;
        }
        #endregion
    }
}
