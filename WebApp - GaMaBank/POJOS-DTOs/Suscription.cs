using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POJOS_DTOs
{
    public class Suscription : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Owner { get; set; }

        public string BaseURL { get; set; }

        public string Code { get; set; }
    }
}
