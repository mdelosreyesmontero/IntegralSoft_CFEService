using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace IntegralSoft.IntegralCFE.Service
{
    [DataContract(Namespace = "http://IntegralSoft/IntegralCFEService/V001")]
    public class ResultObtenerRecepcionPorEstado
    {
        [DataMember]
        public List<long> RecepcionIDs { get; set; }
        [DataMember]
        public ErrorNegocio Error { get; set; }

    }
}