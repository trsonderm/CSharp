using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TRS_06_28_2016_ESH_YMCUSTOMER.Models
{
    public class PriceUnitViewModel
    {
        
        public short price_unit_id { get; set; }

        public string price_unit_name { get; set; }

        public decimal? normalized_value { get; set; }

        public byte? display_order { get; set; }

        public short? currency_id { get; set; }

        public byte? volume_unit_id { get; set; }
    }
}