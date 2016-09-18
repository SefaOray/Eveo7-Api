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
        internal static T QuerySingle<T>(string sql, object param = null) where T : new()
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var result = con.Query<T>(sql, param);

                return result.Any() ? result.First() : default(T);
            }
        }

        internal static void Execute(string sql, object param = null)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                con.Execute(sql, param);
            }
        }

        internal static IEnumerable<T> QueryMany<T>(string sql, object param = null) where T : new()
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var result = con.Query<T>(sql, param);

                var queryMany = result as T[] ?? result.ToArray();
                return queryMany.Any() ? queryMany : default(IEnumerable<T>);
            }
        }

        internal static IEnumerable<T> QueryMany<T,T2>(string sql, Func<T,T2, T> mapperFunc, object param = null) where T : new()
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var result = con.Query<T, T2, T>(sql, mapperFunc,param);

                var queryMany = result as T[] ?? result.ToArray();
                return queryMany.Any() ? default(IEnumerable<T>) : queryMany;
            }
        }
    }
}
