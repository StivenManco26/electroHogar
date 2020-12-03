CREATE 
--DROP
DATABASE ElectroHogar
GO

USE ElectroHogar
GO

CREATE TABLE tblTipo_DOcumento
(tipo_TDO VARCHAR(4) PRIMARY KEY NOT NULL,
descripcion_TDO VARCHAR(100) NOT NULL)
GO

CREATE TABLE tblCLiente_Direccion
(numero_doc_CLD VARCHAR(12) PRIMARY KEY NOT NULL,
direccion_CLD VARCHAR(100) NOT NULL,
ciudad_id_CLD INT NOT NULL,
id_CLD INT IDENTITY(1,1) NOT NULL)
GO

CREATE TABLE tblCLiente_Telefono
(numero_doc_CLT VARCHAR(12) PRIMARY KEY NOT NULL,
telefono_CLT VARCHAR(10) NOT NULL,
tipo_tel_CLT INT NOT NULL,
id_CLT INT IDENTITY(1,1) NOT NULL)
GO

CREATE TABLE tblCLiente_Telefono_Tipo
(id_CLTT INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
descripcion_CLTT VARCHAR(100) NOT NULL)
GO

CREATE TABLE tblCIUdades
(id_CIU INT PRIMARY KEY IDENTITY (100,1) NOT NULL,
descripcion_CIU VARCHAR(100) NOT NULL)
GO

CREATE TABLE tblCLiente_TIpo
(tipo_CLTI INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
descripcion_CLTI VARCHAR(100) NOT NULL,
descuento_CLTI FLOAT NOT NULL)
GO

CREATE TABLE tblCLIente
(numero_CLI VARCHAR(12) PRIMARY KEY NOT NULL,
tipo_doc_CLI VARCHAR(4) NOT NULL,
nombres_CLI VARCHAR(100) NOT NULL,
tipo_cliente_CLI INT NOT NULL,
cod_empleado_CLI INT NOT NULL)

CREATE TABLE tblForma_Pago
(id_FP INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
descripcion_FP VARCHAR(30) NOT NULL,
cod_empleado_FP INT NOT NULL)
GO

CREATE TABLE tblFACtura
(numero_FAC INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
fecha_FAC DATETIME NOT NULL,
numero_doc_FAC VARCHAR(12) NOT NULL,
valor_total_FAC MONEY NOT NULL,
iva_FAC MONEY NOT NULL,
id_forma_pago_FAC INT NOT NULL,
fecha_entrega_FAC DATETIME NOT NULL,
codigo_empleado_FAC INT NOT NULL,
descuento_FAC MONEY NOT NULL)
GO

CREATE TABLE tblFACtura_Detalle
(numero_FACD INT NOT NULL,
codigo_FACD INT NOT NULL,
cantidad_FACD FLOAT NOT NULL,
valor_un_FACD MONEY NOT NULL,
descuento_FACD FLOAT NOT NULL,
iva_FACD FLOAT NOT NULL,
seq_FACD INT NOT NULL)
GO

CREATE TABLE tblPROducto
(codigo_PRO INT PRIMARY KEY IDENTITY (100,1) NOT NULL,
descripcion_PRO VARCHAR(100) NOT NULL,
valor_un_PRO MONEY NOT NULL,
iva_PRO FLOAT NOT NULL,
clasificacion_id_PRO INT NOT NULL,
cod_empleado_PRO INT NOT NULL)
GO

CREATE TABLE tblPROducto_Clasificacion
(id_PROC INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
descripcion_PROC VARCHAR(100) NOT NULL)
GO

CREATE TABLE tblEMPleado
(codigo_EMP INT PRIMARY KEY NOT NULL,
nombres_EMP VARCHAR(100) NOT NULL,
direccion_EMP VARCHAR(100) NOT NULL,
id_ciudad_EMP INT NOT NULL,
cod_empleado_EMP INT NOT NULL)
GO

CREATE TABLE tblUSUario
(usuario_USU VARCHAR(20) PRIMARY KEY NOT NULL,
clave_USU VARCHAR(40) NOT NULL,
cod_empleado_USU INT NOT NULL,
activo_USU BIT NOT NULL)
GO

