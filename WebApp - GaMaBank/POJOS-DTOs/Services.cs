using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POJOS_DTOs
{
    public class Services
    {
        public DateTime ServiceDate { get; set; }
        public string ServiceName { get; set; }
        public String ServiceStatus { get; set; }

        public Services()
        {
            ServiceDate = DateTime.Now;
        }
    }
}
