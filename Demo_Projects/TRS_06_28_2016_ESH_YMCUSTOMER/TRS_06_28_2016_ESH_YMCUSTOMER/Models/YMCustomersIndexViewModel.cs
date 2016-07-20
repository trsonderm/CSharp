/// <summary>
/// 
/// </summary>
namespace TRS_06_28_2016_ESH_YMCUSTOMER.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Web;
    using ESH_YMCUSTOMER.Data.Models;
    using TRS_06_28_2016_ESH_YMCUSTOMER.Models;

    public class YMCustomersIndexViewModel
    {
        public List<string> DisplayOrder { get; set; }

        public Dictionary<string, string> displayNames { get; set; }

        public List<YMCustomersCreateViewModel> YMCustomers { get; set; }

        public YMCustomersIndexViewModel()
        {
            DisplayOrder = new List<string>(new string[] { "ym_customer_id", "customer_name" });
        }

        public YMCustomersIndexViewModel(List<string> displayOrder)
        {
            displayNames = new Dictionary<string, string>();
            displayNames.Add("ym_customer_id", "Customer Id");
            displayNames.Add("customer_notes", "Notes");
            displayNames.Add("customer_name", "Name");
            DisplayOrder = displayOrder;
        }
    }
}