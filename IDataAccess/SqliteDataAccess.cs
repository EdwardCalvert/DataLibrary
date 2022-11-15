using Dapper;
using DataLibrary;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdCalvert.DataLibrary
{
    public class SqliteDataAccess :IDataAccess
    {
        public async Task<List<U>> LoadMultiple<U, T>(string sql, T Parameters, string connectionString)
        {
            using (IDbConnection connection = new SQLiteConnection(connectionString))
            {
                var rows = await connection.QueryAsync<U>(sql, Parameters);

                return rows.ToList();
            }
        }

        public async Task<U> LoadSingle<U, T>(string sql, T Parameters, string connectionString)
        {
            using (IDbConnection connection = new SQLiteConnection(connectionString))
            {
                var rows = await connection.QueryAsync<U>(sql, Parameters);

                return rows.Single();
            }
        }

        public Task SaveData<T>(string sql, T Parameters, string connectionString)
        {
            using (IDbConnection connection = new SQLiteConnection(connectionString))
            {
                return connection.ExecuteAsync(sql, Parameters);
            }
        }

    }
}
