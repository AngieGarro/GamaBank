using DataAccess.Crud;
using POJOS_DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore_Logic.Managers
{
    public class TransactionManager
    {
        public void Create(Transaction trans)
        {
            //Creacion de la transacción
            var crudFactory = new TransactionCrudFactory();
            crudFactory.Create(trans);

            var tran = crudFactory.RetrieveById<Transaction>(trans.Id);
            if (trans != null)
            {
                var c = new Customer();
                //Envio de sms
                var sms = new SmsManager();
                sms.SendSMS(trans,c);
            }
            else
            {
                throw new Exception("ERROR.");
            }
        }

        public Transaction RetrieveById(string Id)
        {
            var crudFactory = new TransactionCrudFactory();
            var trans = crudFactory.RetrieveById<Transaction>(Id);

            return trans;
        }

        public List<Transaction> RetrieveAll()
        {
            var crudFactory = new TransactionCrudFactory();
            var LstTrans = crudFactory.RetrieveAll<Transaction>();

            return LstTrans;
        }
    }
}
