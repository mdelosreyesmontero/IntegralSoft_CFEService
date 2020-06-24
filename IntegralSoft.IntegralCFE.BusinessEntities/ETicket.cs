using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegralSoft.IntegralCFE.BusinessEntities
{
    public class ETicket
    {
        public Encabezado Encabezado { get; set; }
        public List<Item> Detalle { get; set; }
        public List<Referencia> Referencias { get; set; }
    }
}
