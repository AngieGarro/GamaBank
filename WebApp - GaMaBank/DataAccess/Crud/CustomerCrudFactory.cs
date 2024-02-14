using DataAccess.Dao;
using DataAccess.Mapper;
using POJOS_DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Crud
{
    public class CustomerCrudFactory : CrudFactory
    {
        private CustomerMapper mapper;
        public CustomerCrudFactory() : base()
        {
            mapper = new CustomerMapper();
            dao = SqlDao.GetInstance();
         
        }

        //POST      
        public override void Create(BaseEntity entityPojo)
        {
            var customer = (Customer)entityPojo;

            var sqlOperation = mapper.GetCreateStatements(customer);

            dao.ExecuteProcedure(sqlOperation);
        }
   
        //PUT
        public override void Update(BaseEntity entityPojo)
        {
            var customer = (Customer)entityPojo;

            var sqlOperation = mapper.GetUpdateStatements(customer);

            dao.ExecuteProcedure(sqlOperation);
        }


        //DELETE
        public override void Delete(BaseEntity entityPojo)
        {
            Customer customer = (Customer)entityPojo;
            dao.ExecuteProcedure(mapper.DeleteStatements(customer));
        }

        //GET
        public override T RetrieveById<T>(string id)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetrieveByIdStatements(id));

            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objsPojo = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objsPojo, typeof(T));
            }

            return default(T);
        }

        public override List<T> RetrieveAll<T>()
        {
            var listCustomers = new List<T>(); 

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objsPojo = mapper.BuildObjects(lstResult);
                foreach (var c in objsPojo)
                {
                    listCustomers.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return listCustomers;
        }


    }
}
