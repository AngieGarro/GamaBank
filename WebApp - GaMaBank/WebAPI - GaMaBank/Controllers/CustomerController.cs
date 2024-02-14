using AppCore_Logic;
using POJOS_DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI___GaMaBank.Controllers
{
    public class CustomerController : ApiController
    {

        [HttpPost]
        public APIResponse Create(Customer customer)
        {
            try
            {
                var cm = new CustomerManager();
                cm.Create(customer);
                return new APIResponse()
                {
                    Status = "Ok",
                    Message = "Customer created"
                };
            }
            catch (Exception ex)
            {
                return new APIResponse()
                {
                    Status = "Error",
                    Message = ex.Message
                };
            }
        }

        [HttpPut]
        public APIResponse Update(Customer customer)
        {
            try
            {
                var cm = new CustomerManager();
                cm.UpdateCustomer(customer);
                return new APIResponse()
                {
                    Status = "Ok",
                    Message = "Customer Update"
                };
            }
            catch (Exception ex)
            {
                return new APIResponse()
                {
                    Status = "Error",
                    Message = ex.Message
                };
            }

        }

        [HttpDelete]
        public APIResponse Delete(string id)
        {
            try
            {
                var cm = new CustomerManager();
                cm.DeleteCustomer(id);
                return new APIResponse()
                {
                    Status = "Ok",
                    Message = "Customer Delete"
                };
            }
            catch (Exception ex)
            {
                return new APIResponse()
                {
                    Status = "Error",
                    Message = ex.Message
                };
            }
        }

        [HttpGet]
        public APIResponse RetriveById(string id)
        {
            try
            {
                var cm = new CustomerManager();

                var customer = cm.RetrieveById(id);
                return new APIResponse()
                {
                    Status = "Ok",
                    Data = customer
                };
            }
            catch (Exception ex)
            {
                return new APIResponse()
                {
                    Status = "Error",
                    Message = ex.Message
                };
            }

        }
   
        [HttpGet]
        public APIResponse RetrieveAll()
        {
            try
            {
                var cm = new CustomerManager();

                var LstCustomer = cm.RetrieveAll();
                return new APIResponse()
                {
                    Status = "Ok",
                    Data = LstCustomer
                };
            }
            catch (Exception ex)
            {
                return new APIResponse()
                {
                    Status = "Error",
                    Message = ex.Message
                };
            }
        }
    }
}
