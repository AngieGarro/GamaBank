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
    public class FintechController : ApiController
    {
        [HttpGet]
        public APIResponse RetrieveAllSuscriptor()
        {
            var sm = new SuscriptorManager();

            var ar = new APIResponse()
            {
                Data = sm.RetrieveAll(),
                Message = "OK",
                Status = "OK"
            };
            return ar;
        }
    }
}
