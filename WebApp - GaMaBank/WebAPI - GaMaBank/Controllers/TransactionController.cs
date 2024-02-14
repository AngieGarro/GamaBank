using AppCore_Logic.Managers;
using POJOS_DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI___GaMaBank.Controllers
{
    public class TransactionController : ApiController
    {

        [HttpPost]
        public APIResponse Create(Transaction trans)
        {
            try
            {
                var cm = new TransactionManager();
                cm.Create(trans);
                return new APIResponse()
                {
                    Status = "Ok",
                    Message = "Create Transacction"
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
        public APIResponse RetriveById(string Id)
        {
            try
            {
                var cm = new TransactionManager();

                var trans = cm.RetrieveById(Id);
                return new APIResponse()
                {
                    Status = "Ok",
                    Data = trans
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
                var cm = new TransactionManager();

                var LstTransc = cm.RetrieveAll();
                return new APIResponse()
                {
                    Status = "Ok",
                    Data = LstTransc
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
