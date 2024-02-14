using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POJOS_DTOs
{
    public class Coins : BaseEntity
    {
        public string Id { get; set; }

        public string Name { get; set; } //CenfoGaMa - CenfoCoins
        public string FintechCode { get; set; }
        public string ExchangePrice { get; set; }
    }
}
