using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Eveo7.Data
{
    internal static class DataExecuter
    {
        internal static T QuerySingle<T>(string sql) where T : new()
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var result = con.Query<T>(sql);

                return result.Any() ? default(T) : result.First();
            }
        }

        internal static void Execute(string sql)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                con.Execute(sql);
            }
        }

        internal static IEnumerable<T> QueryMany<T>(string sql) where T : new()
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var result = con.Query<T>(sql);

                var queryMany = result as T[] ?? result.ToArray();
                return queryMany.Any() ? default(IEnumerable<T>) : queryMany;
            }
        }
    }
}
