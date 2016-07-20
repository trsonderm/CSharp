namespace ESH_YMCUSTOMER.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ym_customers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ym_customer_id { get; set; }

        public int? facility_id { get; set; }

        [StringLength(80)]
        [Display(Name = "Customer Name")]
        public string customer_name { get; set; }

        [StringLength(255)]
        [Display(Name = "Notes")]
        public string customer_notes { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? customer_start_date { get; set; }

        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? customer_end_date { get; set; }

        [Display(Name = "Mileage")]
        public decimal? mileage { get; set; }

        [Display(Name = "Freight Per Car")]
        [Column(TypeName = "money")]
        public decimal? freight_per_car { get; set; }

        [Display(Name = "Freight Per Unit")]
        [Column(TypeName = "money")]
        public decimal? freight_per_unit { get; set; }

        public virtual price_units price_units { get; set; }

        [Display(Name = "Price Unit", Prompt = "Select Price Unit", Description = "Price Unit Description")]
        [ForeignKey("price_units")]
        public short? price_unit_id { get; set; }

        [Display(Name = "Surcharge Flag")]
        public byte? surcharge_flag { get; set; }

        [Display(Name = "Cars Required Per Week")]
        [Column(TypeName = "int")]
        public short? cars_required_per_week { get; set; }

        [Display(Name = "Product Type")]
        [StringLength(80)]
        public string product_type { get; set; }

        
    }
}
