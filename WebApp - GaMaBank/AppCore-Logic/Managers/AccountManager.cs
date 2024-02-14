using DataAccess.Crud;
using POJOS_DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore_Logic.Managers
{
    public class AccountManager
    {
        //CREACION DE LA CUENTA AL CREAR EL CUSTOMER
        public void CreateAccount(Account a)
        {
            var crud = new AccountCrudFactory();
            crud.Create(a);
        }


        public Account RetrieveAccountById(string uban)
        {
            var crudFactory = new AccountCrudFactory();
            var a = crudFactory.RetrieveById<Account>(uban);

            return new Account();
        }

        //CREACION SEPARADA DEL CUSTOMER DE LA CUENTA.
        public void Create(Account account)
        {
            var crudFactory = new AccountCrudFactory();
            crudFactory.Create(account);

        }

        public void DeleteAccount(Account account)
        {
            var crudFactory = new AccountCrudFactory();
            crudFactory.Delete(account);
        }

        public void DeleteAccount(string _code)
        {
            var crudFactory = new AccountCrudFactory();
            crudFactory.Delete(new Account() { Id = _code });
        }

        public void UpdateAccount(Account account)
        {

            var crudFactory = new AccountCrudFactory();
            crudFactory.Update(account);
        }

        public Account RetrieveById(string Id)
        {
            var crudFactory = new AccountCrudFactory();
            var account = crudFactory.RetrieveById<Account>(Id);

            return account;
        }

        public List<Account> RetrieveAll()
        {
            var crudFactory = new AccountCrudFactory();
            var LstAccounts = crudFactory.RetrieveAll<Account>();

            return LstAccounts;
        }

        //INCREMENTACIÓN DEL CALCULO PARA EL INGRESO DEL SALDO.
        //Balance = Suma de los montos de todas las transacciones(Amount).
       /** public int calBalance(double _amount, double balance)
        {
            var trans = new Transaction();
            var acc = new Account();
            balance = acc.Balance;

            _amount = trans.Amount + trans.move;
            return balance;
        }
       */
    }
}
