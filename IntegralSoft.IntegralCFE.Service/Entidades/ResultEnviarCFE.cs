using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace IntegralSoft.IntegralCFE.Service
{
    [DataContract(Namespace = "http://IntegralSoft/IntegralCFEService/V001")]
    public class ResultEnviarCFE
    {
        [DataMember]
        public long IdResultCFE { get; set; }
        [DataMember]
        public ErrorNegocio Error { get; set; }
    }
}
