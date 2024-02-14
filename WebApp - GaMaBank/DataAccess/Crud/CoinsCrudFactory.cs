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
    public class CoinsCrudFactory : CrudFactory
    {
        private CoinsMapper mapper;
        public CoinsCrudFactory() : base()
        {
            mapper = new CoinsMapper();
            dao = SqlDao.GetInstance();

        }
        public override void Create(BaseEntity entityPojo)
        {
            var coins = (Coins)entityPojo;

            var sqlOperation = mapper.GetCreateStatements(coins);

            dao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseEntity entityPojo)
        {
            Coins coins = (Coins)entityPojo;
            dao.ExecuteProcedure(mapper.DeleteStatements(coins));
        }

        public override List<T> RetrieveAll<T>()
        {
            var listCoins = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objsPojo = mapper.BuildObjects(lstResult);
                foreach (var c in objsPojo)
                {
                    listCoins.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return listCoins;
        }

        public override T RetrieveById<T>(string Id)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetrieveByIdStatements(Id));

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
            var coins = (Coins)entityPojo;

            var sqlOperation = mapper.GetUpdateStatements(coins);

            dao.ExecuteProcedure(sqlOperation);
        }
    }
}
