using IntegralSoft.IntegralCFE.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml;
using System.Xml.Linq;

namespace IntegralSoft.IntegralCFE.BusinessLogic
{
    public class AdmCFE
    {
        public Recepcion ObtenerDatosRecepcion(long recepcionId)
        {
            DataTable dt = null;
            DataAccess.DalcCFE db = new DataAccess.DalcCFE();
            Recepcion retorno = null;

            dt = db.ObtenerDatosRecepcion(recepcionId);

            if (dt.Rows.Count > 0)
            {
                //Convierto la entitdad
                retorno = ConvertToRecepcionEntity(dt);
            }

            return retorno;
        }

        public List<long> ObtenerRecepcionPorEstado(string condicion)
        {
            DataTable dt = null;
            DataAccess.DalcCFE db = new DataAccess.DalcCFE();
            List<long> retorno = null;

            dt = db.ObtenerRecepcionPorEstado(condicion);

            if (dt.Rows.Count > 0)
            {
                //Convierto la entitdad
                retorno = ConvertToRecepcionIdEntity(dt);
            }

            return retorno;
        }

        private List<long> ConvertToRecepcionIdEntity(DataTable dt)
        {
            List<long> retorno = new List<long>();

            foreach (DataRow row in dt.Rows)
            {
                retorno.Add(Convert.ToInt64(row["feWSRecepcionId"]));
            }

            return retorno;
        }
        private Recepcion ConvertToRecepcionEntity(DataTable dt)
        {
            Recepcion retorno = new Recepcion();
            retorno.RecepcionId = Convert.ToInt64(dt.Rows[0]["feWSRecepcionId"]);
            if (dt.Rows[0]["CaeId"] != DBNull.Value)
            {
                retorno.CaeId = Convert.ToInt32(dt.Rows[0]["CaeId"]);
            }
            if (dt.Rows[0]["CAE"] != DBNull.Value)
            {
                retorno.CAE = Convert.ToInt32(dt.Rows[0]["CAE"]);
            }

            if (dt.Rows[0]["Serie"] != DBNull.Value)
            {
                retorno.Serie = dt.Rows[0]["Serie"].ToString();
            }

            if (dt.Rows[0]["NroComprobante"] != DBNull.Value)
            {
                retorno.NroComprobante = Convert.ToInt32(dt.Rows[0]["NroComprobante"]);
            }

            if (dt.Rows[0]["Procesado"] != DBNull.Value)
            {
                retorno.Procesado = dt.Rows[0]["Procesado"].ToString();
            }

            if (dt.Rows[0]["FechaGeneracion"] != DBNull.Value)
            {
                retorno.FechaGeneracion = Convert.ToDateTime(dt.Rows[0]["FechaGeneracion"]);
            }

            if (dt.Rows[0]["feMovimientoId"] != DBNull.Value)
            {
                retorno.FeMovimientoId = Convert.ToInt32(dt.Rows[0]["feMovimientoId"]);
            }

            if (dt.Rows[0]["ReporteDiarioId"] != DBNull.Value)
            {
                retorno.ReporteDiarioId = Convert.ToInt32(dt.Rows[0]["ReporteDiarioId"]);
            }

            if (dt.Rows[0]["SobreDGI"] != DBNull.Value)
            {
                retorno.SobreDGI = dt.Rows[0]["SobreDGI"].ToString();
            }

            if (dt.Rows[0]["SobreEmpresa"] != DBNull.Value)
            {
                retorno.SobreEmpresa = dt.Rows[0]["SobreEmpresa"].ToString();
            }

            if (dt.Rows[0]["SobreEmpresaProcesado"] != DBNull.Value)
            {
                retorno.SobreEmpresaProcesado = dt.Rows[0]["SobreEmpresaProcesado"].ToString();
            }

            if (dt.Rows[0]["Fact"] != DBNull.Value)
            {
                retorno.Fact = Convert.ToDateTime(dt.Rows[0]["Fact"]);
            }

            if (dt.Rows[0]["Publicado"] != DBNull.Value)
            {
                retorno.Publicado = dt.Rows[0]["Publicado"].ToString();
            }

            if (dt.Rows[0]["Impreso"] != DBNull.Value)
            {
                retorno.Impreso = dt.Rows[0]["Impreso"].ToString();
            }

            if (dt.Rows[0]["Archivo"] != DBNull.Value)
            {
                retorno.Archivo = dt.Rows[0]["Archivo"].ToString();
            }

            if (dt.Rows[0]["Archivo"] != DBNull.Value)
            {
                retorno.Archivo = dt.Rows[0]["Archivo"].ToString();
            }

            if (dt.Rows[0]["codigoSeguridad"] != DBNull.Value)
            {
                retorno.CodigoSeguridad = dt.Rows[0]["codigoSeguridad"].ToString();
            }

            if (dt.Rows[0]["RE02"] != DBNull.Value)
            {
                retorno.RE02 = dt.Rows[0]["RE02"].ToString();
            }

            if (dt.Rows[0]["EnRegimen"] != DBNull.Value)
            {
                retorno.EnRegimen = dt.Rows[0]["EnRegimen"].ToString();
            }

            if (dt.Rows[0]["PublicadoWeb"] != DBNull.Value)
            {
                retorno.PublicadoWeb = dt.Rows[0]["PublicadoWeb"].ToString();
            }

            if (dt.Rows[0]["EMailPDFDest"] != DBNull.Value)
            {
                retorno.EmailPdfDest = dt.Rows[0]["EMailPDFDest"].ToString();
            }

            return retorno;
        }

