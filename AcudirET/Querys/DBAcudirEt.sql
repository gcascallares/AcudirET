USE [master]
GO

IF NOT EXISTS (SELECT * FROM sysdatabases WHERE name = 'AcudirEt')
	CREATE DATABASE AcudirEt
GO

USE [AcudirEt]
GO

IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'dbo.EstadoDePedido')) 

	CREATE TABLE dbo.EstadoPedido (
       Id INT IDENTITY NOT NULL,
       Descripcion VARCHAR(50) NOT NULL,
       PRIMARY KEY (Id)
    )
GO

IF NOT EXISTS (select * from dbo.sysobjects where id = object_id(N'dbo.MedioDePago')) 

	CREATE TABLE dbo.MedioDePago (
       Id INT IDENTITY NOT NULL,
       Descripcion VARCHAR(50) NOT NULL,
       PRIMARY KEY (Id)
    )
GO

IF NOT EXISTS (select * from dbo.sysobjects where id = object_id(N'dbo.Producto')) 

	CREATE TABLE dbo.Producto (
       Id INT IDENTITY NOT NULL,
       Descripcion VARCHAR(50) NOT NULL,
	   Precio DECIMAL(19,4) NOT NULL,
       PRIMARY KEY (Id)
    )
GO

IF NOT EXISTS (select * from dbo.sysobjects where id = object_id(N'dbo.Cliente')) 

	CREATE TABLE dbo.Cliente (
       Id INT IDENTITY NOT NULL,
       Nombre VARCHAR(50) NOT NULL,
	   Domicilio VARCHAR(100) NOT NULL,
       PRIMARY KEY (Id)
    )
GO

IF NOT EXISTS (select * from dbo.sysobjects where id = object_id(N'dbo.Repartidor')) 

	CREATE TABLE dbo.Repartidor (
       Id INT IDENTITY NOT NULL,
       Nombre VARCHAR(50) NOT NULL,
       PRIMARY KEY (Id)
    )
GO

IF NOT EXISTS (select * from dbo.sysobjects where id = object_id(N'dbo.Pedido')) 

	CREATE TABLE dbo.Pedido (
       Id INT IDENTITY NOT NULL,
       Observacion VARCHAR(50) NOT NULL,
	   PrecioFinal DECIMAL(19,4) NOT NULL,
	   MedioPagoId INT NOT NULL,
	   ClienteId INT NOT NULL,
	   RepartidorId INT NOT NULL,
	   EstadoId INT NOT NULL,
	   ProductoId INT NOT NULL,
	   Cantidad INT NOT NULL,
       PRIMARY KEY (Id)
    )
	ALTER TABLE dbo.Pedido
	ADD CONSTRAINT FK_Pedido_MedioPago FOREIGN KEY (MedioPagoId)
	REFERENCES dbo.MedioDePago

	ALTER TABLE dbo.Pedido
	ADD CONSTRAINT FK_Pedido_Producto FOREIGN KEY (ProductoId)
	REFERENCES dbo.Producto

	ALTER TABLE dbo.Pedido
	ADD CONSTRAINT FK_Pedido_Cliente FOREIGN KEY (ClienteId)
	REFERENCES dbo.Cliente

	ALTER TABLE dbo.Pedido
	ADD CONSTRAINT FK_Pedidos_Repartidor FOREIGN KEY (RepartidorId)
	REFERENCES dbo.Repartidor

	ALTER TABLE dbo.Pedido
	ADD CONSTRAINT FK_Pedidos_EstadoPedido FOREIGN KEY (EstadoId)
	REFERENCES dbo.EstadoPedido
GO

insert into EstadoPedido
values ('Cancelado'),('En Preparacion'),('Entregado'),('Enviado')
GO

insert into Producto
values ('Carne',10.00),('Pollo',15.00)
GO

insert into MedioDePago
values ('Efectivo'),('Tarjeta')
GO

insert into Cliente
values ('Cliente 1','Domicilio 1')
GO

insert into Repartidor
values ('Repartidor 1')
GO