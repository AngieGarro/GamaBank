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
    public class AccountCrudFactory : CrudFactory
    {
        private AccountMapper mapper;

        public AccountCrudFactory(): base()
        {
            mapper = new AccountMapper();

            dao = SqlDao.GetInstance();
        }

        //REQUERIDO.
        public override void Create(BaseEntity entityPojo)
        {
            var account = (Account)entityPojo;

            var sqlOperation = mapper.GetCreateStatements(account);

            dao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseEntity entityPojo)
        {
            Account acc = (Account)entityPojo;
            dao.ExecuteProcedure(mapper.DeleteStatements(acc));
        }

        //REQUERIDO.
        public override List<T> RetrieveAll<T>()
        {
            var listAccounts = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objsPojo = mapper.BuildObjects(lstResult);
                foreach (var c in objsPojo)
                {
                    listAccounts.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return listAccounts;
        }

        //REQUERIDO.
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

        public override void Update(BaseEntity entityPojo)
        {
            var account = (Account)entityPojo;

            var sqlOperation = mapper.GetUpdateStatements(account);

            dao.ExecuteProcedure(sqlOperation);
        }
    }
}
