using Dapper;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DataLibrary
{
    public class MySqlDataAccess : IDataAccess
    {
        public async Task<List<U>> LoadMultiple<U, T>(string sql, T Parameters, string connectionString)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                var rows = await connection.QueryAsync<U>(sql, Parameters);

                return rows.ToList();
            }
        }


        public async Task<U> LoadSingle<U, T>(string sql, T Parameters, string connectionString)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                var rows = await connection.QueryAsync<U>(sql, Parameters);

                return rows.Single();
            }
        }

        public Task SaveData<T>(string sql, T Parameters, string connectionString)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                return connection.ExecuteAsync(sql, Parameters);
            }
        }
    }
}