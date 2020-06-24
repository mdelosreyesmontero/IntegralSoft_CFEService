--EJ: XML_UFCE_EJ_1.xml
--*******************************************************************************************************--------
--recepcion sin nro de CFE, lo asigna luego el sistema de CFE
insert into feWSRecepcion (fechageneracion,fact, EMailPDFDest) 
values (getdate(), getdate(), 'horacab@gmail.com.uy');
--select * from feWSRecepcion
--Se obtuvo fewsrecepcionid = 1 
---------------------------------------------------------
--Encabezado
insert into feWSEncabezadoIdDoc (fewsrecepcionid, movimientoid, codigosucursal, formapago, fechadocumento, indicadortrasladobienes,indicadormb,fechavto,codigocfe)
values (1,1,2,1,'2020-06-18',1,0,'2020-07-18',101)
--select * from feWSEncabezadoIdDoc

insert into feWSEncabezadoReceptor (fewsrecepcionid, movimientoid, ruc, codtipodoc, codpais,numerodoc, nombre, direccion,ciudad,departamento,pais)
values (1,1,'',4,'AR','30712479465','C & C GROUP S.A', 'OLGA COSSETTINI - BUENOS AIRES - ARGENTINA','','','' );
--select * from feWSEncabezadoReceptor

insert into feWSEncabezadoTotales (fewsrecepcionid, codmoneda, tipocambio, totalmontoNoGravado, TotalMontoExp, TotalMontoImpPercibido,TotalMontoIvaSuspenso,TotalMontoNetoIvaTMin,TotalMontoNetoIvaTBas,TotalMontoNetoIvaTOtra,TasaIvaMin,TasaIvaBas,TotalIvaMin,TotalIvaBas,TotalIvaOtra,TotalMontoTotal,TotalMontoPerRet,CantLineas,MontoNoFacturable,MontoTotalPagar,Ajuste,MayorDMilUI,TotalCreditosFisc)
values (1,'USD', 42.713, 32203.97, 0, 0,0,0,0,0,10,22,0,0,0,32203.97,0,12,0,32203.97,0,0,0);
--select * from feWSEncabezadoTotales

---------------------------------------------
--Detalle
insert into feWSDetalle (fewsrecepcionid, LineaId,TipoCodItem,CodigoItem,IndicadorFacturacion,NombreItem,DescripcionAdicional,Cantidad,UnidadMedida,PrecioUnitario,DescuentoPorc,MontoDto,RecargoPorc,MontoRecargo,MontoItem)
values (1,1,'','',1,'054461101 PLANTERS- SELECT CASHEWS ALMONDS & PECANS 233 G PLANTERS161800 (T)','',540.000,'U',4.83,0,0,0,0,2608.20);

insert into feWSDetalle (fewsrecepcionid, LineaId,TipoCodItem,CodigoItem,IndicadorFacturacion,NombreItem,DescripcionAdicional,Cantidad,UnidadMedida,PrecioUnitario,DescuentoPorc,MontoDto,RecargoPorc,MontoRecargo,MontoItem)
values (1,2,'','',1,'054462111 PLANTERS- MIXED NUTS 292 G PLANTERS - FRUTAS SECAS SURT166500 (T)','',1392.000,'U',3.94,0,0,0,0,5484.48);

insert into feWSDetalle (fewsrecepcionid, LineaId,TipoCodItem,CodigoItem,IndicadorFacturacion,NombreItem,DescripcionAdicional,Cantidad,UnidadMedida,PrecioUnitario,DescuentoPorc,MontoDto,RecargoPorc,MontoRecargo,MontoItem)
values (1,3,'','',1,'054463111 PLANTERS-DELUXE WHOLE CASHEWS 240 G PLANTERS - CASTAÑAS 161500 (T)','',360.000,'U',4.82,0,0,0,0,1735.20);

insert into feWSDetalle (fewsrecepcionid, LineaId,TipoCodItem,CodigoItem,IndicadorFacturacion,NombreItem,DescripcionAdicional,Cantidad,UnidadMedida,PrecioUnitario,DescuentoPorc,MontoDto,RecargoPorc,MontoRecargo,MontoItem)
values (1,4,'','',1,'054464111 PLANTERS CASHEWS LIGHTLY SALTED HALVES & PIECES 226 G P160800 (T)','',600.000,'U',4.28,0,0,0,0,2568.00);

insert into feWSDetalle (fewsrecepcionid, LineaId,TipoCodItem,CodigoItem,IndicadorFacturacion,NombreItem,DescripcionAdicional,Cantidad,UnidadMedida,PrecioUnitario,DescuentoPorc,MontoDto,RecargoPorc,MontoRecargo,MontoItem)
values (1,5,'','',1,'054465081 PLANTERS, DELUXE WHOLE CASHEWS HONEY ROASTED 8.25OZ - 23208000 (T)','',299.000,'U',4.83,0,0,0,0,1444.17);

