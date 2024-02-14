using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dao
{
    public class SqlDao
    {
        private string connectionString = "";

        private static SqlDao instance;

        private SqlDao()
        {
            connectionString = ConfigurationManager.ConnectionStrings["GaMaBank"].ConnectionString;
        }

        //IMPLEMENTA EL PATRÓN SINGLETON
        public static SqlDao GetInstance()
        {
            if (instance == null)

                instance = new SqlDao();

            return instance;
        }

        public void ExecuteProcedure(SqlOperation operation)
        {
            using (var conn = new SqlConnection(connectionString))
            using (var command = new SqlCommand(operation.ProcedureName, conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {
                foreach (var param in operation.Parameters)
                {
                    command.Parameters.Add(param);
                }

                conn.Open();
                command.ExecuteNonQuery();
            }

        }

        //Encargado de ejecutar Store Procedures pero con una Respuesta.
        public List<Dictionary<string, object>> ExecuteQueryProcedure(SqlOperation operation)
        {
            var lstResult = new List<Dictionary<string, object>>();

            using (var conn = new SqlConnection(connectionString))
            using (var command = new SqlCommand(operation.ProcedureName, conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {
                foreach (var param in operation.Parameters)
                {
                    command.Parameters.Add(param);
                }

                conn.Open();

                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var dict = new Dictionary<string, object>();
                        for (var lp = 0; lp < reader.FieldCount; lp++)
                        {
                            dict.Add(reader.GetName(lp), reader.GetValue(lp));
                        }
                        lstResult.Add(dict);
                    }
                }
            }

            return lstResult;
        }
    }
}
