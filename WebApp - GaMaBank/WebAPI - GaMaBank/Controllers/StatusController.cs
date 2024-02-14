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
    public class StatusController : ApiController
    {
        [HttpGet]
        public string HealthCheck()
        {
            return "The API is running today at:" + DateTime.Now.ToString();
        }
    }
}
