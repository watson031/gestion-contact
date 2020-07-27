using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TP_Contact
{
    class Program
    {
        static void Connection1()
        {
            SqlConnection conn = new SqlConnection(connectionString: @"Data Source=8Z0QFT2\SQLEXPRESS;Initial Catalog=dbContact;Integrated Security=True;Connect Timeout=5");
            conn.Open();
            Console.WriteLine("Open");
            //database operations ...
            Thread.Sleep(1000);
            conn.Close();
            Console.WriteLine("closed");
        }

        static void Main(string[] args)
        {
            Connection1();
        }
    }
}