ALTER TABLE tblcliente_telefono ADD FOREIGN KEY (tipo_tel_CLT) REFERENCES tblcliente_telefono_tipo(id_CLTT)
ALTER TABLE tblcliente_telefono ADD FOREIGN KEY (numero_doc_CLT) REFERENCES tblcliente(numero_CLI)
ALTER TABLE tblcliente_direccion ADD FOREIGN KEY (ciudad_id_CLD) REFERENCES tblciudades(id_CIU)
ALTER TABLE tblcliente_direccion ADD FOREIGN KEY (numero_doc_CLD) REFERENCES tblcliente(numero_CLI)
ALTER TABLE tblcliente ADD FOREIGN KEY (tipo_doc_CLI) REFERENCES tbltipo_documento(tipo_TDO)
ALTER TABLE tblcliente ADD FOREIGN KEY (tipo_cliente_CLI) REFERENCES tblcliente_tipo(tipo_CLTI)
ALTER TABLE tblcliente ADD FOREIGN KEY (cod_empleado_CLI) REFERENCES tblempleado(codigo_EMP)
ALTER TABLE tblforma_pago ADD FOREIGN KEY (cod_empleado_FP) REFERENCES tblempleado(codigo_EMP)
ALTER TABLE tblfactura ADD FOREIGN KEY (numero_doc_FAC) REFERENCES tblcliente(numero_CLI)
ALTER TABLE tblfactura ADD FOREIGN KEY (id_forma_pago_FAC) REFERENCES tblforma_pago(id_FP)
ALTER TABLE tblfactura ADD FOREIGN KEY (codigo_empleado_FAC) REFERENCES tblempleado(codigo_EMP)
ALTER TABLE tblfactura_detalle ADD FOREIGN KEY (numero_FACD) REFERENCES tblfactura(numero_FAC)
ALTER TABLE tblfactura_detalle ADD FOREIGN KEY (codigo_FACD) REFERENCES tblproducto(codigo_PRO)
ALTER TABLE tblproducto ADD FOREIGN KEY (clasificacion_id_PRO) REFERENCES tblproducto_clasificacion(id_PROC)
ALTER TABLE tblproducto ADD FOREIGN KEY (cod_empleado_PRO) REFERENCES tblempleado(codigo_EMP)
ALTER TABLE tblusuario ADD FOREIGN KEY (cod_empleado_USU) REFERENCES tblempleado(codigo_EMP)
ALTER TABLE tblempleado ADD FOREIGN KEY (cod_empleado_EMP) REFERENCES tblempleado(codigo_EMP)
GO

INSERT INTO tblCIUdades
VALUES ('MEDELLIN - ANTIOQUIA'),
('BARRANQUILLA - ATLANTICO'),
('BOGOTA - BOGOTA DC'),
('CARTAGENA - BOLIVAR'),
('TUNJA - BOYACA'),
('MANIZALES - CALDAS'),
('FLORENCIA - CAQUETA'),
('POPAYAN - CAUCA'),
('VALLEDUPAR - CESAR'),
('MONTERIA - CORDOBA'),
('AGUA DE DIOS - CUNDINAMARCA'),
('QUIBDO - CHOCO'),
('NEIVA - HUILA'),
('RIOHACHA - GUAJIRA'),
('SANTA MARTA - MAGDALENA'),
('VILLAVICENCIO - META'),
('PASTO - NARIÑO'),
('CUCUTA - NORTE DE SANTANDER'),
('ARMENIA - QUINDIO'),
('PEREIRA - RISARALDA')
GO

INSERT INTO tblEMPleado
VALUES (1111,'ADMINISTRADOR','AVENIDA 33 # 40 - 30',100,1111),
(2222,'ROBERTO OSORIO','AVENIDA 24 # 11 - 10',103,1111)
GO

INSERT INTO tblPROducto_Clasificacion
VALUES ('TELEVISORES'),('HOGAR'),('AUDIO E INFORMATICA'),('COMPUTADORES')
GO

INSERT INTO tblPROducto
VALUES ('LG SMARTV 32',1500000,0.19,1,1111),
('HP NOTEBOOK 10',2500000,0.19,4,1111),
('SAMSUNG SOUND BAR',440000,0,3,1111)
GO

INSERT INTO tblCLiente_TIpo
VALUES ('MAYORISTA',0.10),
('CASUAL',0)
GO

INSERT INTO tblTipo_DOcumento
VALUES ('NI','NUMERO DE IDENTIFICACION TRIBUTARIA'),
('RC','REGISTRO CIVIL'),
('TI','TARJETA DE IDENTIDAD'),
('CC','CEDULA DE CIUDADANIA'),
('CE','CEDULA DE EXTRANJERIA'),
('PA','PASAPORTE')
GO

