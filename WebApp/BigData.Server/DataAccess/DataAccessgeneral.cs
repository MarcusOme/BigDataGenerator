using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigData.Server.DataAccess
{
    /// <summary>
    /// Helper class that is the base for all the others that access database, contains connection string
    /// </summary>
    public class DataAccessgeneral
    {
        public string conn_str = @"Server=.\SQLExpress;Database=BigData;Trusted_Connection=True;MultipleActiveResultSets=true";
    }
}
