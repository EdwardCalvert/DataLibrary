using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLibrary
{
    public interface IDataAccess
    {
        Task<List<U>> LoadMultiple<U, T>(string sql, T Parameters, string connectionString);
        Task<U> LoadSingle<U, T>(string sql, T Parameters, string connectionString);
        Task SaveData<T>(string sql, T Parameters, string connectionString);
    }
}
