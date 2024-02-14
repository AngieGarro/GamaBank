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
    public class CoinsController : ApiController
    {
        [HttpPost]
        public APIResponse Create(Coins coins)
        {
            try
            {
                var cm = new CoinsManager();
                cm.Create(coins);
                return new APIResponse()
                {
                    Status = "Ok",
                    Message = "Coins created"
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
        public APIResponse Update(Coins coins)
        {
            try
            {
                var cm = new CoinsManager();
                cm.UpdateCoins(coins);
                return new APIResponse()
                {
                    Status = "Ok",
                    Message = "Coins Update"
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
                var cm = new CoinsManager();
                cm.DeleteCoins(id);
                return new APIResponse()
                {
                    Status = "Ok",
                    Message = "Coins Delete"
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
                var cm = new CoinsManager();

                var coins = cm.RetrieveById(Id);
                return new APIResponse()
                {
                    Status = "Ok",
                    Data = coins
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
                var cm = new CoinsManager();

                var LstCoins = cm.RetrieveAll();
                return new APIResponse()
                {
                    Status = "Ok",
                    Data = LstCoins
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
