using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Ktbl.RiskManagement.Domain
{
    public class DecisionTable
    {
        public virtual int Id { get; set; }
        /// <summary>
        /// มีความเกียวข้องกับนักการเมื่อง
        /// </summary>
        public virtual bool PEPs { get; set; }
        /// <summary>
        /// ข้อมูลรายชื่อที่ ปปง แจ้งเป็นหรือเคยเป็นบุคคลที่ทำความผิด
        /// </summary>
        public virtual bool Amlo { get; set; }
        /// <summary>
        /// ประกอบอาชีพที่มีความเสี่ยงสูง ตามที่ ปปง กำหนด
        /// </summary>
        public virtual bool Occupation { get; set; }
        /// <summary>
        /// มีถิ่นพำนักหรือที่ตั้งบน High risk country in HR05 or HR06
        /// </summary>
        public virtual bool Country { get; set; }
        /// <summary>
        /// result Risk
        /// </summary>
        public virtual string Result { get; set; }
        /// <summary>
        /// type of personal
        /// </summary>
        public virtual string Type { get; set; }
        /// <summary>
        /// is active
        /// </summary>
        public virtual bool IsActive { get; set; }

        public virtual int Level { get; set; }
    }
}
/*
PEPs	amlo	occupation	country	class
0	1	1	1	R2aoc
0	1	1	0	R3ao
0	1	0	1	R3ac
0	1	0	0	R3a
0	0	0	0	R1
0	0	1	1	R2oc
0	0	1	0	R2o
0	0	0	1	R2c
1	1	1	1	R3paoc
1	1	1	0	P3pao
1	1	0	1	R3pac
1	1	0	0	R3pa
1	0	1	1	R3poc
1	0	1	0	R3po
1	0	0	1	R3pc
1	0	0	0	R3p
*/