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
    public class ParamEnviarCFE
    {
        [DataMember]
        public string SecurityToken;

        [DataMember]
        public string SobreCFE { get; set; }

        [DataMember]
        public string EmailPDFDestinatario { get; set; }

        [DataMember]
        public string Adenda { get; set; }

    }
}
