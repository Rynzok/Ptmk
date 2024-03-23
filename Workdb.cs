using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Ptmk
{
    static class Workdb
    {
        public static NpgsqlConnection Connect(string connectionString)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            try
            {
                conn.Open();
            }
            catch (Exception e)
            {
                throw new Exception("Error connecting to the database", e);
            }
            return conn;
        }

        public static async Task<bool> CreateDb(NpgsqlConnection conn, string sql)
        {
            try
            {
                var cmd = new NpgsqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                await cmd.ExecuteNonQueryAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
