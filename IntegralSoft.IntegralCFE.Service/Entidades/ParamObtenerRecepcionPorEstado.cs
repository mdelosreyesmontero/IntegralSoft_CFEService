using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace IntegralSoft.IntegralCFE.Service
{
    [DataContract(Namespace = "http://IntegralSoft/IntegralCFEService/V001")]
    public class ParamObtenerRecepcionPorEstado
    {
        [DataMember]
        public string SecurityToken { get; set; }

        [DataMember]
        public string Condicion { get; set; }
    }
}