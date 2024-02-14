using AppCore_Logic.Managers;
using DataAccess.Crud;
using POJOS_DTOs;
using System;
using System.Collections.Generic;


namespace AppCore_Logic
{
    public class CustomerManager
    {

        //CREACIÓN DE CUSTOMER CON LA CUENTA.
        public void Create(Customer customer)
        
        {
            //Creacion del cliente.
            var crudFactory = new CustomerCrudFactory();
            crudFactory.Create(customer);

            //Verificacion del cliente.
            var c = crudFactory.RetrieveById<Customer>(customer.Id);

            if (c != null)
            {
                var newAccount = new Account()
                {
                    CustomerId = customer.Id,
                    CoinCode = "CFG",
                    AccountName = "Cuenta de apertura",
                    Status = "AC",
                    UBAN = GetUban()
                };

                var am = new AccountManager();
                am.CreateAccount(newAccount);

                var account = am.RetrieveAccountById(newAccount.UBAN);
                //Envio de correo de verificaion, indicando informacion de la nueva cuenta.
                var em = new EmailManager();
                em.SendEmail(customer, account);
               

                if (account != null)
                {
                    throw new Exception("Cuenta creada con exito.");
                }
                else
                {
                    throw new Exception("ERROR al crear la cuenta.");
                }

            }
            else
            {
                throw new Exception("ERROR al crear el cliente.");
            }
        }


        //GENERA UN UBAN PROVISIONAL PARA CREAR LA CUENTA GENERICA.
        //EN EL UPDATE DE LA CUENTA SE DEBE ACTUALIZAR EL UBAN.
        private string GetUban()
        {
            var random = new Random();
            var code = "";
            var chars = /*"ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"*/ "CR" + "_" + "1234567890";

            for (int i = 0; i < 10; i++)
            {
                code += chars[random.Next(chars.Length)];
            }

            return code;
        }

        public void DeleteCustomer(Customer customer)
        {
            var crudFactory = new CustomerCrudFactory();
            crudFactory.Delete(customer);
        }

        public void DeleteCustomer(string _code)
        {
            var crudFactory = new CustomerCrudFactory();
            crudFactory.Delete(new Customer() { Id = _code });
        }

        public void UpdateCustomer(Customer customer)
        {

            var crudFactory = new CustomerCrudFactory();
                crudFactory.Update(customer);
        }

        public Customer RetrieveById(string id)
        {
            var crudFactory = new CustomerCrudFactory();
            var customer = crudFactory.RetrieveById<Customer>(id);

            return customer;
        }

        public List<Customer> RetrieveAll()
        {
            var crudFactory = new CustomerCrudFactory();
            var LstCustomer = crudFactory.RetrieveAll<Customer>();

            return LstCustomer;
        }
    }    
}
