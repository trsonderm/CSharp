using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TRS_06_28_2016_ESH_YMCUSTOMER.Models
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field,
    Inherited = true, AllowMultiple = false)]
    [ImmutableObject(true)]
    public sealed class OrderAttribute : Attribute
    {
        private readonly int order;
        public int Order { get { return order; } }
        public OrderAttribute(int order) { this.order = order; }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field,
    Inherited = true, AllowMultiple = false)]
    [ImmutableObject(true)]
    public sealed class LookupAttribute : Attribute
    {
        private readonly string storedProcedure;
        public string StoredProcedure { get { return storedProcedure; } }
        public LookupAttribute(string storedProcedure) { this.storedProcedure = storedProcedure; }
    }

    public class YMCustomersCreateViewModel
    {
        [Order(0)]
        [ReadOnly(true)]
        [Display(Name = "ID")]
        public int ym_customer_id { get; set; }


        [Order(1)]
        [StringLength(80)]
        [Display(Name = "Customer Name")]
        public string customer_name { get; set; }

        [Order(5)]
        [StringLength(255)]
        [MaxLength(20,ErrorMessage = "Notes Exceed Max Length")]
        [Display(Name = "Notes")]
        public string customer_notes { get; set; }

        [Order(3)]
        [Required(ErrorMessage = "Date is Required")]
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? customer_start_date { get; set; }

        [Order(4)]
        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? customer_end_date { get; set; }

        [Order(5)]
        [Display(Name = "Mileage")]
        public decimal? mileage { get; set; }

        [Order(6)]
        [Display(Name = "Freight Per Car")]
        [Column(TypeName = "money")]
        public decimal? freight_per_car { get; set; }

        [Order(7)]
        [Display(Name = "Freight Per Unit")]
        [Column(TypeName = "money")]
        public decimal? freight_per_unit { get; set; }

        [Lookup("sp_xReadAllPriceUnits,price_unit_id,price_unit_name")]
        [Order(8)]
        [Display(Name = "Price Unit", Prompt = "Select Price Unit", Description = "Price Unit Description")]
        public short? price_unit_id { get; set; }

        [Order(9)]
        [Display(Name = "Surcharge Flag")]
        public byte? surcharge_flag { get; set; }

        [Order(10)]
        [Display(Name = "Cars Required Per Week")]
        [Column(TypeName = "int")]
        public short? cars_required_per_week { get; set; }

        [Order(11)]
        [Display(Name = "Product Type")]
        [StringLength(80)]
        public string product_type { get; set; }

       }
}