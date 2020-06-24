using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegralSoft.IntegralCFE.BusinessEntities
{
    public class Encabezado
    {
        public IDDoc IdDoc { get; set; }
        public Emisor Emisor { get; set; }
        public Receptor Receptor { get; set; }
        public Totales Totales { get; set; }
    }
}
