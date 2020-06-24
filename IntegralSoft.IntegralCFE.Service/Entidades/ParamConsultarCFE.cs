using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace IntegralSoft.IntegralCFE.Service
{
    [DataContract(Namespace = "http://IntegralSoft/IntegralCFEService/V001")]
    public class ParamConsultarCFE
    {
        [DataMember]
        public string SecurityToken { get; set; }

        [DataMember]
        public long RecepcionId { get; set; }
    }
}