INSERT INTO tblCLIente
VALUES ('800400200','NI','TERPEL SAS',1,1111),
('11521111','CC','JOSÉ ROJAS',2,1111),
('7162222','CC','FERNANDO CASAS',2,1111)
GO

INSERT INTO tblForma_Pago (descripcion_FP,cod_empleado_FP)
VALUES ('EFECTIVO',1111),
('T. DEBITO',1111),
('T. CREDITO',1111),
('CHEQUE',1111)
GO

INSERT INTO tblUSUario 
VALUES ('admin123', 'Colombia.1', 1111, 1),
('operador1','Opera1',2222,1)
GO 

--RELACIONADO CON PRODUCTOS

CREATE PROCEDURE USP_ProductoClasi 
AS
BEGIN
	SELECT id_PROC as Clave, descripcion_PROC as Dato
	FROM tblPROducto_Clasificacion
	ORDER BY id_PROC ASC 
	--EXEC USP_ProductoClasi
END
GO

CREATE PROCEDURE USP_Prod_BuscarXcodigo
@strCodigo INT
AS 
BEGIN
	SELECT codigo_PRO AS Cod,descripcion_PRO AS Descrip,
	valor_un_PRO AS Vlr,iva_PRO AS IVA,
	clasificacion_id_PRO AS Clasi
	FROM tblPROducto
	WHERE codigo_PRO = @strCodigo
	--EXEC USP_Prod_BuscarXcodigo 102
END
GO

CREATE PROCEDURE USP_Prod_BuscarGeneral
AS 
BEGIN 
	SELECT codigo_PRO AS Cod,descripcion_PRO AS Descrip,
	valor_un_PRO AS Vlr,iva_PRO AS IVA,
	clasificacion_id_PRO AS Clasi
	FROM tblPROducto
	--EXEC USP_Prod_BuscarGeneral
END
GO

CREATE PROCEDURE USP_Prod_Grabar
@Descripcion VARCHAR(100),
@VlrUni MONEY,
@Iva FLOAT,
@Clasi INT,
@CodEmp INT
AS 
BEGIN
	DECLARE @CODIGO INT

	IF EXISTS( SELECT * FROM tblPROducto WHERE descripcion_PRO = @Descripcion )
	BEGIN
		SELECT -1 AS Rpta
		RETURN
	END

	IF NOT EXISTS( SELECT * FROM tblEMPleado WHERE codigo_EMP = @CodEmp )
	BEGIN
		SELECT 0 AS Rpta
		RETURN
	END

	ELSE
	BEGIN
		BEGIN TRANSACTION tx
			INSERT INTO tblPROducto
			VALUES (@Descripcion, @VlrUni, @Iva, @Clasi, @CodEmp );
			SELECT @CODIGO=MAX(codigo_PRO) FROM tblPROducto
			IF ( @@ERROR > 0 )
			BEGIN
				ROLLBACK TRANSACTION tx
				SELECT 0 AS Rpta
				RETURN
			END
		COMMIT TRANSACTION tx
		SELECT @CODIGO AS Rpta
		RETURN
	END
--EXEC USP_Prod_Grabar 'MOTOROLA MOTO ONE 32GB', '460000', 0.19, 3, 1111
END
GO

CREATE PROCEDURE USP_Prod_Modificar
@Codigo INT,
@Descripcion VARCHAR(100),
@VlrUni MONEY,
@Iva FLOAT,
@Clasi INT,
@CodEmp INT
As
BEGIN
	IF EXISTS( SELECT * FROM tblPROducto WHERE codigo_PRO <> @Codigo AND descripcion_PRO = @Descripcion )
	BEGIN
		SELECT -1 AS Rpta
		RETURN
	END
	ELSE
	BEGIN
		BEGIN TRANSACTION tx
			UPDATE tblPROducto
			SET descripcion_PRO = @Descripcion, valor_un_PRO = @VlrUni,
			iva_PRO = @Iva, clasificacion_id_PRO = @Clasi, cod_empleado_PRO = @CodEmp
			WHERE codigo_PRO = @Codigo
			IF ( @@ERROR > 0 )
			Begin
				ROLLBACK TRANSACTION tx
				SELECT 0 AS Rpta
				Return
			End
		COMMIT TRANSACTION tx
	SELECT @Codigo  AS Rpta
	RETURN
	END
	--EXEC USP_Prod_Modificar 100,'LG SMARTV 32', 2000000, '0.1', 1, 1111
