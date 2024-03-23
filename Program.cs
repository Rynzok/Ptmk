using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ptmk
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // connect
            string connectionString = ConfigurationManager.ConnectionStrings["ptmk"].ConnectionString;
            var conn = Workdb.Connect(connectionString);


            if (args[0] == "1")
            {
                string sql = $@"
                                    CREATE TABLE IF NOT EXISTS Employees(
                                    Id SERIAL PRIMARY KEY,
                                    Name CHARACTER VARYING(40),
                                    Date DATE,
                                    Sex CHARACTER VARYING(10),
                                    Age INTEGER)
                              ";

                var result = await Workdb.CreateDb(conn, sql);
                if (result == true)
                {
                    Console.WriteLine("Good");
                }
                else
                {
                    Console.WriteLine("Error");
                }       
            }
            else
            {
                Console.WriteLine("What?");

            }

            foreach (string arg in args)
            {   
                Console.WriteLine(arg);
            }
        }
    }
}
