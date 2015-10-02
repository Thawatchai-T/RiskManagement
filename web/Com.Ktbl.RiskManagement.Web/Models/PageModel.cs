using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Com.Ktbl.RiskManagement.Web.Models
{
    public class PageModel<T>
    {
        public List<T> data { get; set; }
        public int total { get; set; }
    }
}