using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegralSoft.IntegralCFE.DataAccess
{
    public class DalcCFE
    {
        protected string connetionString;

        public DalcCFE()
        {
            connetionString = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
        }

        public DataTable ObtenerRecepcionPorEstado(string condicion)
        {
            try
            {
                DataTable dtRetorno = new DataTable();

                using (SqlConnection cnn = new SqlConnection(connetionString))
                {
                    cnn.Open();

                    string sqlQuery = "  select feWsRecepcionid from feWSRecepcion where procesado = @procesado";

                    using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, cnn))
                    {

                        sqlCommand.Parameters.AddWithValue("@procesado", condicion);

                        using (SqlDataAdapter da = new SqlDataAdapter(sqlCommand))
                        {
                            da.Fill(dtRetorno);
                        }

                        cnn.Close();
                    }
                }

                return dtRetorno;
            }
            catch (Exception)
            {
                throw;
            }
        }



        public DataTable ObtenerDatosRecepcion(long recepcionId)
        {
            try
            {
                DataTable dtRetorno = new DataTable();

                using (SqlConnection cnn = new SqlConnection(connetionString))
                {
                    cnn.Open();

                    string sqlQuery = "  select * from feWSRecepcion where feWSRecepcionId = @feWSRecepcionId";

                    using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, cnn))
                    {

                        sqlCommand.Parameters.AddWithValue("@feWSRecepcionId", recepcionId);

                        using (SqlDataAdapter da = new SqlDataAdapter(sqlCommand))
                        {
                            da.Fill(dtRetorno);
                        }

                        cnn.Close();
                    }
                }

                return dtRetorno;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void GuardarEncabezadoIdDoc(long recepcionId, int? feMovimientoId, long? movimientoId,
            int codigoCausal, int formaPago, DateTime fechaDocumento, int indicadorTrasladoBienes,
            DateTime? periodoDesde, DateTime? periodoHasta, int indicadorMb, DateTime fechaVto,
            string descripcion, int? CAE, int codigoCfe, string serieCAE, int? nroComprobante,
            string clausulaVenta, int? modalidadVenta, int? viaTransporte)
        {
            try
            {


                string sqlQuery = "INSERT INTO FEWSENCABEZADOIDDOC (feWSRecepcionId,feMovimientoId,MovimientoId,CodigoSucursal,FormaPago,FechaDocumento,IndicadorTrasladoBienes,PeriodoDesde,PeriodoHasta,IndicadorMB,FechaVto,Descripcion,CAE,CodigoCFE,SerieCAE,NroComprobante,ClausulaVenta,ModalidadVenta,ViaTransporte) ";
                sqlQuery += "values (@feWSRecepcionId,@feMovimientoId,@MovimientoId,@CodigoSucursal,@FormaPago,@FechaDocumento,@IndicadorTrasladoBienes,@PeriodoDesde,@PeriodoHasta,@IndicadorMB,@FechaVto,@Descripcion,@CAE,@CodigoCFE,@SerieCAE,@NroComprobante,@ClausulaVenta,@ModalidadVenta,@ViaTransporte);";

                using (SqlConnection cnn = new SqlConnection(connetionString))
                {
                    cnn.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, cnn))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("feWSRecepcionId", recepcionId));
                        if (feMovimientoId.HasValue)
                        {
                            sqlCommand.Parameters.Add(new SqlParameter("feMovimientoId", feMovimientoId));
                        }
                        else
                        {
                            sqlCommand.Parameters.Add(new SqlParameter("feMovimientoId", DBNull.Value));
                        }

                        sqlCommand.Parameters.Add(new SqlParameter("MovimientoId", movimientoId));
                        sqlCommand.Parameters.Add(new SqlParameter("CodigoSucursal", codigoCausal));
                        sqlCommand.Parameters.Add(new SqlParameter("FormaPago", formaPago));
                        sqlCommand.Parameters.Add(new SqlParameter("FechaDocumento", fechaDocumento));
                        sqlCommand.Parameters.Add(new SqlParameter("IndicadorTrasladoBienes", indicadorTrasladoBienes));
                        if (periodoDesde.HasValue)
                        {
                            sqlCommand.Parameters.Add(new SqlParameter("PeriodoDesde", periodoDesde));
                        }
                        else
                        {
                            sqlCommand.Parameters.Add(new SqlParameter("PeriodoDesde", DBNull.Value));
                        }

                        if (periodoHasta.HasValue)
                        {
                            sqlCommand.Parameters.Add(new SqlParameter("PeriodoHasta", periodoHasta));
                        }
                        else
                        {
                            sqlCommand.Parameters.Add(new SqlParameter("PeriodoHasta", DBNull.Value));
                        }
                        sqlCommand.Parameters.Add(new SqlParameter("IndicadorMB", indicadorMb));
                        sqlCommand.Parameters.Add(new SqlParameter("FechaVto", fechaVto));
                        if (!String.IsNullOrEmpty(descripcion))
                        {
                            sqlCommand.Parameters.Add(new SqlParameter("Descripcion", descripcion));
                        }
                        else
                        {
                            sqlCommand.Parameters.Add(new SqlParameter("Descripcion", DBNull.Value));
                        }
                        if (CAE.HasValue)
                        {
                            sqlCommand.Parameters.Add(new SqlParameter("CAE", CAE));
                        }
                        else
                        {
                            sqlCommand.Parameters.Add(new SqlParameter("CAE", DBNull.Value));
                        }
                        sqlCommand.Parameters.Add(new SqlParameter("CodigoCFE", codigoCfe));
                        if (!String.IsNullOrEmpty(serieCAE))
                        {
                            sqlCommand.Parameters.Add(new SqlParameter("SerieCAE", serieCAE));
                        }
                        else
                        {
                            sqlCommand.Parameters.Add(new SqlParameter("SerieCAE", DBNull.Value));
                        }
                        if (nroComprobante.HasValue)
                        {
                            sqlCommand.Parameters.Add(new SqlParameter("NroComprobante", nroComprobante));
                        }
                        else
                        {
                            sqlCommand.Parameters.Add(new SqlParameter("NroComprobante", DBNull.Value));
                        }
                        if (!String.IsNullOrEmpty(clausulaVenta))
                        {
                            sqlCommand.Parameters.Add(new SqlParameter("ClausulaVenta", clausulaVenta));
                        }
                        else
                        {
                            sqlCommand.Parameters.Add(new SqlParameter("ClausulaVenta", DBNull.Value));
                        }
                        if (modalidadVenta.HasValue)
                        {
                            sqlCommand.Parameters.Add(new SqlParameter("ModalidadVenta", modalidadVenta));
                        }
                        else
                        {
                            sqlCommand.Parameters.Add(new SqlParameter("ModalidadVenta", DBNull.Value));
                        }

                        if (viaTransporte.HasValue)
                        {
                            sqlCommand.Parameters.Add(new SqlParameter("ViaTransporte", viaTransporte));
                        }
                        else
                        {
                            sqlCommand.Parameters.Add(new SqlParameter("ViaTransporte", DBNull.Value));
                        }

                        sqlCommand.ExecuteNonQuery();
                    }

                    cnn.Close();
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }


        public void GuardarEncabezadoReceptor(long recepcionId, int? feMovimientoId, long? movimientoId, string ruc, int codTipoDoc, string codPais, string numeroDoc, string nombre, string direccion, string ciudad, string departamento, string pais, int? codigoPostal, string infoAdicional, string lugarDeEntrega, int? IdCompra)
        {
            string sqlQuery = "INSERT INTO FEWSENCABEZADORECEPTOR (feWSRecepcionId,feMovimientoId,MovimientoId,Ruc,CodTipoDoc,CodPais,NumeroDoc,Nombre,Direccion,Ciudad,Departamento,Pais,CodigoPostal,InfoAdicional,LugarEntrega,IdCompra) ";
            sqlQuery += "VALUES (@feWSRecepcionId,@feMovimientoId,@MovimientoId,@Ruc,@CodTipoDoc,@CodPais,@NumeroDoc,@Nombre,@Direccion,@Ciudad,@Departamento,@Pais,@CodigoPostal,@InfoAdicional,@LugarEntrega,@IdCompra);";

            using (SqlConnection cnn = new SqlConnection(connetionString))
            {
                cnn.Open();

                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, cnn))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("feWSRecepcionId", recepcionId));
                    if (feMovimientoId.HasValue)
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("feMovimientoId", feMovimientoId));
                    }
                    else
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("feMovimientoId", DBNull.Value));
                    }
                    if (movimientoId.HasValue)
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("MovimientoId", movimientoId));
                    }
                    else
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("MovimientoId", DBNull.Value));
                    }
                    sqlCommand.Parameters.Add(new SqlParameter("Ruc", ruc));
                    sqlCommand.Parameters.Add(new SqlParameter("CodTipoDoc", codTipoDoc));
                    sqlCommand.Parameters.Add(new SqlParameter("CodPais", codPais));
                    sqlCommand.Parameters.Add(new SqlParameter("NumeroDoc", numeroDoc));
                    sqlCommand.Parameters.Add(new SqlParameter("Nombre", nombre));
                    sqlCommand.Parameters.Add(new SqlParameter("Direccion", direccion));
                    sqlCommand.Parameters.Add(new SqlParameter("Ciudad", ciudad));
                    sqlCommand.Parameters.Add(new SqlParameter("Departamento", departamento));
                    sqlCommand.Parameters.Add(new SqlParameter("Pais", pais));
                    if (codigoPostal.HasValue)
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("CodigoPostal", codigoPostal));
                    }
                    else
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("CodigoPostal", DBNull.Value));
                    }
                    if (!String.IsNullOrEmpty(infoAdicional))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("InfoAdicional", infoAdicional));
                    }
                    else
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("InfoAdicional", DBNull.Value));
                    }
                    if (!String.IsNullOrEmpty(lugarDeEntrega))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("LugarEntrega", lugarDeEntrega));
                    }
                    else
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("LugarEntrega", DBNull.Value));
                    }
                    if (IdCompra.HasValue)
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("IdCompra", IdCompra));
                    }
                    else
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("IdCompra", DBNull.Value));
                    }

                    sqlCommand.ExecuteNonQuery();
                }

                cnn.Close();
            }
        }

        public void GuardarEncabezadoTotales(long recepcionId, long? feMovimientoId, string codMoneda, double tipoCambio, double totalMontoNoGravado, double totalMontoExp, int totalMontoImpPercibido,
            double totalMontoIvaSuspenso, double totalMontoNetoIvaTMin, double totalMontoNetoIvaTBas, double totalMontoNetoIvaTOtra, int? codIva, double tasaIvaMin, double tasaIvaBas, double totalIvaMin, double totalIvaBas,
            double totalIvaOtra, double totalMontoTotal, double totalMontoPerRet, int cantLineas, double montoNoFacturable, double montoTotalPagar, int ajuste, int mayorDMilUI, double totalCreditosFisc)
        {
            string sqlQuery = "insert into feWSEncabezadoTotales (fewsrecepcionid,feMovimientoId, codmoneda, tipocambio, totalmontoNoGravado, TotalMontoExp, TotalMontoImpPercibido,TotalMontoIvaSuspenso,TotalMontoNetoIvaTMin,TotalMontoNetoIvaTBas,TotalMontoNetoIvaTOtra,CodIva,TasaIvaMin,TasaIvaBas,TotalIvaMin,TotalIvaBas,TotalIvaOtra,TotalMontoTotal,TotalMontoPerRet,CantLineas,MontoNoFacturable,MontoTotalPagar,Ajuste,MayorDMilUI,TotalCreditosFisc) ";
            sqlQuery += "VALUES (@fewsrecepcionid,@feMovimientoId, @codmoneda, @tipocambio, @totalmontoNoGravado, @TotalMontoExp, @TotalMontoImpPercibido,@TotalMontoIvaSuspenso," +
                "@TotalMontoNetoIvaTMin,@TotalMontoNetoIvaTBas,@TotalMontoNetoIvaTOtra,@CodIva,@TasaIvaMin,@TasaIvaBas,@TotalIvaMin,@TotalIvaBas,@TotalIvaOtra," +
                "@TotalMontoTotal,@TotalMontoPerRet,@CantLineas,@MontoNoFacturable,@MontoTotalPagar,@Ajuste,@MayorDMilUI,@TotalCreditosFisc );";

            using (SqlConnection cnn = new SqlConnection(connetionString))
            {
                cnn.Open();

                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, cnn))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("fewsrecepcionid", recepcionId));
                    if (feMovimientoId.HasValue)
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("feMovimientoId", feMovimientoId));
                    }
                    else
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("feMovimientoId", DBNull.Value));
                    }
                    sqlCommand.Parameters.Add(new SqlParameter("codmoneda", codMoneda));
                    sqlCommand.Parameters.Add(new SqlParameter("tipocambio", tipoCambio));
                    sqlCommand.Parameters.Add(new SqlParameter("totalmontoNoGravado", totalMontoNoGravado));
                    sqlCommand.Parameters.Add(new SqlParameter("TotalMontoExp", totalMontoExp));
                    sqlCommand.Parameters.Add(new SqlParameter("TotalMontoImpPercibido", totalMontoImpPercibido));
                    sqlCommand.Parameters.Add(new SqlParameter("TotalMontoIvaSuspenso", totalMontoIvaSuspenso));
                    sqlCommand.Parameters.Add(new SqlParameter("TotalMontoNetoIvaTMin", totalMontoNetoIvaTMin));
                    sqlCommand.Parameters.Add(new SqlParameter("TotalMontoNetoIvaTBas", totalMontoNetoIvaTBas));
                    sqlCommand.Parameters.Add(new SqlParameter("TotalMontoNetoIvaTOtra", totalMontoNetoIvaTOtra));
                    if (codIva.HasValue)
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("CodIva", codIva));
                    }
                    else
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("CodIva", DBNull.Value));
                    }
                    sqlCommand.Parameters.Add(new SqlParameter("TasaIvaMin", tasaIvaMin));
                    sqlCommand.Parameters.Add(new SqlParameter("TasaIvaBas", tasaIvaBas));
                    sqlCommand.Parameters.Add(new SqlParameter("TotalIvaMin", totalIvaMin));
                    sqlCommand.Parameters.Add(new SqlParameter("TotalIvaBas", totalIvaBas));
                    sqlCommand.Parameters.Add(new SqlParameter("TotalIvaOtra", totalIvaOtra));
                    sqlCommand.Parameters.Add(new SqlParameter("TotalMontoTotal", totalMontoTotal));
                    sqlCommand.Parameters.Add(new SqlParameter("TotalMontoPerRet", totalMontoPerRet));
                    sqlCommand.Parameters.Add(new SqlParameter("CantLineas", cantLineas));
                    sqlCommand.Parameters.Add(new SqlParameter("MontoNoFacturable", montoNoFacturable));
                    sqlCommand.Parameters.Add(new SqlParameter("MontoTotalPagar", montoTotalPagar));
                    sqlCommand.Parameters.Add(new SqlParameter("Ajuste", ajuste));
                    sqlCommand.Parameters.Add(new SqlParameter("MayorDMilUI", mayorDMilUI));
                    sqlCommand.Parameters.Add(new SqlParameter("TotalCreditosFisc", totalCreditosFisc));
                    sqlCommand.ExecuteNonQuery();
                }

                cnn.Close();
            }
        }

        public void GuardarDetalle(long recepcionId, long? feMovimientoId, int lineaId, string tipoCodItem, string codigoItem, int indicadorFacturacion, string nombreItem, string descripcionAdicional, double cantidad, string unidadMedida, double precioUnitario, int descuentoPorc, int montoDto, int recargoPorc, int montoRecargo, double montoItem, int? subTotalId)
        {
            string sqlQuery = "INSERT INTO FEWSDETALLE (fewsrecepcionid,feMovimientoId, LineaId,TipoCodItem,CodigoItem,IndicadorFacturacion,NombreItem,DescripcionAdicional,Cantidad,UnidadMedida,PrecioUnitario,DescuentoPorc,MontoDto,RecargoPorc,MontoRecargo,MontoItem,SubTotalId) ";
            sqlQuery += "VALUES (@fewsrecepcionid,@feMovimientoId, @LineaId,@TipoCodItem,@CodigoItem,@IndicadorFacturacion,@NombreItem,@DescripcionAdicional,@Cantidad,@UnidadMedida,@PrecioUnitario,@DescuentoPorc,@MontoDto,@RecargoPorc,@MontoRecargo,@MontoItem,@SubTotalId);";

            using (SqlConnection cnn = new SqlConnection(connetionString))
            {
                cnn.Open();

                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, cnn))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("fewsrecepcionid", recepcionId));
                    if (feMovimientoId.HasValue)
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("feMovimientoId", feMovimientoId));
                    }
                    else
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("feMovimientoId", DBNull.Value));
                    }
                    sqlCommand.Parameters.Add(new SqlParameter("LineaId", lineaId));
                    if (!String.IsNullOrEmpty(tipoCodItem))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("TipoCodItem", tipoCodItem));
                    }
                    else
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("TipoCodItem", DBNull.Value));
                    }

                    if (!String.IsNullOrEmpty(codigoItem))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("CodigoItem", codigoItem));
                    }
                    else
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("CodigoItem", DBNull.Value));
                    }
                    sqlCommand.Parameters.Add(new SqlParameter("IndicadorFacturacion", indicadorFacturacion));
                    sqlCommand.Parameters.Add(new SqlParameter("NombreItem", nombreItem));
                    if (!String.IsNullOrEmpty(descripcionAdicional))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("DescripcionAdicional", descripcionAdicional));
                    }
                    else
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("DescripcionAdicional", DBNull.Value));
                    }
                    sqlCommand.Parameters.Add(new SqlParameter("Cantidad", cantidad));
                    sqlCommand.Parameters.Add(new SqlParameter("UnidadMedida", unidadMedida));
                    sqlCommand.Parameters.Add(new SqlParameter("PrecioUnitario", precioUnitario));
                    sqlCommand.Parameters.Add(new SqlParameter("DescuentoPorc", descuentoPorc));
                    sqlCommand.Parameters.Add(new SqlParameter("MontoDto", montoDto));
                    sqlCommand.Parameters.Add(new SqlParameter("RecargoPorc", recargoPorc));
                    sqlCommand.Parameters.Add(new SqlParameter("MontoRecargo", montoRecargo));
                    sqlCommand.Parameters.Add(new SqlParameter("MontoItem", montoItem));
                    if (subTotalId.HasValue)
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("SubTotalId", subTotalId));
                    }
                    else
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("SubTotalId", DBNull.Value));
                    }

                    sqlCommand.ExecuteNonQuery();
                }

                cnn.Close();
            }
        }

        public void GuardarReferencia(long recepcionid, long? feMovimientoId, int nroLinRef, int indicadorGlobalRef, string CAE, int codigoCFE, string serieCAE, int nroComprobante, int? movimientoIdRef, string referencia, DateTime fechaDocumento)
        {
            string sqlQuery = "INSERT INTO FEWSINFOREFERENCIA (fewsrecepcionid,feMovimientoId, NroLinRef, IndicadorGlobalRef,CAE,CodigoCFE,SerieCAE,NroComprobante,MovimientoIdRef,Referencia,FechaDocumento) ";
            sqlQuery += "VALUES (@fewsrecepcionid, @feMovimientoId, @NroLinRef, @IndicadorGlobalRef,@CAE,@CodigoCFE,@SerieCAE,@NroComprobante,@MovimientoIdRef,@Referencia,@FechaDocumento);";

            using (SqlConnection cnn = new SqlConnection(connetionString))
            {
                cnn.Open();

                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, cnn))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("fewsrecepcionid", recepcionid));
                    if (feMovimientoId.HasValue)
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("feMovimientoId", feMovimientoId));
                    }
                    else
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("feMovimientoId", DBNull.Value));
                    }
                    sqlCommand.Parameters.Add(new SqlParameter("NroLinRef", nroLinRef));
                    sqlCommand.Parameters.Add(new SqlParameter("IndicadorGlobalRef", indicadorGlobalRef));
                    if (!String.IsNullOrEmpty(CAE))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("CAE", CAE));
                    }
                    else
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("CAE", DBNull.Value));
                    }
                    sqlCommand.Parameters.Add(new SqlParameter("CodigoCFE", codigoCFE));
                    sqlCommand.Parameters.Add(new SqlParameter("SerieCAE", serieCAE));
                    sqlCommand.Parameters.Add(new SqlParameter("NroComprobante", nroComprobante));
                    if (movimientoIdRef.HasValue)
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("MovimientoIdRef", movimientoIdRef));
                    }
                    else
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("MovimientoIdRef", DBNull.Value));
                    }
                    if (!String.IsNullOrEmpty(referencia))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("Referencia", referencia));
                    }
                    else
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("Referencia", DBNull.Value));
                    }
                    sqlCommand.Parameters.Add(new SqlParameter("FechaDocumento", fechaDocumento));

                    sqlCommand.ExecuteNonQuery();
                }

                cnn.Close();
            }
        }

        public void GuardarAgenda(long recepcionid, string adenda)
        {
            string sqlQuery = "insert into feWSAdenda (fewsrecepcionid, ObservacionFact) ";
            sqlQuery += "values (@fewsrecepcionid,@ObservacionFact);";

            using (SqlConnection cnn = new SqlConnection(connetionString))
            {
                cnn.Open();

                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, cnn))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("fewsrecepcionid", recepcionid));
                    sqlCommand.Parameters.Add(new SqlParameter("ObservacionFact", adenda));

                    sqlCommand.ExecuteNonQuery();
                }

                cnn.Close();
            }
        }

        public long GuardarRecepcion(string destinatarioEmail, string procesado)
        {
            long recepcionId = long.MinValue;

            string sqlQuery = "INSERT INTO FEWSRECEPCION (FECHAGENERACION,FACT,PROCESADO, EMAILPDFDEST) ";
            sqlQuery += "VALUES (getdate(), getdate(), @procesado, @paramMail); SELECT SCOPE_IDENTITY(); ";

            using (SqlConnection cnn = new SqlConnection(connetionString))
            {
                cnn.Open();

                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, cnn))
                {
                    if (!String.IsNullOrEmpty(destinatarioEmail))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("paramMail", destinatarioEmail));
                    }
                    else
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("paramMail", DBNull.Value));
                    }


                    if (!String.IsNullOrEmpty(procesado))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("procesado", procesado));
                    }
                    else
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("procesado", DBNull.Value));
                    }

                    recepcionId = (long)(decimal)sqlCommand.ExecuteScalar();
                }

                cnn.Close();
            }

            return recepcionId;
        }
    }
}
