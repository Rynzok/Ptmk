using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ptmk
{
    class Employee
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime date { get; set; }
        public string sex { get; set; }
        public int? age {  get; set; }

        public Employee(string n, string d, string s) {
            name = n;
            date = DateTime.Parse(d);
            sex = s;
        }

        public void calAge() {
            DateTime today = DateTime.Today.Date;
            TimeSpan a = today - date; 
            age = a.Days/365;
        }

        public async Task<bool> AddDb(NpgsqlConnection conn)
        {
            try
            {
                string commandText = $@"INSERT INTO Employees (Name, Date, Sex, Age) VALUES (@name, @date, @sex, @age)";
                using (var cmd = new NpgsqlCommand(commandText, conn))
                {
                    cmd.Parameters.AddWithValue("name", name);
                    cmd.Parameters.AddWithValue("date", date);
                    cmd.Parameters.AddWithValue("sex", sex);
                    cmd.Parameters.AddWithValue("age", age);
                    await cmd.ExecuteNonQueryAsync();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }


        }
    }
}
