using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POJOS_DTOs
{
    public class Transaction : BaseEntity
    {
        public string Id { get; set; }
        public string Amount { get; set; }
        public string Type { get; set; }

        //CUENTA DE DONDE SE HACE LA TRANSACCION
        public string AccountUBAN { get; set; }

        //CUENTA PARA LA QUE SE VA A HACER LA TRANSACCION
        public string FintechUBAN { get; set; }

    }
}
