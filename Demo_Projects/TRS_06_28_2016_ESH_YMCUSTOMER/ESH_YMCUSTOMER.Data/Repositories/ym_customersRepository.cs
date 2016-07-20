using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESH_YMCUSTOMER.Data.Models;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using ESH_YMCUSTOMER.Data.Helpers;
using System.Data.Entity;

namespace ESH_YMCUSTOMER.Data.Repositories
{
    interface IYMCustomerRepository : IDisposable
    {
        int InsertCustomer(ym_customers entity);

        void UpdateCustomer(ym_customers entity);

        void DeleteCustomer(ym_customers entity);

        IEnumerable<ym_customers> GetCustomers();

        ym_customers GetCustomerById(int id);        

    }

    public class ym_customersRepository : SerializeModel, IYMCustomerRepository
    {
        private ESHDataModel context;
        private string lTempString;
        private bool lTempUseQuotes;

        public ym_customersRepository(ESHDataModel context)
        {
            this.context = context;
        }

        public IEnumerable<ym_customers> GetCustomers()
        {
            return context.Database.SqlQuery<ym_customers>("exec sp_xReadAllYMCustomers").ToList();
        }

        public ym_customers GetCustomerById(int id)
        {
            var result = context.ym_customers.SqlQuery("exec sp_xReadYmCustomer " + id).Single();

            return result;
        }

        public int InsertCustomer(ym_customers customer)
        {
            string parameters = SerializeClass(true, customer);
            try
            {
                var result = context.Database.SqlQuery<int>("exec sp_xInsertYmCustomer " + parameters.ToString());
                Save();
                return Convert.ToInt32(result.First());
            }
            catch (Exception ex)
            {
                var tester = "error stop";
            }
            return 1;
        }

        public void DeleteCustomer(ym_customers customer)
        {
            context.Database.SqlQuery<string>("exec sp_xDeleteYMCustomer " + customer.ym_customer_id);
        }

        public void UpdateCustomer(ym_customers customer)
        {
            string parameters = SerializeClass(false, customer);
            //var testString = "exec sp_xUpdateYmCustomer " + parameters.ToString();
            try
            {
                context.Database.ExecuteSqlCommand("exec sp_xUpdateYmCustomer " + parameters.ToString());
                Save();
            }
            catch(Exception ex)
            {
                var tester = "error stop";
            }
            
        }

        

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void AppendValue(ref string aSQLString, string aQueryVal, bool aUseQuotes, bool aIsFirst)
        {

            string returnVal = "";
            if (!aIsFirst)
            {
                returnVal = ", ";
            }
            else
            {
                returnVal = " ";
            }

            if (aUseQuotes)
            {
                returnVal += "'";
            }

            string sThisQueryVal = aQueryVal?.ToString() ?? "";
            if (sThisQueryVal != "")
            {
                returnVal += sThisQueryVal;
            }
            else if (!aUseQuotes)
            {
                returnVal += "null";
            }

            if (aUseQuotes)
            {
                returnVal += "'";
            }

            aSQLString += returnVal;
        }

    }
}
