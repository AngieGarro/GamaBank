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
    public class AccountController : ApiController
    {
        [HttpPost]
        public APIResponse Create(Account account)
        {
            try
            {
                var cm = new AccountManager();
                cm.Create(account);
                return new APIResponse()
                {
                    Status = "Ok",
                    Message = "Account created"
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
        public APIResponse Update(Account account)
        {
            try
            {
                var cm = new AccountManager();
                cm.UpdateAccount(account);
                return new APIResponse()
                {
                    Status = "Ok",
                    Message = "Account Update"
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
                var cm = new AccountManager();
                cm.DeleteAccount(id);
                return new APIResponse()
                {
                    Status = "Ok",
                    Message = "Account Delete"
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
                var cm = new AccountManager();

                var account = cm.RetrieveById(id);
                return new APIResponse()
                {
                    Status = "Ok",
                    Data = account
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
                var cm = new AccountManager();

                var LstAccounts = cm.RetrieveAll();
                return new APIResponse()
                {
                    Status = "Ok",
                    Data = LstAccounts
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