END
GO



--RELACIONADO CON FACTURACION

CREATE PROCEDURE USP_FormaPago
AS
BEGIN
	SELECT id_FP as Clave, descripcion_FP as Dato
	FROM tblForma_Pago
	ORDER BY id_FP ASC 
	--EXEC USP_FormaPago
END
GO

CREATE PROCEDURE USP_BuscarProducto
@Codigo INT
AS 
BEGIN
	SELECT descripcion_PRO as Producto 
	FROM tblPROducto 
	WHERE codigo_PRO = @Codigo
	--EXEC USP_BuscarProducto 104
END
GO

CREATE PROCEDURE USP_BuscarCliente
@NumeroCli VARCHAR(12)
AS 
BEGIN
	SELECT nombres_CLI as Cliente 
	FROM tblCLIente 
	WHERE numero_CLI = @NumeroCli
	--EXEC USP_BuscarCliente '800400200'
END
GO

CREATE PROCEDURE USP_Fac_BorrarDetalle
@Factura INT,
@Seq INT
AS
BEGIN TRANSACTION tx

	DECLARE @VlrIVA MONEY=0
	DECLARE @VlrDesc MONEY=0
	DECLARE @Total MONEY=0
	DECLARE @Neto MONEY=0

	SELECT @VlrDesc=(valor_un_FACD*cantidad_FACD)*descuento_FACD,
			@Neto=(valor_un_FACD*cantidad_FACD)-@VlrDesc,
			@VlrIVA=@Neto*iva_FACD,@Total=@Neto+@VlrIVA
	FROM tblFACtura_Detalle 
	WHERE numero_FACD=@Factura AND seq_FACD=@Seq

	UPDATE tblFACtura
	SET iva_FAC=iva_FAC-@VlrIVA,descuento_FAC=descuento_FAC-@VlrDesc,valor_total_FAC=valor_total_FAC-@Total
	WHERE numero_FAC=@Factura

	DELETE FROM tblFACtura_Detalle
	WHERE numero_FACD = @Factura AND seq_FACD=@Seq;

	IF ( @@ERROR > 0 )
	BEGIN
		ROLLBACK TRANSACTION tx
		SELECT 0 AS Rpta
		Return
	END
COMMIT TRANSACTION tx
SELECT @Seq AS Rpta
RETURN
--EXEC USP_Fac_BorrarDetalle 1,2
GO

CREATE PROCEDURE USP_Fac_BuscarDetalle_X_Numero
@Numero INT
AS
BEGIN
	SELECT seq_FACD Consec, codigo_FACD AS Producto,
	descripcion_PRO AS Descripción, cantidad_FACD AS Cantidad,
	valor_un_FACD AS ValorUnitario, (valor_un_FACD*cantidad_FACD) AS Valor,
	(valor_un_FACD*cantidad_FACD)*descuento_FACD AS ValorDescuento,
	((valor_un_FACD*cantidad_FACD)-((valor_un_FACD*cantidad_FACD)*descuento_FACD))*iva_FACD AS ValorIVA
	FROM tblFACtura 
	INNER JOIN tblFACtura_Detalle ON numero_FAC = numero_FACD
	INNER JOIN tblPROducto ON codigo_FACD=codigo_PRO
	WHERE numero_FAC = @Numero
	ORDER BY seq_FACD
	--EXEC USP_Fac_BuscarDetalle_X_Numero 1;
END
GO

CREATE PROCEDURE USP_Fac_BuscarXNumero
@Numero INT
AS 
BEGIN
	SELECT numero_FAC As Numero, Convert (varchar(10), fecha_FAC, 103) As Fecha,
	numero_CLI AS Cliente, nombres_CLI AS Nombre, id_forma_pago_FAC AS FormaPago,
	Convert (varchar(10), fecha_entrega_FAC, 103) As FechaEntrega, 
	iva_FAC AS IVA, descuento_FAC AS Descuento,	valor_total_FAC AS Total, 
	nombres_EMP AS Empleado
	FROM tblFACtura
	INNER JOIN tblCLIente ON numero_doc_FAC = numero_CLI
	INNER JOIN tblEMPleado ON codigo_empleado_FAC = codigo_EMP
	WHERE numero_FAC = @Numero
	
	EXEC USP_Fac_BuscarDetalle_X_Numero @Numero;
	--EXEC USP_Fac_BuscarXNumero 1;
