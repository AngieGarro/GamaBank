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
    public class TransactionCrudFactory : CrudFactory
    {
        private TransactionMapper mapper;
        public TransactionCrudFactory() : base()
        {
            mapper = new TransactionMapper();
            dao = SqlDao.GetInstance();

        }
        public override void Create(BaseEntity entityPojo)
        {
            var transc = (Transaction)entityPojo;

            var sqlOperation = mapper.GetCreateStatements(transc);

            dao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseEntity entityPojo)
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>()
        {
            var listTransc = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objsPojo = mapper.BuildObjects(lstResult);
                foreach (var c in objsPojo)
                {
                    listTransc.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return listTransc;
        }

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
            throw new NotImplementedException();
        }
    }
}
