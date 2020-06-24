using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace IntegralSoft.IntegralCFE.Service
{
    [ServiceContract(Namespace = "http://IntegralSoft/IntegralCFEService/V001")]

    public interface IServiceFacade
    {
        [OperationContract]
        ResultEnviarCFE EnviarCFE(ParamEnviarCFE param);

        [OperationContract]
        ResultConsultarCFE ConsultarCFE(ParamConsultarCFE param);

        [OperationContract]
        ResultObtenerRecepcionPorEstado ObtenerRecepcionPorEstado(ParamObtenerRecepcionPorEstado param);
    }
}
