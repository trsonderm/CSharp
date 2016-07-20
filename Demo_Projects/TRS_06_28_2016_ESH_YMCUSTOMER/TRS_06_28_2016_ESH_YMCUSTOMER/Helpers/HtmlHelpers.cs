using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using TRS_06_28_2016_ESH_YMCUSTOMER.Models;
using System.Data.Entity;
using ESH_YMCUSTOMER.Data;
using ESH_YMCUSTOMER.Data.Models;
using System.Data.SqlClient;
using System.Data;

namespace TRS_06_28_2016_ESH_YMCUSTOMER.Helpers
{
    public class Labeler
    {
        public static MvcHtmlString Label(PropertyInfo lbl)
        {
            string displayName = lbl.GetCustomAttributes(typeof(DisplayAttribute), true).Cast<DisplayAttribute>().First().Name ?? lbl.Name;

            return MvcHtmlString.Create($"<label for={lbl.Name}>{displayName}</label>");
        }
    }
    public class Editor
    {
        private ESHDataModel _context;
        public Editor()
        {
            _context = new ESHDataModel();
        }
        public static MvcHtmlString EditField(PropertyInfo edit, string value)
        {
            StringBuilder sb = new StringBuilder();
            bool isReadOnly = false;
            bool isLookup = false;
            bool isRequired = false;
            string isRequiredErrorMessage = "";
            var attr = (ReadOnlyAttribute[])edit.GetCustomAttributes(typeof(ReadOnlyAttribute), true);
            var isLookupAttr = (LookupAttribute[])edit.GetCustomAttributes(typeof(LookupAttribute), true);
            var isRequiredAttr = (RequiredAttribute[])edit.GetCustomAttributes(typeof(RequiredAttribute), true);

            if (attr.Length > 0)
            {
                  isReadOnly = edit.GetCustomAttributes(typeof(ReadOnlyAttribute), true).Cast<ReadOnlyAttribute>().First().IsReadOnly;
            }
            if (isRequiredAttr.Length > 0)
            {
                isRequiredErrorMessage = edit.GetCustomAttributes(typeof(RequiredAttribute), true).Cast<RequiredAttribute>().First().ErrorMessage;
                isRequired = true;
            }

            if (isLookupAttr.Length > 0){
                isLookup = true;
            }
            if (!isLookup)
            {
                sb.Append("<input ");
                if (edit.PropertyType == typeof(Nullable<DateTime>))
                {
                    sb.Append("type=\"datetime-local\" ");
                    if (value != "")
                    {
                        DateTime date = Convert.ToDateTime(value);

                        string formattedDate = date.Year + "-" + date.Month.ToString().PadLeft(2, '0') + "-" + date.Day.ToString().PadLeft(2, '0') + "T" + date.TimeOfDay + ".0";

                        value = formattedDate;
                    }

                }
                else
                {
                    sb.Append("type=\"textbox\"");
                }
                if (value != null)
                {
                    sb.Append(" value=\"" + value + "\" ");
                }


                sb.Append(" id=\"" + edit.Name + "\" ");

                sb.Append(" name=\"" + edit.Name + "\" ");

                if (isReadOnly)
                    sb.Append(" readonly ");

                if (isRequired)
                {
                    sb.Append(" data-val=\"true\" data-val-required=\"" + isRequiredErrorMessage + "\" />");
                    sb.Append("<span class=\"field-validation-valid\" data-valmsg-for=\"" + edit.Name + "\" data-valmsg-replace=\"true\"></span>");
                }
                else
                {
                    sb.Append("/>");
                }
            }else
            {
                //is Lookup stirnrg
                sb.Append("<select ");
                sb.Append(" id=\"" + edit.Name + "\" ");
                sb.Append(" name=\"" + edit.Name + "\" ");
                var lookupParams = edit.GetCustomAttributes(typeof(LookupAttribute), true)[0];
                var lookupParamsValue = (lookupParams as LookupAttribute).StoredProcedure;
                string[] lookupParamsValueArray = lookupParamsValue.ToString().Split(',');
                StoredProcedureHelper mySPHelper = new StoredProcedureHelper();
                DataTable spResults = mySPHelper.GetStoredProcedureResults(lookupParamsValueArray[0]);
                foreach (DataRow row in spResults.Rows)
                {
                    sb.Append("<option value=\"" + row[lookupParamsValueArray[1]] + "\">" + row[lookupParamsValueArray[2]] + "</option>");
                }
                sb.Append("</select>");
            }
            return MvcHtmlString.Create(sb.ToString());
        }

        public static MvcHtmlString DetailsField(PropertyInfo edit, string value)
        {
            StringBuilder sb = new StringBuilder();
            
            sb.Append("<input ");
            {
                sb.Append("type=\"textbox\"");
            }
            if (value != null)
            {
                sb.Append(" value=\"" + value + "\" ");
            }


            sb.Append(" id=\"" + edit.Name + "\" ");

            sb.Append(" name=\"" + edit.Name + "\" ");

            sb.Append(" readonly ");
            sb.Append("/>");

            return MvcHtmlString.Create(sb.ToString());
        }
    } 
    
    public class StoredProcedureHelper
    {
        private ESHDataModel _context;
        public StoredProcedureHelper()
        {
            _context = new ESHDataModel();
        }

        public DataTable GetStoredProcedureResults(string spName)
        {
            var sqlConnection = ((SqlConnection)_context.Database.Connection);
            DataTable dt = new DataTable();
            if (sqlConnection != null && sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
            using (SqlDataAdapter ad = new SqlDataAdapter())
            {
                SqlDataAdapter com = new SqlDataAdapter("exec " + spName, sqlConnection);
                com.Fill(dt);
            }
            return dt;
        }
    }     
}