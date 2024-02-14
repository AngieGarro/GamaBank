using DataAccess.Dao;
using POJOS_DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class CustomerMapper : EntityMapper, ICrudStatments, IObjectMapper
    {

        //ENVIAR LOS DATOS DESDE C# HASTA UNA BD DE SQL.

        //______________________________________________

        //OPERACIÓN PARA CREAR EL CUSTOMER
        public SqlOperation GetCreateStatements(BaseEntity entityPojo)
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "CRE_CUSTOMER_PR"
            };

            var customer = (Customer)entityPojo;
            operation.AddVarcharParam("ID", customer.Id);
            operation.AddVarcharParam("NAME", customer.Name);
            operation.AddVarcharParam("LAST_NAME", customer.LastName);
            operation.AddVarcharParam("EMAIL", customer.Email);
            operation.AddVarcharParam("PHONE_NUMBER", customer.Phone);

           return operation;
        }


        //OPERACIÓN PARA ACTUALIZAR DATA
        public SqlOperation GetUpdateStatements(BaseEntity entityPojo)
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "SP_UPDATE_CUSTOMER"
            };
            var customer = (Customer)entityPojo;
            operation.AddVarcharParam("ID", customer.Id);
            operation.AddVarcharParam("NAME", customer.Name);
            operation.AddVarcharParam("LAST_NAME", customer.LastName);
            operation.AddVarcharParam("EMAIL", customer.Email);
            operation.AddVarcharParam("PHONE_NUMBER", customer.Phone);

            return operation;
        }

        //OPERACIÓN PARA ELIMINAR EL CUSTOMER POR MEDIO DE SU ID
        public SqlOperation DeleteStatements(BaseEntity entityPojo)
        {
            var operation = new SqlOperation { ProcedureName = "SP_DELETE_CUSTOMER" };

            var cust = (Customer)entityPojo;
            operation.AddVarcharParam("ID", cust.Id);

            return operation;
        }

        public SqlOperation GetRetrieveByIdStatements(string id)
        {
            var operation = new SqlOperation { ProcedureName = "SP_RETRIEVE_ID_CUSTOMER" };

            operation.AddVarcharParam("ID", id);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "SP_RETRIEVE_ALL_CUSTOMER" };
            return operation;
        }


        //RECIBIR LOS DATOS DESDE SQL HASTA C#.

        //______________________________________________
        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var customer = BuildObject(row);
                lstResults.Add(customer);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var customer = new Customer()
            {
                Id = row["Id"].ToString(),
                Name = row["Name"].ToString(),
                LastName = row["LastName"].ToString(),
                Email = row["Email"].ToString(),
                Phone = row["Phone"].ToString()
            };

            return customer;
        }

    }
}
