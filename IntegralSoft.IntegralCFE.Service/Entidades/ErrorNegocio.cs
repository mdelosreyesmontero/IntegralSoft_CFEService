using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace IntegralSoft.IntegralCFE.Service
{
    [DataContract(Namespace = "http://IntegralSoft/IntegralCFEService/V001")]
    public class ErrorNegocio
    {
        [DataMember]
        public int Codigo { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
    }
}
