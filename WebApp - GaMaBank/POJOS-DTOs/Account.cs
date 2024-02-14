using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POJOS_DTOs
{
    public class Account : BaseEntity
    {
        public string UBAN { get; set; }

        public string AccountName { get; set; }
        public string CustomerId { get; set; }

        public string CoinCode { get; set; }

        public string Status { get; set; }
       

    }
}
