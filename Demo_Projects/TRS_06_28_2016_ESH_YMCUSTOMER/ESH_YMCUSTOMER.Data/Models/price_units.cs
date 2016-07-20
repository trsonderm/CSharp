namespace ESH_YMCUSTOMER.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class price_units
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short price_unit_id { get; set; }

        [StringLength(50)]
        public string price_unit_name { get; set; }

        public decimal? normalized_value { get; set; }

        public byte? display_order { get; set; }

        public short? currency_id { get; set; }

        public byte? volume_unit_id { get; set; }
    }
}
