using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegralSoft.IntegralCFE.BusinessEntities
{
    public class Item
    {
        public int NroLinDet { get; set; }
        public int IndFact { get; set; }
        public string NomItem { get; set; }
        public double Cantidad { get; set; }
        public string UniMed { get; set; }
        public double PrecioUnitario { get; set; }
        public double MontoItem { get; set; }
    }
}
