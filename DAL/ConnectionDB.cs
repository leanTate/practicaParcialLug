using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DAL
{
    internal sealed class ConnectionDB
    {
        private static SqlConnection _instance = null;

        public static SqlConnection Instance {
            get
            {
                if (_instance == null) _instance = new SqlConnection("Data Source=.;Initial Catalog=practicaP;Integrated Security=True");
                
                return _instance;
            }
        }
        
        public static void Open() {
            if (_instance.State == ConnectionState.Closed)
                _instance.Open();
        }
        
        public static void Close() { 
            if (_instance.State == ConnectionState.Open)
                _instance.Close();
        }
        }
}
