using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using TRS_06_28_2016_ESH_YMCUSTOMER.Models;

namespace TRS_06_28_2016_ESH_YMCUSTOMER.Helpers
{
    public class OrderedPropertiesHelper
    {
       
        public static IOrderedEnumerable<PropertyInfo> GetSortedProperties<T>()
        {
            return typeof(T)
              .GetProperties()
              .OrderBy(p => ((OrderAttribute)p.GetCustomAttributes(typeof(OrderAttribute), false)[0]).Order);
        }
        public static MvcHtmlString CreateFormItem(YMCustomersCreateViewModel createField)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("<fieldset class=\"form-group\">");
            foreach (var prop in GetSortedProperties<YMCustomersCreateViewModel>())
            {
                //Console.WriteLine(prop.GetValue(createField, null));
                //sb.Append(LabelFor(createField => createField[prop]);//model => model[prop.Name]);
            }
            sb.Append("</fieldset>");
            return new MvcHtmlString(sb.ToString());



        }
    }   
}