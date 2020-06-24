using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace IntegralSoft.IntegralCFE.Service.Entidades
{
    [DataContract(Namespace = "http://IntegralSoft/IntegralCFEService/V001")]
    public class DatosRecepcion
    {
        [DataMember]
        public long RecepcionId { get; set; }
        [DataMember]
        public int? CaeId { get; set; }
        [DataMember]
        public int? CAE { get; set; }
        [DataMember]
        public string Serie { get; set; }
        [DataMember]
        public int? NroComprobante { get; set; }
        [DataMember]
        public string Procesado { get; set; }
        [DataMember]
        public DateTime FechaGeneracion { get; set; }
        [DataMember]
        public int? FeMovimientoId { get; set; }
        [DataMember]
        public int? ReporteDiarioId { get; set; }
        [DataMember]
        public string SobreDGI { get; set; }
        [DataMember]
        public string SobreEmpresa { get; set; }
        [DataMember]
        public string SobreEmpresaProcesado { get; set; }
        [DataMember]
        public DateTime Fact { get; set; }
        [DataMember]
        public string Publicado { get; set; }
        [DataMember]
        public string Impreso { get; set; }
        [DataMember]
        public string Archivo { get; set; }
        [DataMember]
        public string CodigoSeguridad { get; set; }
        [DataMember]
        public string RE02 { get; set; }
        [DataMember]
        public string EnRegimen { get; set; }
        [DataMember]
        public string PublicadoWeb { get; set; }
        [DataMember]
        public string EmailPdfDest { get; set; }
    }
}