using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESH_YMCUSTOMER.Data.Helpers
{
    public abstract class SerializeModel
    {
        public virtual string SerializeClass(bool isInsert, object customClass)
        {
            StringBuilder parameters = new StringBuilder();
            int length = customClass.GetType().GetProperties().Length;
            int counter = 0;
            foreach (var p in customClass.GetType().GetProperties())
            {
                counter++;
                //if not inserting go through properties, otherwise we skip the first(id)
                if (!isInsert)
                {
                    bool isValidPropertyType = true;

                    if (p.PropertyType == typeof(System.Int32))
                    {
                        parameters.Append(p.GetValue(customClass, null) ?? "null");
                    }
                    else if (p.PropertyType == typeof(System.Int16))
                    {
                        parameters.Append(p.GetValue(customClass, null) ?? "null");
                    }
                    else if (p.PropertyType == typeof(Nullable<System.Int32>))
                    {
                        parameters.Append(p.GetValue(customClass, null) ?? "null");
                    }
                    else if (p.PropertyType == typeof(Nullable<System.DateTime>))
                    {
                        if (p.GetValue(customClass, null) == null)
                        {
                            parameters.Append("null");
                        }
                        else
                        {
                            parameters.Append("'" + p.GetValue(customClass, null) + "'");
                        }
                    }
                    else if (p.PropertyType == typeof(System.DateTime))
                    {
                        if (p.GetValue(customClass, null) == null)
                        {
                            parameters.Append("null");
                        }
                        else
                        {
                            parameters.Append("'" + p.GetValue(customClass, null) + "'");
                        }
                    }
                    else if (p.PropertyType == typeof(Nullable<System.Int16>))
                    {
                        parameters.Append(p.GetValue(customClass, null) ?? "null");
                    }
                    else if (p.PropertyType == typeof(System.String))
                    {
                        if (p.GetValue(customClass, null) == null)
                        {
                            parameters.Append("null");
                        }
                        else
                        {
                            parameters.Append("'" + p.GetValue(customClass, null) + "'");
                        }
                    }
                    else if (p.PropertyType == typeof(System.Byte))
                    {
                        parameters.Append(p.GetValue(customClass, null) ?? "null");
                    }
                    else if (p.PropertyType == typeof(Nullable<System.Byte>))
                    {
                        parameters.Append(p.GetValue(customClass, null) ?? "null");
                    }
                    else if (p.PropertyType == typeof(System.Decimal))
                    {
                        parameters.Append(p.GetValue(customClass, null) ?? "null");
                    }
                    else if (p.PropertyType == typeof(Nullable<System.Decimal>))
                    {
                        parameters.Append(p.GetValue(customClass, null) ?? "null");
                    }
                    else
                    {
                        isValidPropertyType = false;
                        // parameters.Append(p.GetValue(customer, null));
                    }



                    if (isValidPropertyType)
                    {
                        if (counter < length)
                            parameters.Append(",");

                    }
                }
                else
                {
                    isInsert = false;
                }


            }
            return parameters.ToString();
        }
    }
}
