using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Ktbl.RiskManagement.Process
{
    /// <summary>
    /// R3paoc     ระดับความเสี่ยงที่ 3 และมีรายชื่อใน PEPs, Amlo, Occupation, Country
    /// R3pao      ระดับความเสี่ยงที่ 3 และมีรายชื่อใน PEPs, Amlo, Occupation
    /// R3pa       ระดับความเสี่ยงที่ 3 และมีรายชื่อใน PEPs, Amlo, Country
    /// R3poc      ระดับความเสี่ยงที่ 3 และมีรายชื่อใน PEPs, Amlo
    /// R3po       ระดับความเสี่ยงที่ 3 และมีรายชื่อใน PEPs, Occupation, Country
    /// R3pc       ระดับความเสี่ยงที่ 3 และมีรายชื่อใน PEPs, Occupation
    /// R3p        ระดับความเสี่ยงที่ 3 และมีรายชื่อใน PEPs, Country
    /// R3aoc      ระดับความเสี่ยงที่ 3 และมีรายชื่อใน PEPs
    /// R3ao       ระดับความเสี่ยงที่ 3 และมีรายชื่อใน Amlo, Occupation, Country
    /// R3ac       ระดับความเสี่ยงที่ 3 และมีรายชื่อใน Amlo, Occupation
    /// R3a        ระดับความเสี่ยงที่ 3 และมีรายชื่อใน Amlo, Country
    /// R2oc       ระดับความเสี่ยงที่ 3 และมีรายชื่อใน Amlo
    /// R2o        ระดับความเสี่ยงที่ 3 และมีรายชื่อใน Occupation, Country
    /// R2c        ระดับความเสี่ยงที่ 3 และมีรายชื่อใน Country
    /// R1         ระดับความเสี่ยงที่ 1
    /// </summary>
    public enum TypeRiskPersonal
    {
        R3paoc,
        R3pao,
        R3pa,
        R3poc,
        R3po,
        R3pc,
        R3p,
        R3aoc,
        R3ao,
        R3ac,
        R3a,
        R2oc,
        R2o,
        R2c,
        R1
    }
}
