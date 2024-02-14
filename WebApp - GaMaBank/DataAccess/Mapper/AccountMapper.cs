using DataAccess.Dao;
using POJOS_DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class AccountMapper : EntityMapper, ICrudStatments, IObjectMapper
    {
        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var account = new Account()
            {
                UBAN = row["UBAN"].ToString(),
                AccountName = row["AccountName"].ToString(),
                CustomerId = row["CustomerId"].ToString(),
                CoinCode = row["CoinCode"].ToString(),
                Status = row["Status"].ToString(),
            };

            return account;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var account = BuildObject(row);
                lstResults.Add(account);
            }

            return lstResults;
        }

        //ENVIAR LOS DATOS DESDE C# HASTA UNA BD DE SQL.

        //______________________________________________

        public SqlOperation DeleteStatements(BaseEntity entityPojo)
        {
            var operation = new SqlOperation { ProcedureName = "SP_DELETE_ACCOUNT" };

            var acc = (Account)entityPojo;
            operation.AddVarcharParam("UBAN", acc.UBAN);

            return operation;
        }

        //Implementacion requerida.
        public SqlOperation GetCreateStatements(BaseEntity entityPojo)
        {
            var operation = new SqlOperation();
            operation.ProcedureName = "CRE_ACCOUNT_PR";

            var a = (Account)entityPojo;
            operation.AddVarcharParam("UBAN", a.UBAN);
            operation.AddVarcharParam("ACCOUNT_NAME", a.AccountName);
            operation.AddVarcharParam("CUSTOMER_ID", a.CustomerId);
            operation.AddVarcharParam("COIN_CODE", a.CoinCode);
            operation.AddVarcharParam("STATUS", a.Status);

            return operation;
        }

        //Implementacion requerida.
        public SqlOperation GetRetrieveByIdStatements(string id)
        {
            var operation = new SqlOperation();
            operation.ProcedureName = "RET_ACCOUNT_BY_UBAN_PR";
            operation.AddVarcharParam("UBAN", id);

            return operation;
        }

        //Implementacion requerida.
        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RETRIEVE_ALL_ACCOUNT" };
            return operation;
        }


        public SqlOperation GetUpdateStatements(BaseEntity entityPojo)
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "PR_UPDATE_ACCOUNT"
            };

            var a = (Account)entityPojo;
            operation.AddVarcharParam("UBAN", a.UBAN);
            operation.AddVarcharParam("ACCOUNT_NAME", a.AccountName);
            operation.AddVarcharParam("COIN_CODE", a.CoinCode);
            operation.AddVarcharParam("STATUS", a.Status);

            return operation;
        }
    }
}
