USE [master]
GO
/****** Object:  Database [SistemaVentas]    Script Date: 2/10/2019 20:11:35 ******/
CREATE DATABASE [SistemaVentas] 
GO
USE [SistemaVentas]
GO
/****** Object:  Table [dbo].[Barrios]    Script Date: 6/10/2019 12:09:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Barrios](
	[id_barrio] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[ciudad] [int] NULL,
	[borrado] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_barrio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categorias]    Script Date: 6/10/2019 12:09:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorias](
	[id_categoria] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
	[borrado] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_categoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ciudades]    Script Date: 6/10/2019 12:09:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ciudades](
	[id_ciudad] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[borrado] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_ciudad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 6/10/2019 12:09:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[id_cliente] [int] IDENTITY(1,1) NOT NULL,
	[cuit] [varchar](13) NULL,
	[nombre_local] [varchar](50) NULL,
	[nombre_cliente] [varchar](50) NOT NULL,
	[domicilio_calle] [varchar](50) NOT NULL,
	[domicilio_numero] [int] NOT NULL,
	[telefono] [varchar](50) NULL,
	[email] [varchar](50) NULL,
	[fecha_registro] [date] NULL,
	[barrio] [int] NULL,
	[tipo_cliente] [int] NULL,
	[estado_cliente] [int] NULL,
	[borrado] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EstadoCliente]    Script Date: 6/10/2019 12:09:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstadoCliente](
	[id_estadoC] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
	[borrado] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_estadoC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EstadoProducto]    Script Date: 6/10/2019 12:09:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstadoProducto](
	[id_estadoPr] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NULL,
	[borrado] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_estadoPr] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Facturas]    Script Date: 6/10/2019 12:09:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Facturas](
	[id_factura] [int] IDENTITY(1,1) NOT NULL,
	[nro_factura] [int] NULL,
	[fecha] [date] NOT NULL,
	[cliente] [int] NULL,
	[tipoFactura] [char](1) NOT NULL,
	[subtotal] [decimal](18, 2) NOT NULL,
	[descuento] [decimal](18, 2) NOT NULL,
	[borrado] [bit] NOT NULL,
 CONSTRAINT [PK_Factura] PRIMARY KEY CLUSTERED 
(
	[id_factura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FacturasDetalle]    Script Date: 6/10/2019 12:09:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FacturasDetalle](
	[id_factura_detalle] [int] IDENTITY(1,1) NOT NULL,
	[id_factura] [int] NOT NULL,
	[id_producto] [int] NOT NULL,
	[precio_unitario] [decimal](18, 2) NOT NULL,
	[cantidad] [decimal](18, 0) NOT NULL,
	[borrado] [bit] NOT NULL,
 CONSTRAINT [PK_FacturaDetalle] PRIMARY KEY CLUSTERED 
(
	[id_factura_detalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 6/10/2019 12:09:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[id_producto] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[unidad] [varchar](10) NULL,
	[fecha_registro] [date] NULL,
	[estado] [int] NULL,
	[categoria] [int] NULL,
	[precio] [decimal](10, 2) NOT NULL,
	[stock] [int] NOT NULL,
	[borrado] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoCliente]    Script Date: 6/10/2019 12:09:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoCliente](
	[id_tipoC] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
	[borrado] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_tipoC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoFactura]    Script Date: 6/10/2019 12:09:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoFactura](
	[id_tipoFactura] [char](1) NOT NULL,
	[descripcion] [varchar](50) NULL,
	[borrado] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_tipoFactura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Barrios] ON 
GO
INSERT [dbo].[Barrios] ([id_barrio], [nombre], [ciudad], [borrado]) VALUES (1, N'Alberdi', 1, 0)
GO
INSERT [dbo].[Barrios] ([id_barrio], [nombre], [ciudad], [borrado]) VALUES (2, N'Nueva Cordoba', 1, 0)
GO
INSERT [dbo].[Barrios] ([id_barrio], [nombre], [ciudad], [borrado]) VALUES (3, N'Centro', 1, 0)
GO
INSERT [dbo].[Barrios] ([id_barrio], [nombre], [ciudad], [borrado]) VALUES (4, N'Junior', 1, 0)
GO
INSERT [dbo].[Barrios] ([id_barrio], [nombre], [ciudad], [borrado]) VALUES (5, N'Gral Paz', 1, 0)
GO
INSERT [dbo].[Barrios] ([id_barrio], [nombre], [ciudad], [borrado]) VALUES (6, N'Alta Córdoba', 1, 0)
GO
INSERT [dbo].[Barrios] ([id_barrio], [nombre], [ciudad], [borrado]) VALUES (7, N'Talleres Este', 1, 0)
GO
INSERT [dbo].[Barrios] ([id_barrio], [nombre], [ciudad], [borrado]) VALUES (8, N'Talleres Oeste', 1, 0)
GO
INSERT [dbo].[Barrios] ([id_barrio], [nombre], [ciudad], [borrado]) VALUES (9, N'Villa Esquiú', 1, 0)
GO
INSERT [dbo].[Barrios] ([id_barrio], [nombre], [ciudad], [borrado]) VALUES (10, N'Yofre Norte', 1, 0)
GO
INSERT [dbo].[Barrios] ([id_barrio], [nombre], [ciudad], [borrado]) VALUES (11, N'Centro', 2, 0)
GO
INSERT [dbo].[Barrios] ([id_barrio], [nombre], [ciudad], [borrado]) VALUES (12, N'Barrancas', 2, 0)
GO
INSERT [dbo].[Barrios] ([id_barrio], [nombre], [ciudad], [borrado]) VALUES (13, N'Pueblo Nuevo', 2, 0)
GO
INSERT [dbo].[Barrios] ([id_barrio], [nombre], [ciudad], [borrado]) VALUES (14, N'Centro', 3, 0)
GO
INSERT [dbo].[Barrios] ([id_barrio], [nombre], [ciudad], [borrado]) VALUES (15, N'La Cuesta', 3, 0)
GO
INSERT [dbo].[Barrios] ([id_barrio], [nombre], [ciudad], [borrado]) VALUES (16, N'Costa Azul Sur', 3, 0)
GO
INSERT [dbo].[Barrios] ([id_barrio], [nombre], [ciudad], [borrado]) VALUES (17, N'Altos de las Vertientes', 3, 0)
GO
INSERT [dbo].[Barrios] ([id_barrio], [nombre], [ciudad], [borrado]) VALUES (18, N'Villa del Lago', 3, 0)
GO
INSERT [dbo].[Barrios] ([id_barrio], [nombre], [ciudad], [borrado]) VALUES (19, N'Centro', 4, 0)
GO
INSERT [dbo].[Barrios] ([id_barrio], [nombre], [ciudad], [borrado]) VALUES (20, N'Cumbre Azul', 4, 0)
GO
INSERT [dbo].[Barrios] ([id_barrio], [nombre], [ciudad], [borrado]) VALUES (21, N'Pan de Azucar', 4, 0)
GO
INSERT [dbo].[Barrios] ([id_barrio], [nombre], [ciudad], [borrado]) VALUES (22, N'Alto Mieres', 4, 0)
GO
INSERT [dbo].[Barrios] ([id_barrio], [nombre], [ciudad], [borrado]) VALUES (23, N'Yacanto', 5, 0)
GO
INSERT [dbo].[Barrios] ([id_barrio], [nombre], [ciudad], [borrado]) VALUES (24, N'Centro', 5, 0)
GO
INSERT [dbo].[Barrios] ([id_barrio], [nombre], [ciudad], [borrado]) VALUES (25, N'Los Reartes', 5, 0)
GO
INSERT [dbo].[Barrios] ([id_barrio], [nombre], [ciudad], [borrado]) VALUES (26, N'San Javier', 5, 0)
GO
INSERT [dbo].[Barrios] ([id_barrio], [nombre], [ciudad], [borrado]) VALUES (27, N'Centro', 6, 0)
GO
INSERT [dbo].[Barrios] ([id_barrio], [nombre], [ciudad], [borrado]) VALUES (28, N'Banda Norte', 6, 0)
GO
INSERT [dbo].[Barrios] ([id_barrio], [nombre], [ciudad], [borrado]) VALUES (29, N'Abilene', 6, 0)
GO
INSERT [dbo].[Barrios] ([id_barrio], [nombre], [ciudad], [borrado]) VALUES (30, N'Centro', 7, 0)
GO
INSERT [dbo].[Barrios] ([id_barrio], [nombre], [ciudad], [borrado]) VALUES (31, N'Golf Club', 7, 0)
GO
INSERT [dbo].[Barrios] ([id_barrio], [nombre], [ciudad], [borrado]) VALUES (32, N'Las Quintas', 7, 0)
GO
INSERT [dbo].[Barrios] ([id_barrio], [nombre], [ciudad], [borrado]) VALUES (33, N'Centro', 8, 0)
GO
INSERT [dbo].[Barrios] ([id_barrio], [nombre], [ciudad], [borrado]) VALUES (34, N'Obrero', 8, 0)
GO
INSERT [dbo].[Barrios] ([id_barrio], [nombre], [ciudad], [borrado]) VALUES (35, N'Centro', 9, 0)
GO
INSERT [dbo].[Barrios] ([id_barrio], [nombre], [ciudad], [borrado]) VALUES (36, N'1° de Mayo', 9, 0)
GO
INSERT [dbo].[Barrios] ([id_barrio], [nombre], [ciudad], [borrado]) VALUES (37, N'Parque del Virrey', 9, 0)
GO
INSERT [dbo].[Barrios] ([id_barrio], [nombre], [ciudad], [borrado]) VALUES (38, N'Centro', 10, 0)
GO
INSERT [dbo].[Barrios] ([id_barrio], [nombre], [ciudad], [borrado]) VALUES (39, N'Las Rosas', 10, 0)
GO
INSERT [dbo].[Barrios] ([id_barrio], [nombre], [ciudad], [borrado]) VALUES (40, N'Maipú', 10, 0)
GO
INSERT [dbo].[Barrios] ([id_barrio], [nombre], [ciudad], [borrado]) VALUES (41, N'Centro', 11, 0)
GO
INSERT [dbo].[Barrios] ([id_barrio], [nombre], [ciudad], [borrado]) VALUES (42, N'El Prado', 11, 0)
GO
INSERT [dbo].[Barrios] ([id_barrio], [nombre], [ciudad], [borrado]) VALUES (43, N'Santa Rosa', 12, 0)
GO
INSERT [dbo].[Barrios] ([id_barrio], [nombre], [ciudad], [borrado]) VALUES (44, N'Valle Verde', 12, 0)
GO
INSERT [dbo].[Barrios] ([id_barrio], [nombre], [ciudad], [borrado]) VALUES (45, N'Centro', 13, 0)
GO
INSERT [dbo].[Barrios] ([id_barrio], [nombre], [ciudad], [borrado]) VALUES (46, N'Stoecklin', 13, 0)
GO
INSERT [dbo].[Barrios] ([id_barrio], [nombre], [ciudad], [borrado]) VALUES (47, N'Villa Los Paraísos', 13, 0)
GO
SET IDENTITY_INSERT [dbo].[Barrios] OFF
GO
SET IDENTITY_INSERT [dbo].[Categorias] ON 
GO
INSERT [dbo].[Categorias] ([id_categoria], [descripcion], [borrado]) VALUES (1, N'Alimentos que aceleran el metabolismo', 0)
GO
INSERT [dbo].[Categorias] ([id_categoria], [descripcion], [borrado]) VALUES (2, N'Alimentos saciantes', 0)
GO
INSERT [dbo].[Categorias] ([id_categoria], [descripcion], [borrado]) VALUES (3, N'Alimentos digestivos', 0)
GO
SET IDENTITY_INSERT [dbo].[Categorias] OFF
GO
SET IDENTITY_INSERT [dbo].[Ciudades] ON 
GO
INSERT [dbo].[Ciudades] ([id_ciudad], [nombre], [borrado]) VALUES (1, N'Córdoba', 0)
GO
INSERT [dbo].[Ciudades] ([id_ciudad], [nombre], [borrado]) VALUES (2, N'Jesús María', 0)
GO
INSERT [dbo].[Ciudades] ([id_ciudad], [nombre], [borrado]) VALUES (3, N'Carlos Paz', 0)
GO
INSERT [dbo].[Ciudades] ([id_ciudad], [nombre], [borrado]) VALUES (4, N'Cosquin', 0)
GO
INSERT [dbo].[Ciudades] ([id_ciudad], [nombre], [borrado]) VALUES (5, N'Arroyito', 0)
GO
INSERT [dbo].[Ciudades] ([id_ciudad], [nombre], [borrado]) VALUES (6, N'Río Cuarto', 0)
GO
INSERT [dbo].[Ciudades] ([id_ciudad], [nombre], [borrado]) VALUES (7, N'Río Tercero', 0)
GO
INSERT [dbo].[Ciudades] ([id_ciudad], [nombre], [borrado]) VALUES (8, N'Villa María', 0)
GO
INSERT [dbo].[Ciudades] ([id_ciudad], [nombre], [borrado]) VALUES (9, N'Alta Gracia', 0)
GO
INSERT [dbo].[Ciudades] ([id_ciudad], [nombre], [borrado]) VALUES (10, N'San Francisco', 0)
GO
INSERT [dbo].[Ciudades] ([id_ciudad], [nombre], [borrado]) VALUES (11, N'Bell-Ville', 0)
GO
INSERT [dbo].[Ciudades] ([id_ciudad], [nombre], [borrado]) VALUES (12, N'La Falda', 0)
GO
INSERT [dbo].[Ciudades] ([id_ciudad], [nombre], [borrado]) VALUES (13, N'La Calera', 0)
GO
SET IDENTITY_INSERT [dbo].[Ciudades] OFF
GO
SET IDENTITY_INSERT [dbo].[Clientes] ON 
GO
INSERT [dbo].[Clientes] ([id_cliente], [cuit], [nombre_local], [nombre_cliente], [domicilio_calle], [domicilio_numero], [telefono], [email], [fecha_registro], [barrio], [tipo_cliente], [estado_cliente], [borrado]) VALUES (11, NULL, N'Pato Azul', N'Arturo Viñas', N'San Martín', 788, N'0351-4514753', N'patoazul@gmail.com', CAST(N'2019-09-03' AS Date), 1, 1, 1, 0)
GO
INSERT [dbo].[Clientes] ([id_cliente], [cuit], [nombre_local], [nombre_cliente], [domicilio_calle], [domicilio_numero], [telefono], [email], [fecha_registro], [barrio], [tipo_cliente], [estado_cliente], [borrado]) VALUES (12, NULL, N'Vida Sana', N'Maria Vegas', N'Oncativo', 1454, N'0351-4518013', N'vidasanaproductos@gmail.com', CAST(N'2019-01-01' AS Date), 2, 1, 1, 0)
GO
INSERT [dbo].[Clientes] ([id_cliente], [cuit], [nombre_local], [nombre_cliente], [domicilio_calle], [domicilio_numero], [telefono], [email], [fecha_registro], [barrio], [tipo_cliente], [estado_cliente], [borrado]) VALUES (13, NULL, N'Amanecer', N'Esmeralda Di Pietro', N'Santa Fé', 5120, N'0351-159913445', N'dipietroventa@gmail.com', CAST(N'2017-08-13' AS Date), 3, 3, 1, 0)
GO
INSERT [dbo].[Clientes] ([id_cliente], [cuit], [nombre_local], [nombre_cliente], [domicilio_calle], [domicilio_numero], [telefono], [email], [fecha_registro], [barrio], [tipo_cliente], [estado_cliente], [borrado]) VALUES (14, NULL, N'Dietetica Anahi', N'Anahi Sosa', N'Perón', 1157, N'0351-450598', N'psosaadietetica@gmail.com', CAST(N'2018-05-07' AS Date), 5, 1, 1, 0)
GO
INSERT [dbo].[Clientes] ([id_cliente], [cuit], [nombre_local], [nombre_cliente], [domicilio_calle], [domicilio_numero], [telefono], [email], [fecha_registro], [barrio], [tipo_cliente], [estado_cliente], [borrado]) VALUES (15, NULL, N'Holy Seed', N'Rosa Zabala', N'San Lorenzo', 510, N'0351-4587009', N'holyseedmoon@gmail.com', CAST(N'2018-11-28' AS Date), 4, 2, 1, 0)
GO
INSERT [dbo].[Clientes] ([id_cliente], [cuit], [nombre_local], [nombre_cliente], [domicilio_calle], [domicilio_numero], [telefono], [email], [fecha_registro], [barrio], [tipo_cliente], [estado_cliente], [borrado]) VALUES (16, NULL, N'Salud Hoy', N'Dario Brites', N'Av. Pueyrredón', 985, N'0351-15145805', N'vidasaanainsumos@gmail.com', CAST(N'2018-11-28' AS Date), 21, 2, 1, 0)
GO
INSERT [dbo].[Clientes] ([id_cliente], [cuit], [nombre_local], [nombre_cliente], [domicilio_calle], [domicilio_numero], [telefono], [email], [fecha_registro], [barrio], [tipo_cliente], [estado_cliente], [borrado]) VALUES (17, NULL, N'Dietetica San Lorenzo', N'Sofía Meinas', N'Perú', 320, N'0351-4519772', N'dieteticasanlorenzo@gmail.com', CAST(N'2019-03-08' AS Date), 25, 2, 1, 0)
GO
INSERT [dbo].[Clientes] ([id_cliente], [cuit], [nombre_local], [nombre_cliente], [domicilio_calle], [domicilio_numero], [telefono], [email], [fecha_registro], [barrio], [tipo_cliente], [estado_cliente], [borrado]) VALUES (18, NULL, N'Mundo Salud', N'Josefina Ariza', N'Independiente', 1828, N'0351-15360028', N'mundosalud_josef@gmail.com', CAST(N'2019-03-28' AS Date), 4, 1, 1, 0)
GO
INSERT [dbo].[Clientes] ([id_cliente], [cuit], [nombre_local], [nombre_cliente], [domicilio_calle], [domicilio_numero], [telefono], [email], [fecha_registro], [barrio], [tipo_cliente], [estado_cliente], [borrado]) VALUES (19, NULL, N'Comunidad Crecer', N'Thom Yorke', N'Obispo Trejo', 570, N'0351-4588755', N'saludcomunidad_crecer@gmail.com', CAST(N'2018-03-12' AS Date), 10, 3, 1, 0)
GO
INSERT [dbo].[Clientes] ([id_cliente], [cuit], [nombre_local], [nombre_cliente], [domicilio_calle], [domicilio_numero], [telefono], [email], [fecha_registro], [barrio], [tipo_cliente], [estado_cliente], [borrado]) VALUES (20, NULL, N'Patagonia', N'Camila Maldonado', N'Entre Rios', 386, N'0351-4598800', N'patagonia_dietetica@gmail.com', CAST(N'2018-01-01' AS Date), 7, 1, 1, 0)
GO
INSERT [dbo].[Clientes] ([id_cliente], [cuit], [nombre_local], [nombre_cliente], [domicilio_calle], [domicilio_numero], [telefono], [email], [fecha_registro], [barrio], [tipo_cliente], [estado_cliente], [borrado]) VALUES (21, NULL, N'Pato Azul', N'Arturo Viñas', N'San Martín', 788, N'0351-4514753', N'patoazul@gmail.com', CAST(N'2019-09-03' AS Date), 1, 1, 1, 0)
GO
INSERT [dbo].[Clientes] ([id_cliente], [cuit], [nombre_local], [nombre_cliente], [domicilio_calle], [domicilio_numero], [telefono], [email], [fecha_registro], [barrio], [tipo_cliente], [estado_cliente], [borrado]) VALUES (22, NULL, N'Vida Sana', N'Maria Vegas', N'Oncativo', 1454, N'0351-4518013', N'vidasanaproductos@gmail.com', CAST(N'2019-01-01' AS Date), 2, 1, 1, 0)
GO
INSERT [dbo].[Clientes] ([id_cliente], [cuit], [nombre_local], [nombre_cliente], [domicilio_calle], [domicilio_numero], [telefono], [email], [fecha_registro], [barrio], [tipo_cliente], [estado_cliente], [borrado]) VALUES (23, NULL, N'Amanecer', N'Esmeralda Di Pietro', N'Santa Fé', 5120, N'0351-159913445', N'dipietroventa@gmail.com', CAST(N'2017-08-13' AS Date), 3, 3, 1, 0)
GO
INSERT [dbo].[Clientes] ([id_cliente], [cuit], [nombre_local], [nombre_cliente], [domicilio_calle], [domicilio_numero], [telefono], [email], [fecha_registro], [barrio], [tipo_cliente], [estado_cliente], [borrado]) VALUES (24, NULL, N'Dietetica Anahi', N'Anahi Sosa', N'Perón', 1157, N'0351-450598', N'psosaadietetica@gmail.com', CAST(N'2018-05-07' AS Date), 5, 1, 1, 0)
GO
INSERT [dbo].[Clientes] ([id_cliente], [cuit], [nombre_local], [nombre_cliente], [domicilio_calle], [domicilio_numero], [telefono], [email], [fecha_registro], [barrio], [tipo_cliente], [estado_cliente], [borrado]) VALUES (25, NULL, N'Holy Seed', N'Rosa Zabala', N'San Lorenzo', 510, N'0351-4587009', N'holyseedmoon@gmail.com', CAST(N'2018-11-28' AS Date), 4, 2, 1, 0)
GO
INSERT [dbo].[Clientes] ([id_cliente], [cuit], [nombre_local], [nombre_cliente], [domicilio_calle], [domicilio_numero], [telefono], [email], [fecha_registro], [barrio], [tipo_cliente], [estado_cliente], [borrado]) VALUES (26, NULL, N'Salud Hoy', N'Dario Brites', N'Av. Pueyrredón', 985, N'0351-15145805', N'vidasaanainsumos@gmail.com', CAST(N'2018-11-28' AS Date), 21, 2, 1, 0)
GO
INSERT [dbo].[Clientes] ([id_cliente], [cuit], [nombre_local], [nombre_cliente], [domicilio_calle], [domicilio_numero], [telefono], [email], [fecha_registro], [barrio], [tipo_cliente], [estado_cliente], [borrado]) VALUES (27, NULL, N'Dietetica San Lorenzo', N'Sofía Meinas', N'Perú', 320, N'0351-4519772', N'dieteticasanlorenzo@gmail.com', CAST(N'2019-03-08' AS Date), 25, 2, 1, 0)
GO
INSERT [dbo].[Clientes] ([id_cliente], [cuit], [nombre_local], [nombre_cliente], [domicilio_calle], [domicilio_numero], [telefono], [email], [fecha_registro], [barrio], [tipo_cliente], [estado_cliente], [borrado]) VALUES (28, NULL, N'Mundo Salud', N'Josefina Ariza', N'Independiente', 1828, N'0351-15360028', N'mundosalud_josef@gmail.com', CAST(N'2019-03-28' AS Date), 4, 1, 1, 0)
GO
INSERT [dbo].[Clientes] ([id_cliente], [cuit], [nombre_local], [nombre_cliente], [domicilio_calle], [domicilio_numero], [telefono], [email], [fecha_registro], [barrio], [tipo_cliente], [estado_cliente], [borrado]) VALUES (29, NULL, N'Comunidad Crecer', N'Thom Yorke', N'Obispo Trejo', 570, N'0351-4588755', N'saludcomunidad_crecer@gmail.com', CAST(N'2018-03-12' AS Date), 10, 3, 1, 0)
GO
INSERT [dbo].[Clientes] ([id_cliente], [cuit], [nombre_local], [nombre_cliente], [domicilio_calle], [domicilio_numero], [telefono], [email], [fecha_registro], [barrio], [tipo_cliente], [estado_cliente], [borrado]) VALUES (30, NULL, N'Patagonia', N'Camila Maldonado', N'Entre Rios', 386, N'0351-4598800', N'patagonia_dietetica@gmail.com', CAST(N'2018-01-01' AS Date), 7, 1, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Clientes] OFF
GO
SET IDENTITY_INSERT [dbo].[EstadoCliente] ON 
GO
INSERT [dbo].[EstadoCliente] ([id_estadoC], [descripcion], [borrado]) VALUES (1, N'En Alta', 0)
GO
INSERT [dbo].[EstadoCliente] ([id_estadoC], [descripcion], [borrado]) VALUES (2, N'De Baja', 0)
GO
SET IDENTITY_INSERT [dbo].[EstadoCliente] OFF
GO
SET IDENTITY_INSERT [dbo].[EstadoProducto] ON 
GO
INSERT [dbo].[EstadoProducto] ([id_estadoPr], [descripcion], [borrado]) VALUES (1, N'En produccion', 0)
GO
INSERT [dbo].[EstadoProducto] ([id_estadoPr], [descripcion], [borrado]) VALUES (2, N'Fuera de produccion', 0)
GO
SET IDENTITY_INSERT [dbo].[EstadoProducto] OFF
GO
SET IDENTITY_INSERT [dbo].[Productos] ON 
GO
INSERT [dbo].[Productos] ([id_producto], [nombre], [unidad], [fecha_registro], [estado], [categoria], [precio], [stock], [borrado]) VALUES (1, N'Peperina', NULL, NULL, NULL, NULL, CAST(643.54 AS Decimal(10, 2)), 150, 0)
GO
INSERT [dbo].[Productos] ([id_producto], [nombre], [unidad], [fecha_registro], [estado], [categoria], [precio], [stock], [borrado]) VALUES (2, N'Poleo', NULL, NULL, NULL, NULL, CAST(339.93 AS Decimal(10, 2)), 250, 0)
GO
INSERT [dbo].[Productos] ([id_producto], [nombre], [unidad], [fecha_registro], [estado], [categoria], [precio], [stock], [borrado]) VALUES (3, N'Palo Amarillo', NULL, NULL, NULL, NULL, CAST(189.50 AS Decimal(10, 2)), 45, 0)
GO
INSERT [dbo].[Productos] ([id_producto], [nombre], [unidad], [fecha_registro], [estado], [categoria], [precio], [stock], [borrado]) VALUES (4, N'Jarilla', NULL, NULL, NULL, NULL, CAST(175.90 AS Decimal(10, 2)), 95, 0)
GO
INSERT [dbo].[Productos] ([id_producto], [nombre], [unidad], [fecha_registro], [estado], [categoria], [precio], [stock], [borrado]) VALUES (5, N'Incayuyo', NULL, NULL, NULL, NULL, CAST(542.57 AS Decimal(10, 2)), 120, 0)
GO
INSERT [dbo].[Productos] ([id_producto], [nombre], [unidad], [fecha_registro], [estado], [categoria], [precio], [stock], [borrado]) VALUES (6, N'Té de Burro', NULL, NULL, NULL, NULL, CAST(242.56 AS Decimal(10, 2)), 145, 0)
GO
SET IDENTITY_INSERT [dbo].[Productos] OFF
GO
SET IDENTITY_INSERT [dbo].[TipoCliente] ON 
GO
INSERT [dbo].[TipoCliente] ([id_tipoC], [descripcion], [borrado]) VALUES (1, N'Mayorista', 0)
GO
INSERT [dbo].[TipoCliente] ([id_tipoC], [descripcion], [borrado]) VALUES (2, N'Minorista', 0)
GO
INSERT [dbo].[TipoCliente] ([id_tipoC], [descripcion], [borrado]) VALUES (3, N'Consumidor', 0)
GO
SET IDENTITY_INSERT [dbo].[TipoCliente] OFF
GO
INSERT [dbo].[TipoFactura] ([id_tipoFactura], [descripcion], [borrado]) VALUES (N'A', N'Factura del tipo A', 0)
GO
INSERT [dbo].[TipoFactura] ([id_tipoFactura], [descripcion], [borrado]) VALUES (N'B', N'Factura del tipo B', 0)
GO
INSERT [dbo].[TipoFactura] ([id_tipoFactura], [descripcion], [borrado]) VALUES (N'C', N'Factura del tipo C', 0)
GO
ALTER TABLE [dbo].[Barrios] ADD  DEFAULT ((0)) FOR [borrado]
GO
ALTER TABLE [dbo].[Categorias] ADD  DEFAULT ((0)) FOR [borrado]
GO
ALTER TABLE [dbo].[Ciudades] ADD  DEFAULT ((0)) FOR [borrado]
GO
ALTER TABLE [dbo].[Clientes] ADD  DEFAULT ((0)) FOR [borrado]
GO
ALTER TABLE [dbo].[EstadoCliente] ADD  DEFAULT ((0)) FOR [borrado]
GO
ALTER TABLE [dbo].[EstadoProducto] ADD  DEFAULT ((0)) FOR [borrado]
GO
ALTER TABLE [dbo].[Facturas] ADD  CONSTRAINT [DF__Ventas__borrado__66603565]  DEFAULT ((0)) FOR [borrado]
GO
ALTER TABLE [dbo].[FacturasDetalle] ADD  CONSTRAINT [DF__DetVentas__borra__6B24EA82]  DEFAULT ((0)) FOR [borrado]
GO
ALTER TABLE [dbo].[Productos] ADD  DEFAULT ((0)) FOR [stock]
GO
ALTER TABLE [dbo].[Productos] ADD  DEFAULT ((0)) FOR [borrado]
GO
ALTER TABLE [dbo].[TipoCliente] ADD  DEFAULT ((0)) FOR [borrado]
GO
ALTER TABLE [dbo].[TipoFactura] ADD  DEFAULT ((0)) FOR [borrado]
GO
ALTER TABLE [dbo].[Barrios]  WITH CHECK ADD  CONSTRAINT [FK_Ciudad] FOREIGN KEY([ciudad])
REFERENCES [dbo].[Ciudades] ([id_ciudad])
GO
ALTER TABLE [dbo].[Barrios] CHECK CONSTRAINT [FK_Ciudad]
GO
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_barrioC] FOREIGN KEY([barrio])
REFERENCES [dbo].[Barrios] ([id_barrio])
GO
ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [FK_barrioC]
GO
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_estado_cliente] FOREIGN KEY([estado_cliente])
REFERENCES [dbo].[EstadoCliente] ([id_estadoC])
GO
ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [FK_estado_cliente]
GO
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_tipo_cliente] FOREIGN KEY([tipo_cliente])
REFERENCES [dbo].[TipoCliente] ([id_tipoC])
GO
ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [FK_tipo_cliente]
GO
ALTER TABLE [dbo].[Facturas]  WITH CHECK ADD  CONSTRAINT [FK_cliente_ventas] FOREIGN KEY([cliente])
REFERENCES [dbo].[Clientes] ([id_cliente])
GO
ALTER TABLE [dbo].[Facturas] CHECK CONSTRAINT [FK_cliente_ventas]
GO
ALTER TABLE [dbo].[Facturas]  WITH CHECK ADD  CONSTRAINT [FK_tipoFactura_ventas] FOREIGN KEY([tipoFactura])
REFERENCES [dbo].[TipoFactura] ([id_tipoFactura])
GO
ALTER TABLE [dbo].[Facturas] CHECK CONSTRAINT [FK_tipoFactura_ventas]
GO
ALTER TABLE [dbo].[FacturasDetalle]  WITH CHECK ADD  CONSTRAINT [FK_producto_detVenta] FOREIGN KEY([id_producto])
REFERENCES [dbo].[Productos] ([id_producto])
GO
ALTER TABLE [dbo].[FacturasDetalle] CHECK CONSTRAINT [FK_producto_detVenta]
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD  CONSTRAINT [FK_categoria] FOREIGN KEY([categoria])
REFERENCES [dbo].[Categorias] ([id_categoria])
GO
ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [FK_categoria]
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD  CONSTRAINT [FK_estadoProducto] FOREIGN KEY([estado])
REFERENCES [dbo].[EstadoProducto] ([id_estadoPr])
GO
ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [FK_estadoProducto]
GO
USE [master]
GO
ALTER DATABASE [SistemaVentas] SET  READ_WRITE 
GO
