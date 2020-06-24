--tablas bandeja de entrada de WS
use bdcfe
go
drop TABLE feWSRecepcion;
drop TABLE feWSEncabezadoIdDoc;
drop TABLE feWSEncabezadoReceptor;
drop TABLE feWSEncabezadoTotales;
drop TABLE feWSDetalle;
drop TABLE feWSInfoReferencia;
drop TABLE feWSAdenda;

CREATE TABLE feWSRecepcion (
	feWSRecepcionId int IDENTITY(1,1) NOT NULL,
	CaeId int NULL,
	CAE bigint NULL,
	Serie nvarchar(2) NULL,
	NroComprobante int NULL,
	Procesado char(1) NULL,
	FechaGeneracion datetime NULL,
	feMovimientoId int NULL,
	ReporteDiarioId int NULL,
	SobreDGI nvarchar(100) NULL,
	SobreEmpresa nvarchar(100) NULL,
	SobreEmpresaProcesado char(1) NULL,
	Fact datetime NOT NULL,
	Publicado char(1) NULL,
	Impreso char(1) NULL,
	Archivo nvarchar(100) NULL,
	codigoSeguridad nvarchar(200) NULL,
	RE02 char(1) NULL,
	EnRegimen char(1) NULL,
	PublicadoWeb char(1) NULL,
	EMailPDFDest varchar(250) null,
 CONSTRAINT PK_feWSRecepcion PRIMARY KEY CLUSTERED 
(
	feWSRecepcionId ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE feWSRecepcion ADD  DEFAULT ('N') FOR Publicado
GO

ALTER TABLE feWSRecepcion ADD  DEFAULT ('N') FOR Impreso
GO

ALTER TABLE feWSRecepcion ADD  DEFAULT ('N') FOR PublicadoWeb
GO
----------------------------

CREATE TABLE feWSEncabezadoIdDoc (
	EncabezadoIdDoc int IDENTITY(1,1) NOT NULL,
	feWSRecepcionId int NULL,
	feMovimientoId int NULL,
	MovimientoId int NULL,
	CodigoSucursal int NULL,
	FormaPago int NULL,
	FechaDocumento datetime NULL,
	IndicadorTrasladoBienes int NULL,
	PeriodoDesde datetime NULL,
	PeriodoHasta datetime NULL,
	IndicadorMB bit NULL,
	FechaVto datetime NULL,
	Descripcion nvarchar(200) NULL,
	CAE bigint NULL,
	CodigoCFE int not NULL,
	SerieCAE nvarchar(2) NULL,
	NroComprobante int NULL,
	ClausulaVenta nvarchar(3) NULL,
	ModalidadVenta int NULL,
	ViaTransporte int NULL,
 CONSTRAINT PK_feWSEncabezadoIdDoc PRIMARY KEY CLUSTERED 
(
	EncabezadoIdDoc ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


CREATE TABLE feWSEncabezadoReceptor(
	EncabezadoReceptorId int IDENTITY(1,1) NOT NULL,
	feWSRecepcionId int NULL,
	feMovimientoId int NULL,
	MovimientoId int NULL,
	Ruc nvarchar(12) NOT NULL,
	CodTipoDoc int NULL,
	CodPais nvarchar(2) NULL,
	NumeroDoc nvarchar(20) NULL,
	Nombre nvarchar(150) NULL,
	Direccion nvarchar(70) NULL,
	Ciudad nvarchar(30) NULL,
	Departamento nvarchar(30) NULL,
	Pais nvarchar(30) NULL,
	CodigoPostal int NULL,
	InfoAdicional nvarchar(150) NULL,
	LugarEntrega nvarchar(100) NULL,
	IdCompra nvarchar(50) NULL,
 CONSTRAINT PK_feWSEncabezadoReceptor PRIMARY KEY CLUSTERED 
(
	EncabezadoReceptorId ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE feWSEncabezadoTotales(
	EncabezadoTotalesId int IDENTITY(1,1) NOT NULL,
	feWSRecepcionId int NULL,
	feMovimientoId int NULL,
	CodMoneda varchar(3) NULL,
	TipoCambio decimal(7, 3) NULL,
	TotalMontoNoGravado decimal(17, 2) NULL,
	TotalMontoExp decimal(17, 2) NULL,
	TotalMontoImpPercibido decimal(17, 2) NULL,
	TotalMontoIvaSuspenso decimal(17, 2) NULL,
	TotalMontoNetoIvaTMin decimal(17, 2) NULL,
	TotalMontoNetoIvaTBas decimal(17, 2) NULL,
	TotalMontoNetoIvaTOtra decimal(17, 2) NULL,
	CodIva smallint NULL,
	TasaIvaMin decimal(6, 3) NULL,
	TasaIvaBas decimal(6, 3) NULL,
	TotalIvaMin decimal(17, 2) NULL,
	TotalIvaBas decimal(17, 2) NULL,
	TotalIvaOtra decimal(17, 2) NULL,
	TotalMontoTotal decimal(17, 2) NULL,
	TotalMontoPerRet decimal(17, 2) NULL,
	CantLineas smallint NULL,
	MontoNoFacturable decimal(17, 2) NULL,
	MontoTotalPagar decimal(17, 2) NULL,
	Ajuste decimal(6, 3) NULL,
	MayorDMilUI bit NULL,
	TotalCreditosFisc decimal(17, 2) NULL,
 CONSTRAINT PK_feWSEncabezadoTotales PRIMARY KEY CLUSTERED 
(
	EncabezadoTotalesId ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
-------------------------
--Detalle

CREATE TABLE feWSDetalle(
	DetalleId int IDENTITY(1,1) NOT NULL,
	feWSRecepcionId int NULL,
	feMovimientoId int NULL,
	LineaId int NULL,
	TipoCodItem nvarchar(10) NULL,
	CodigoItem nvarchar(35) NULL,
	IndicadorFacturacion smallint NULL,
	NombreItem nvarchar(80) NULL,
	DescripcionAdicional nvarchar(1000) NULL,
	Cantidad decimal(17, 3) NULL,
	UnidadMedida nvarchar(4) NULL,
	PrecioUnitario decimal(17, 2) NULL,
	DescuentoPorc decimal(6, 3) NULL,
	MontoDto decimal(17, 2) NULL,
	RecargoPorc decimal(6, 3) NULL,
	MontoRecargo decimal(17, 2) NULL,
	MontoItem decimal(17, 2) NULL,
	SubTotalId int NULL,
 CONSTRAINT PK_feWSDetalle PRIMARY KEY CLUSTERED 
(
	DetalleId ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
-----------------------------------
----referencia
CREATE TABLE feWSInfoReferencia(
	InfoReferenciaId int IDENTITY(1,1) NOT NULL,
	feWSRecepcionId int NOT NULL,
	feMovimientoId int NULL,
	NroLinRef int,
	IndicadorGlobalRef smallint NOT NULL,
	CAE bigint NULL,
	CodigoCFE int NULL,
	SerieCAE nvarchar(2) NULL,
	NroComprobante int NULL,
	MovimientoIdRef int NULL,
	Referencia nvarchar(200) NULL,
	FechaDocumento datetime NULL,
 CONSTRAINT PK_feWSInfoReferencia PRIMARY KEY CLUSTERED 
(
	InfoReferenciaId ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
-------------------------------------
---Adenda

CREATE TABLE feWSAdenda(
	AdendaId int IDENTITY(1,1) NOT NULL,
	feWSRecepcionId int NULL,
	feMovimientoId int NULL,
	VendedorId smallint NULL,
	CodVendedor smallint NULL,
	Vendedor nvarchar(100) NULL,
	FormaEnvioId smallint NULL,
	FormaEnvio nvarchar(100) NULL,
	ObservacionIdFact int NULL,
	ObservacionFact nvarchar(200) NULL,
	TipoObservacion nvarchar(1) NULL,
 CONSTRAINT PK_feWSAdenda PRIMARY KEY CLUSTERED 
(
	AdendaId ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
