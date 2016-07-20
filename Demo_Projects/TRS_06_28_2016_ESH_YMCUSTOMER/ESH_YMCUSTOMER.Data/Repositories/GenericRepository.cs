using ESH_YMCUSTOMER.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESH_YMCUSTOMER.Data.Repositories
{
    public class GenericRepository
    {
        private ESHDataModel context;
        private string lTempString;
        private bool lTempUseQuotes;

        public GenericRepository(ESHDataModel context)
        {
            this.context = context;
        }

    }
}
