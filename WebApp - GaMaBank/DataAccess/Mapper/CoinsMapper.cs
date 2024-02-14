using DataAccess.Dao;
using POJOS_DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class CoinsMapper : EntityMapper, ICrudStatments, IObjectMapper
    {

        //RECIBIR LOS DATOS DESDE SQL HASTA C#.
        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var coins = new Coins()
            {
                Id = row["Id"].ToString(),
                Name = row["Name"].ToString(),
                FintechCode = row["FintechCode"].ToString(),
                ExchangePrice = row["ExchangePrice"].ToString()  
            };

            return coins;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var coins = BuildObject(row);
                lstResults.Add(coins);
            }

            return lstResults;
        }


        //ENVIAR LOS DATOS DESDE C# HASTA UNA BD DE SQL.

        public SqlOperation DeleteStatements(BaseEntity entityPojo)
        {
            var operation = new SqlOperation { ProcedureName = "DELETE_COINS_PR" };

            var coins = (Coins)entityPojo;
            operation.AddVarcharParam("ID", coins.Id);

            return operation;
        }

        public SqlOperation GetCreateStatements(BaseEntity entityPojo)
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "CREATE_COINS_PR"
            };

            var coins = (Coins)entityPojo;
            operation.AddVarcharParam("ID", coins.Id);
            operation.AddVarcharParam("NAME", coins.Name);
            operation.AddVarcharParam("FINTECH_CODE", coins.FintechCode);
            operation.AddVarcharParam("PRICE", coins.ExchangePrice);

            return operation;
        }

        public SqlOperation GetRetrieveByIdStatements(string id)
        {
            var operation = new SqlOperation { ProcedureName = "RETRIEVE_ID_COINS" };

            operation.AddVarcharParam("ID", id);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RETRIEVE_ALL_COINS" };
            return operation;
        }

        public SqlOperation GetUpdateStatements(BaseEntity entityPojo)
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "UPDATE_COINS_PR"
            };

            var coins = (Coins)entityPojo;
            operation.AddVarcharParam("ID", coins.Id);
            operation.AddVarcharParam("NAME", coins.Name);
            operation.AddVarcharParam("FINTECH_CODE", coins.FintechCode);
            operation.AddVarcharParam("PRICE", coins.ExchangePrice);

            return operation;
        }
    }
}