        public ResultGuardarTicket GuardarSobreCFEXML(string sobreCFE, string destinatarioEmail, string adenda)
        {
            string ruc = "";
            DataAccess.DalcCFE db = new DataAccess.DalcCFE();
            long recepcionId = long.MinValue;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(sobreCFE);
            ResultGuardarTicket retorno = new ResultGuardarTicket();
            ErrorNegocio error = null;

            //Convierto el XML en una entidad
            ETicket ticket = new ETicket();
            ticket.Encabezado = this.ConvertToEncabezado(xmlDoc);
            ticket.Detalle = this.ConvertToDetalle(xmlDoc);
            ticket.Referencias = this.ConvertToReferencia(xmlDoc);

            try
            {
                //## INICIO - Aplico las validaciones de negocio ##
                error = this.ValidarDatosTicket(ticket);

                if (error != null)
                {
                    retorno.Error = error;
                    return retorno;
                }
                //## FIN - Aplico las validaciones de negocio ##

                using (TransactionScope scope = new TransactionScope())
                {
                    //Guardo la Recepcion
                    recepcionId = db.GuardarRecepcion(destinatarioEmail, "N");

                    //Guardo el encabezado IdDoc
                    db.GuardarEncabezadoIdDoc(recepcionId, null, recepcionId, ticket.Encabezado.Emisor.CdgDGISucur, ticket.Encabezado.IdDoc.FmaPago,
                        ticket.Encabezado.IdDoc.FchEmis, 1, null, null, 0, ticket.Encabezado.IdDoc.FchEmis, null, null, ticket.Encabezado.IdDoc.TipoCFE,
                        null, null, null, null, null);

                    if (ticket.Encabezado.Receptor.TipoDocRecep.Equals(3))
                    {
                        ruc = ticket.Encabezado.Receptor.DocRecep;
                    }
                    else
                    {
                        ruc = ticket.Encabezado.Receptor.DocRecepExt;
                    }

                    //Guardo el Receptor
                    db.GuardarEncabezadoReceptor(recepcionId, null, recepcionId, ruc, ticket.Encabezado.Receptor.TipoDocRecep, ticket.Encabezado.Receptor.CodPaisRecep,
                        ruc, ticket.Encabezado.Receptor.RznSocRecep, ticket.Encabezado.Receptor.DirRecep, ticket.Encabezado.Receptor.CiudadRecep, String.Empty, String.Empty, null, null, null, null);

                    //Guardo los totales
                    db.GuardarEncabezadoTotales(recepcionId, null, ticket.Encabezado.Totales.TpoMoneda, ticket.Encabezado.Totales.TpoCambio, ticket.Encabezado.Totales.MntNoGrv, 0, 0, 0, ticket.Encabezado.Totales.MntNetoIvaTasaMin,
                        ticket.Encabezado.Totales.MntNetoIVATasaBasica, 0, null, ticket.Encabezado.Totales.IVATasaMin, ticket.Encabezado.Totales.IVATasaBasica, ticket.Encabezado.Totales.MntIVATasaMin, ticket.Encabezado.Totales.MntIVATasaBasica,
                        0, ticket.Encabezado.Totales.MntTotal, 0, ticket.Encabezado.Totales.CantLinDet, 0, ticket.Encabezado.Totales.MntPagar, 0, 0, 0);

                    //Guardo el detalle de la factura
                    if (ticket.Detalle != null && ticket.Detalle.Any())
                    {
                        foreach (Item item in ticket.Detalle)
                        {
                            db.GuardarDetalle(recepcionId, null, item.NroLinDet, null, null, item.IndFact, item.NomItem, null, item.Cantidad, item.UniMed, item.PrecioUnitario, 0, 0, 0, 0, item.MontoItem, null);
                        }
                    }

                    //Guardo la referencia
                    if (ticket.Referencias != null && ticket.Referencias.Any())
                    {
                        foreach (Referencia r in ticket.Referencias)
                        {
                            db.GuardarReferencia(recepcionId, null, r.NroLinRef, 1, null, r.TpoDocRef, r.Serie, r.NroCFERef, null, null, r.FechaCFEref);
                        }
                    }

                    //Guardo adenda
                    db.GuardarAgenda(recepcionId, adenda);

                    //Asigno la variable para retornarla
                    retorno.RecepcionId = recepcionId;

                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return retorno;
        }


        private ErrorNegocio ValidarDatosTicket(ETicket ticket)
        {
            ErrorNegocio retorno = null;

            if (ticket.Encabezado.IdDoc.FchEmis.Date >= DateTime.Now.Date)
            {
                retorno = new ErrorNegocio() { Descripcion = "La fecha de emisión no puede ser mayor a la fecha actual" };
                return retorno;
            }

            if (String.IsNullOrEmpty(ticket.Encabezado.Emisor.RUCEmisor) || ticket.Encabezado.Emisor.RUCEmisor.Length < 4)
            {
                retorno = new ErrorNegocio() { Descripcion = "Ruc inválido " + ticket.Encabezado.Emisor.RUCEmisor };
                return retorno;
            }

            return retorno;
        }


        public Encabezado ConvertToEncabezado(XmlDocument xmlDoc)
        {
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(xmlDoc.NameTable);
            nsmgr.AddNamespace("app", "http://cfe.dgi.gub.uy");
            Encabezado retorno = new Encabezado();
            XmlNode node = null;

            //IdDoc
            node = xmlDoc.SelectSingleNode("//app:IdDoc", nsmgr);
            if (node != null)
            {
                retorno.IdDoc = new IDDoc();
                retorno.IdDoc.TipoCFE = Convert.ToInt32(node["TipoCFE"].InnerText);
                retorno.IdDoc.FchEmis = Convert.ToDateTime(node["FchEmis"].InnerText);
                retorno.IdDoc.FmaPago = Convert.ToInt32(node["FmaPago"].InnerText);
            }

            //Emisor
            node = xmlDoc.SelectSingleNode("//app:Emisor", nsmgr);
            if (node != null)
            {
                retorno.Emisor = new Emisor();
                retorno.Emisor.RUCEmisor = node["RUCEmisor"].InnerText;
                retorno.Emisor.RznSoc = node["RznSoc"].InnerText;
                retorno.Emisor.CdgDGISucur = Convert.ToInt32(node["CdgDGISucur"].InnerText);
                retorno.Emisor.DomFiscal = node["DomFiscal"].InnerText;
                retorno.Emisor.Ciudad = node["Ciudad"].InnerText;
                retorno.Emisor.Departamento = node["Departamento"].InnerText;
            }

            //Receptor
            node = xmlDoc.SelectSingleNode("//app:Receptor", nsmgr);
            if (node != null)
            {
                retorno.Receptor = new Receptor();
                retorno.Receptor.TipoDocRecep = Convert.ToInt32(node["TipoDocRecep"].InnerText);
                retorno.Receptor.CodPaisRecep = node["CodPaisRecep"].InnerText;
                if (node["DocRecepExt"] != null)
                {
                    retorno.Receptor.DocRecepExt = node["DocRecepExt"].InnerText;
                }
                if (node["DocRecep"] != null)
                {
                    retorno.Receptor.DocRecep = node["DocRecep"].InnerText;
                }
                retorno.Receptor.RznSocRecep = node["RznSocRecep"].InnerText;
                retorno.Receptor.DirRecep = node["DirRecep"].InnerText;
                retorno.Receptor.CiudadRecep = node["CiudadRecep"].InnerText;
            }

            //Totales
            node = xmlDoc.SelectSingleNode("//app:Totales", nsmgr);
            if (node != null)
            {
                retorno.Totales = new Totales();
                retorno.Totales.TpoMoneda = node["TpoMoneda"].InnerText;
                retorno.Totales.TpoCambio = double.Parse(node["TpoCambio"].InnerText, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo);
                retorno.Totales.MntNoGrv = double.Parse(node["MntNoGrv"].InnerText, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo);
                retorno.Totales.MntNetoIvaTasaMin = double.Parse(node["MntNetoIvaTasaMin"].InnerText, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo);
                retorno.Totales.MntNetoIVATasaBasica = double.Parse(node["MntNetoIVATasaBasica"].InnerText, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo);
                retorno.Totales.IVATasaMin = double.Parse(node["IVATasaMin"].InnerText, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo);
                retorno.Totales.IVATasaBasica = double.Parse(node["IVATasaBasica"].InnerText, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo);
                retorno.Totales.MntIVATasaMin = double.Parse(node["MntIVATasaMin"].InnerText, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo);
                retorno.Totales.MntIVATasaBasica = double.Parse(node["MntIVATasaBasica"].InnerText, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo);
                retorno.Totales.MntTotal = double.Parse(node["MntTotal"].InnerText, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo);
                retorno.Totales.CantLinDet = Convert.ToInt32(node["CantLinDet"].InnerText);
                retorno.Totales.MntPagar = double.Parse(node["MntPagar"].InnerText, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo);
            }

            return retorno;
        }

        public List<Item> ConvertToDetalle(XmlDocument xmlDoc)
        {
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(xmlDoc.NameTable);
            nsmgr.AddNamespace("app", "http://cfe.dgi.gub.uy");
            XmlNodeList node = null;
            List<Item> retorno = new List<Item>();
            Item item = null;

            //Item
            node = xmlDoc.SelectNodes("//app:Item", nsmgr);

            if (node != null)
            {
                foreach (XmlNode n in node)
                {
                    item = new Item();
                    item.MontoItem = double.Parse(n["MontoItem"].InnerText, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo);
                    item.PrecioUnitario = double.Parse(n["PrecioUnitario"].InnerText, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo);
                    item.UniMed = n["UniMed"].InnerText;
                    item.NroLinDet = Convert.ToInt32(n["NroLinDet"].InnerText);
                    item.IndFact = Convert.ToInt32(n["IndFact"].InnerText);
                    item.NomItem = n["NomItem"].InnerText;
                    item.Cantidad = double.Parse(n["Cantidad"].InnerText, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo); ;

                    retorno.Add(item);
                }
            }

            return retorno;
        }

        public List<Referencia> ConvertToReferencia(XmlDocument xmlDoc)
        {
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(xmlDoc.NameTable);
            nsmgr.AddNamespace("app", "http://cfe.dgi.gub.uy");
            XmlNodeList node = null;
            List<Referencia> retorno = new List<Referencia>();
            Referencia referencia = null;

            //Referencia
            node = xmlDoc.SelectNodes("//app:Referencia", nsmgr);

            if (node != null)
            {
                foreach (XmlNode n in node)
                {
                    foreach (XmlNode r in n.ChildNodes)
                    {
                        if (r.Name.Equals("Referencia"))
                        {
                            referencia = new Referencia();
                            referencia.NroLinRef = Convert.ToInt32(r["NroLinRef"].InnerText);
                            referencia.TpoDocRef = Convert.ToInt32(r["TpoDocRef"].InnerText);
                            referencia.Serie = r["Serie"].InnerText;
                            referencia.NroCFERef = Convert.ToInt32(r["NroCFERef"].InnerText);
                            referencia.FechaCFEref = Convert.ToDateTime(r["FechaCFEref"].InnerText);

                            retorno.Add(referencia);
                        }
                    }
                }
            }

            return retorno;
        }

    }
}