insert into feWSDetalle (fewsrecepcionid, LineaId,TipoCodItem,CodigoItem,IndicadorFacturacion,NombreItem,DescripcionAdicional,Cantidad,UnidadMedida,PrecioUnitario,DescuentoPorc,MontoDto,RecargoPorc,MontoRecargo,MontoItem)
values (1,6,'','',1,'054467092 PLANTERS HONEY ROASTED PEANUTS 453 G PLANTERS - MANIES 734500 (T)','',2640.000,'U',2.92,0,0,0,0,7708.80);

insert into feWSDetalle (fewsrecepcionid, LineaId,TipoCodItem,CodigoItem,IndicadorFacturacion,NombreItem,DescripcionAdicional,Cantidad,UnidadMedida,PrecioUnitario,DescuentoPorc,MontoDto,RecargoPorc,MontoRecargo,MontoItem)
values (1,7,'','',1,'054475082 GREY POUPON, DIJON MUSTARD 8OZ - 227GRS AÑO PAR AGOSTO 544000002400 ','',480.000,'U',2.03,0,0,0,0,974.40);

insert into feWSDetalle (fewsrecepcionid, LineaId,TipoCodItem,CodigoItem,IndicadorFacturacion,NombreItem,DescripcionAdicional,Cantidad,UnidadMedida,PrecioUnitario,DescuentoPorc,MontoDto,RecargoPorc,MontoRecargo,MontoItem)
values (1,8,'','',1,'054482011 BULL''S EYE, BARBECUE SAUCE HICKORY SMOKE 18OZ - 510GRS A92236 ','',480.000,'U',1.45,0,0,0,0,696.00);

insert into feWSDetalle (fewsrecepcionid, LineaId,TipoCodItem,CodigoItem,IndicadorFacturacion,NombreItem,DescripcionAdicional,Cantidad,UnidadMedida,PrecioUnitario,DescuentoPorc,MontoDto,RecargoPorc,MontoRecargo,MontoItem)
values (1,9,'','',1,'056236121 PLANTERS, PEANUTS COCKTAIL 340GRS - 12OZ AÑO IMPAR NOVIE721200 ','',600.000,'U',2.17,0,0,0,0,1302.00);

insert into feWSDetalle (fewsrecepcionid, LineaId,TipoCodItem,CodigoItem,IndicadorFacturacion,NombreItem,DescripcionAdicional,Cantidad,UnidadMedida,PrecioUnitario,DescuentoPorc,MontoDto,RecargoPorc,MontoRecargo,MontoItem)
values (1,10,'','',1,'056265011 PLANTERS, DRY ROASTED PEANUTS 453GRS - 16OZ AÑO IMPAR EN290000732500 ','',656.000,'U',2.92,0,0,0,0,1915.52);

insert into feWSDetalle (fewsrecepcionid, LineaId,TipoCodItem,CodigoItem,IndicadorFacturacion,NombreItem,DescripcionAdicional,Cantidad,UnidadMedida,PrecioUnitario,DescuentoPorc,MontoDto,RecargoPorc,MontoRecargo,MontoItem)
values (1,11,'','',1,'057144041 HEINZ, TOMATO KETCHUP 396.893GRS- 14OZ AÑO IMPAR ABRIL 130000097800 ','',4320.000,'U',0.73,0,0,0,0,3153.60);

insert into feWSDetalle (fewsrecepcionid, LineaId,TipoCodItem,CodigoItem,IndicadorFacturacion,NombreItem,DescripcionAdicional,Cantidad,UnidadMedida,PrecioUnitario,DescuentoPorc,MontoDto,RecargoPorc,MontoRecargo,MontoItem)
values (1,12,'','',1,'057146061 HEINZ, YELLOW MUSTARD 396.89GRS - 14OZ AÑO IMPAR JUNIO 130000021200','',2640.000,'U',0.99,0,0,0,0,2613.60);

--select * from feWSDetalle

---------------------------------------------
--Referencia
insert into feWSInfoReferencia (fewsrecepcionid, NroLinRef, IndicadorGlobalRef,CAE,CodigoCFE,SerieCAE,NroComprobante,MovimientoIdRef,Referencia,FechaDocumento)
values (1,1, 0, '', 101, 'A', 10192, 0, '', '2020-04-01' );
--select * from feWSInfoReferencia

-------------------------------------------------------------------------------------
--Adenda
insert into feWSAdenda (fewsrecepcionid, ObservacionFact)
values (1,'Entregar en el Liceo Nª34 Convencion entre 18 de Julio y Colonia');
--select * from feWSAdenda
-----------------------------------------------------------------------------------------------------------------
--FIN WS
