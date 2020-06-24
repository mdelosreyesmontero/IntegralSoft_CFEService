using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WinAppClient
{
    public partial class frmPrincipal : Form
    {
        private string xmlCfe = "";
        private string fileNameCfe = "";

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(xmlCfe))
            {
                txtConsola.Text += "Debe cargar un xml para enviar" + Environment.NewLine;
                return;
            }

            wsCFEService.ServiceFacadeClient client = new wsCFEService.ServiceFacadeClient();
            wsCFEService.ParamEnviarCFE param = new wsCFEService.ParamEnviarCFE();
            param.SobreCFE = xmlCfe;
            param.SecurityToken = "CFE_USR-4543411265897360-061711-972067297a70a8294ff21672fe8b00d6-211542200013";
            param.Adenda = "Adenda";
            param.EmailPDFDestinatario = "mail@mail.com";

            try
            {
                var response = client.EnviarCFE(param);

                txtConsola.Text += "Xml " + fileNameCfe + " Enviado correctamente " + response.IdResultCFE + Environment.NewLine;
            }
            catch (Exception ex)
            {
                txtConsola.Text += "Ocurrio un error " + ex.Message + Environment.NewLine;
            }
        }

        private void btnCargarXml_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            DialogResult result = dialog.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = dialog.FileName;
                fileNameCfe = Path.GetFileName(file);
                XmlDocument doc = new XmlDocument();
                doc.Load(file);

                lblXml.Text = file;

                xmlCfe = doc.InnerXml;
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtRecepcionId.Text))
            {
                txtConsola.Text += "Debe ingresar RecepcionId" + Environment.NewLine;
                return;
            }

            wsCFEService.ServiceFacadeClient client = new wsCFEService.ServiceFacadeClient();
            wsCFEService.ParamConsultarCFE param = new wsCFEService.ParamConsultarCFE();
            wsCFEService.ResultConsultarCFE result = null;
            param.RecepcionId = Convert.ToInt64(txtRecepcionId.Text.Trim());
            param.SecurityToken = "CFE_USR-4543411265897360-061711-972067297a70a8294ff21672fe8b00d6-211542200013";

            result = client.ConsultarCFE(param);

            if (result.DatosRecepcion != null)
            {
                StringBuilder str = new StringBuilder();
                str.AppendLine("RecepcionId: " + result.DatosRecepcion.RecepcionId);
                str.AppendLine("Publicado: " + result.DatosRecepcion.Publicado);
                str.AppendLine("PublicadoWeb: " + result.DatosRecepcion.PublicadoWeb);
                str.AppendLine("FechaGeneracion: " + result.DatosRecepcion.FechaGeneracion);
                str.AppendLine("CAE: " + result.DatosRecepcion.CAE);
                str.AppendLine("CaeId: " + result.DatosRecepcion.CaeId);
                str.AppendLine("CodigoSeguridad: " + result.DatosRecepcion.CodigoSeguridad);
                str.AppendLine("NroComprobante: " + result.DatosRecepcion.NroComprobante);
                str.AppendLine("SobreDGI: " + result.DatosRecepcion.SobreDGI);
                str.AppendLine("SobreEmpresa: " + result.DatosRecepcion.SobreEmpresa);
                str.AppendLine("SobreEmpresaProcesado: " + result.DatosRecepcion.SobreEmpresaProcesado);
                str.AppendLine("EnRegimen: " + result.DatosRecepcion.EnRegimen);
                str.AppendLine("Impreso: " + result.DatosRecepcion.Impreso);

                txtDatosRecepcion.Text = str.ToString();
            }
        }

        private void btnConsultarPorEstado_Click(object sender, EventArgs e)
        {
            wsCFEService.ServiceFacadeClient client = new wsCFEService.ServiceFacadeClient();
            wsCFEService.ParamObtenerRecepcionPorEstado param = new wsCFEService.ParamObtenerRecepcionPorEstado();
            wsCFEService.ResultObtenerRecepcionPorEstado result = null;
            param.Condicion = txtEstado.Text.Trim();
            param.SecurityToken = "CFE_USR-4543411265897360-061711-972067297a70a8294ff21672fe8b00d6-211542200013";

            result = client.ObtenerRecepcionPorEstado(param);

            if (result.RecepcionIDs != null && result.RecepcionIDs.Any())
            {
                StringBuilder str = new StringBuilder();
                str.AppendLine("Los identificadores con el estado son: ");
                foreach (long id in result.RecepcionIDs)
                {
                    str.AppendLine(id.ToString());
                }

                txtConsola.Text += str.ToString();
            }
            else
            {
                txtConsola.Text += "No se encontraron datos para el estado ingresado" + Environment.NewLine;
            }

        }
    }
}

