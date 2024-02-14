using DataAccess.Crud;
using POJOS_DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore_Logic.Managers
{
    public class CoinsManager
    {
        public void Create(Coins coins)
        {
            var crudFactory = new CoinsCrudFactory();
            crudFactory.Create(coins);
        }

        public void DeleteCoins(Coins coins)
        {
            var crudFactory = new CoinsCrudFactory();
            crudFactory.Delete(coins);
        }


        public void DeleteCoins(string _code)
        {
            var crudFactory = new CoinsCrudFactory();
            crudFactory.Delete(new Coins() { Id = _code });
        }

        public void UpdateCoins(Coins coins)
        {
           
                var crudFactory = new CoinsCrudFactory();

                crudFactory.Update(coins);
        }

        public Coins RetrieveById(string Id)
        {
            var crudFactory = new CoinsCrudFactory();
            var coins = crudFactory.RetrieveById<Coins>(Id);

            return coins;
        }

        public List<Coins> RetrieveAll()
        {
            var crudFactory = new CoinsCrudFactory();
            var LstCoins = crudFactory.RetrieveAll<Coins>();

            return LstCoins;
        }
    }
}
