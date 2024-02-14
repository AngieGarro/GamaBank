using DataAccess.Dao;
using POJOS_DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class TransactionMapper : EntityMapper, ICrudStatments, IObjectMapper
    {
        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var Transc = new Transaction()
            {
                Id = row["Id"].ToString(),
                Amount =row["Amount"].ToString(),
                Type = row["Type"].ToString(),
                AccountUBAN = row["AccountUBAN"].ToString(),
                FintechUBAN = row["FintechUBAN"].ToString()
            };

            return Transc;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var Trasc = BuildObject(row);
                lstResults.Add(Trasc);
            }

            return lstResults;
        }

        public SqlOperation DeleteStatements(BaseEntity entityPojo)
        {
            throw new NotImplementedException();
        }

        //CREACION DE LA TRANSFERENCIA O EL MOVIMIENTO BANCARIO
        public SqlOperation GetCreateStatements(BaseEntity entityPojo)
        {
            var Transc = (Transaction)entityPojo;
            SqlOperation operation = new SqlOperation();

            if (Transc.FintechUBAN.Equals("-"))
            {
                operation.ProcedureName = "SP_CREATE_MOVE_TRANSACTION";
            }
            else
            {
                operation.ProcedureName = "SP_CREATE_TRANSACTION";
            }
            operation.AddVarcharParam("ID", Transc.Id);
            operation.AddVarcharParam("AMOUNT", Transc.Amount);
            operation.AddVarcharParam("TYPE", Transc.Type);
            operation.AddVarcharParam("ACCOUNT_UBAN", Transc.AccountUBAN);
            operation.AddVarcharParam("FINTECH_UBAN", Transc.FintechUBAN);

            return operation;
        }

        public SqlOperation GetRetrieveByIdStatements(string Id)
        {
            var operation = new SqlOperation { ProcedureName = "SP_RETRIEVE_ID_TRANSC" };

            operation.AddVarcharParam("Id", Id);

            return operation;
        }

        //RETRIEVE CON EL ID DE LA CUENTA
        public SqlOperation GetRetrieveStatement(BaseEntity entityPojo)
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "SP_RETRIEVE_TRANS_ID_ACCOUNT"
            };

            var account = (Account)entityPojo;
            operation.AddVarcharParam("ACCOUNT_UBAN", account.UBAN);
            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "SP_RETRIEVE_ALL_TRANS" };
            return operation;
        }

        public SqlOperation GetUpdateStatements(BaseEntity entityPojo)
        {
            throw new NotImplementedException();
        }
    }
}
