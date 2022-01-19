using System;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jcDeskInventory
{
    internal class DBConnection
    {
        public static string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=jcDeskInventoryDB;Integrated Security = true;encrypt=false";
    }
}
