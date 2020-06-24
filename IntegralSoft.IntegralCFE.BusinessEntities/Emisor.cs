using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegralSoft.IntegralCFE.BusinessEntities
{
    public class Emisor
    {
        public string RUCEmisor { get; set; }
        public string RznSoc { get; set; }
        public int CdgDGISucur { get; set; }
        public string DomFiscal { get; set; }
        public string Ciudad { get; set; }
        public string Departamento { get; set; }
    }
}