END
GO

CREATE PROCEDURE USP_Fac_GrabarDetalle
@Numero INT,
@Codigo INT,
@Cantidad FLOAT,
@Desc FLOAT=NULL
AS 
BEGIN
DECLARE @VlrUni MONEY
DECLARE @IVA FLOAT
DECLARE @Seq INT
DECLARE @VlrIVA MONEY
DECLARE @VlrDesc MONEY
DECLARE @Total MONEY
DECLARE @Neto MONEY
DECLARE @Doc VARCHAR(12)

SELECT @Seq=(ISNULL(MAX(seq_FACD),0)+1) FROM tblFACtura_Detalle WHERE numero_FACD=@Numero
SELECT @VlrUni=valor_un_PRO, @IVA=iva_PRO FROM tblPROducto WHERE codigo_PRO=@Codigo
SELECT @Doc=numero_doc_FAC FROM tblFACtura WHERE numero_FAC=@Numero

IF (@Desc IS NULL OR @Desc<0)
BEGIN
	SELECT @Desc=descuento_CLTI FROM tblCLIente INNER JOIN tblCLiente_TIpo ON tipo_cliente_CLI=tipo_CLTI WHERE numero_CLI=@Doc
END

	BEGIN TRANSACTION tx
		INSERT INTO tblFACtura_Detalle(numero_FACD,codigo_FACD,cantidad_FACD,valor_un_FACD,
			descuento_FACD,iva_FACD,seq_FACD)
		VALUES ( @Numero, @Codigo, @Cantidad, @VlrUni, @Desc, @IVA, @Seq );

		SET @VlrDesc=((@VlrUni*@Cantidad)*@Desc);
		SET @Neto=((@VlrUni*@Cantidad)-@VlrDesc);
		SET @VlrIVA=(@Neto*@IVA);
		SET @Total=(@Neto+@VlrIVA)

		UPDATE tblFACtura
		SET iva_FAC=iva_FAC+@VlrIVA, descuento_FAC=descuento_FAC+@VlrDesc, valor_total_FAC=valor_total_FAC+@Total
		WHERE numero_FAC=@Numero

		IF ( @@ERROR > 0 )
		BEGIN
			ROLLBACK TRANSACTION tx
			SELECT 0 AS Rpta
			RETURN
		END
	COMMIT TRANSACTION tx
	SELECT @Numero AS Rpta
	RETURN
	--EXEC USP_Fac_GrabarDetalle 1, 100, 1, NULL;
	--EXEC USP_Fac_GrabarDetalle 1, 102, 2, 0.5;
END
GO

CREATE PROCEDURE USP_Fac_Grabar_Agregar
@NumeroDoc VARCHAR(12),
@FormaPago INT,
@CodigoEmp INT,
@FechaEnt DATETIME
AS 
BEGIN

	BEGIN TRANSACTION tx

	INSERT INTO tblFACtura(fecha_FAC, numero_doc_FAC, valor_total_FAC, iva_FAC,
			id_forma_pago_FAC, fecha_entrega_FAC, codigo_empleado_FAC, descuento_FAC)
	VALUES (GETDATE(), @NumeroDoc, 0, 0, @FormaPago, @FechaEnt, @CodigoEmp, 0);

	IF ( @@ERROR > 0 )
	BEGIN
		ROLLBACK TRANSACTION tx
		SELECT 0 AS Rpta
		Return
	END
	COMMIT TRANSACTION tx
	SELECT @@IDENTITY AS Rpta
	Return
	--EXEC USP_Fac_Grabar_Agregar '800400200', 2, 2222,'01/05/2020';
END
GO

CREATE PROCEDURE USP_Fac_Grabar_Modificar
@Numero INT, 
@FormaPago INT,
@FechaEntrega DATE,
@CodigoEmp INT
AS 
BEGIN

	BEGIN TRANSACTION tx

	UPDATE tblFACtura
	SET id_forma_pago_FAC=@FormaPago, fecha_entrega_FAC=@FechaEntrega, 
			codigo_empleado_FAC=@CodigoEmp
	WHERE numero_FAC=@Numero	

	IF ( @@ERROR > 0 )
	BEGIN
		ROLLBACK TRANSACTION tx
		SELECT 0 AS Rpta
		Return
	END
	COMMIT TRANSACTION tx
	SELECT @Numero AS Rpta
	RETURN
	--EXEC USP_Fac_Grabar_Modificar 1,2,'29/11/2020',2222
END
GO

CREATE PROCEDURE USP_Cli_TipoCliRN 
@NumeroDoc VARCHAR(12)
AS
BEGIN
	SELECT tipo_cliente_CLI as Tipo 
	FROM tblCLIente 
	WHERE numero_CLI = @NumeroDoc
	--EXEC USP_Cli_TipoCliRN '800400200'
END
GO

CREATE PROCEDURE USP_Fac_BuscarCliente
@strCodigo VARCHAR(20)
AS 
BEGIN
	SELECT nombres_CLI as Cliente
	FROM tblCLIente 
	WHERE numero_CLI = @strCodigo
	--EXEC USP_Fac_BuscarCliente '11521111'
END
GO

CREATE PROCEDURE USP_Fac_BuscarFac_X_Cliente
@strCodigo VARCHAR(20)
AS 
BEGIN
	SELECT numero_FAC AS Factura, nombres_CLI AS Cliente,
	CONVERT (varchar(10), fecha_FAC, 103) AS Fecha,
	valor_total_FAC AS Total, descripcion_FP AS FormaPago
	FROM tblFACtura 
	INNER JOIN tblForma_Pago ON id_forma_pago_FAC=id_FP
	INNER JOIN tblCLIente ON numero_doc_FAC=numero_CLI
	WHERE numero_doc_FAC = @strCodigo
	ORDER BY numero_FAC desc
	--EXEC USP_Fac_BuscarFac_X_Cliente '800400200';
END
GO


---INFORMES

--Productos
CREATE PROCEDURE USP_Prod_BuscarXcodigo_Impresion
@CODIGO INT
AS
BEGIN
	SELECT codigo_PRO AS CodProd,
	CAST(clasificacion_id_PRO AS VARCHAR(100)) + ' - ' + descripcion_PROC AS Clasifica,
	descripcion_PRO AS Producto, valor_un_PRO AS Valor, iva_PRO AS IVA
	FROM tblPROducto
	INNER JOIN tblPROducto_Clasificacion ON clasificacion_id_PRO = id_PROC
	WHERE codigo_PRO = @CODIGO
	-- EXEC USP_Prod_BuscarXcodigo_Impresion 101;
END
GO

CREATE PROCEDURE USP_Fac_Impresion
@Numero INT
AS
BEGIN
	SELECT numero_FAC AS NroFac,
	CONVERT(varchar(10),fecha_FAC, 103) AS Fecha,
	CONVERT(varchar(10),fecha_entrega_FAC, 103) AS FechaEntr,
	tipo_doc_CLI + ' - ' + descripcion_TDO AS TipoDoc,
	numero_doc_FAC AS NroDoc, nombres_CLI AS Nombre,descripcion_CLTI AS TipoCli,
	descuento_FAC AS Descuento, iva_FAC AS IVA, valor_total_FAC AS TOTAL,
	nombres_EMP AS Usuario
	FROM tblFACtura
	INNER JOIN tblCLIente ON numero_doc_FAC = numero_CLI
	INNER JOIN tblTipo_DOcumento ON tipo_doc_CLI = tipo_TDO
	INNER JOIN tblCLiente_TIpo ON tipo_cliente_CLI=tipo_CLTI
	INNER JOIN tblEMPleado ON codigo_empleado_FAC=codigo_EMP
	WHERE numero_FAC = @Numero;
	EXEC USP_Fac_BuscarDetalle_X_Numero @Numero;
	-- EXEC USP_Fac_Impresion 1;
END
GO

--RELACIONADO AL LOGIN 

CREATE PROCEDURE USP_Login_Validar
@user VARCHAR(20),
@clave VARCHAR(40)
AS
BEGIN
DECLARE @LOGIN INT

	SELECT @LOGIN=COUNT(usuario_USU) FROM tblUSUario
	WHERE usuario_USU=@user and clave_USU COLLATE Latin1_General_CS_AS =@clave and activo_USU=1
	IF(@LOGIN>0)
	BEGIN
		SELECT 1 AS Rpta, cod_empleado_USU AS codigo, nombres_EMP AS nombre
		FROM tblUSUario
		INNER JOIN tblEMPleado ON cod_empleado_USU = codigo_EMP and usuario_USU = @user
	END
	ELSE
		SELECT 0 AS Rpta, 0 AS codigo, 0 AS nombre
	
	--EXEC USP_Login_Validar 'operador1', 'Opera1'
END
GO
