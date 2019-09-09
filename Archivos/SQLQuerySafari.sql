/****** Object:  Table [dbo].[cita]    Script Date: 05/08/2019 23:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[cita](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [datetime] NOT NULL,
	[medico_legajo] [int] NOT NULL,
	[paciente_codigo] [int] NOT NULL,
	[sala_numero] [int] NOT NULL,
	[tipo_servicio_id] [int] NOT NULL,
	[estado] [varchar](50) NOT NULL,
	[created_by] [int] NOT NULL,
	[created_date] [datetime] NOT NULL,
	[changed_by] [int] NULL,
	[changed_date] [datetime] NULL,
	[deleted_by] [int] NULL,
	[deleted_date] [datetime] NULL,
	[deleted] [bit] NULL,
CONSTRAINT [PK_cita] PRIMARY KEY CLUSTERED
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[cliente]    Script Date: 05/08/2019 23:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[cliente](
	[codigo] [int] IDENTITY(1,1) NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[email] [varchar](255) NOT NULL,
	[telefono] [varchar](50) NOT NULL,
	[url] [varchar](255) NULL,
	[fecha_nacimiento] [date] NOT NULL,
	[domicilio] [varchar](255) NOT NULL,
CONSTRAINT [PK_cliente] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[especie]    Script Date: 05/08/2019 23:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[especie](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
CONSTRAINT [PK_especie] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[medico]    Script Date: 05/08/2019 23:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[medico](
	[legajo] [int] IDENTITY(1,1) NOT NULL,
	[tipo_matricula] [char](2) NOT NULL,
	[numero_matricula] [int] NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[especialidad] [varchar](255) NOT NULL,
	[fecha_nacimiento] [date] NOT NULL,
	[email] [varchar](255) NOT NULL,
	[telefono] [varchar](50) NOT NULL,
CONSTRAINT [PK_medico] PRIMARY KEY CLUSTERED 
(
	[legajo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[movimiento]    Script Date: 05/08/2019 23:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[movimiento](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [datetime] NOT NULL,
	[cliente_codigo] [int] NOT NULL,
	[tipo_movimiento_id] [int] NOT NULL,
	[valor] [decimal](10, 2) NOT NULL,
CONSTRAINT [PK_movimiento] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[paciente]    Script Date: 05/08/2019 23:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[paciente](
	[codigo] [int] IDENTITY(1,1) NOT NULL,
	[cliente_codigo] [int] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[fecha_nacimiento] [date] NOT NULL,
	[especie_id] [int] NOT NULL,
	[observacion] [text] NULL,
CONSTRAINT [PK_paciente] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[precio]    Script Date: 05/08/2019 23:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[precio](
	[tipo_servicio_id] [int] NOT NULL,
	[fecha_desde] [date] NOT NULL,
	[fecha_hasta] [date] NOT NULL,
	[valor] [decimal](10, 2) NOT NULL,
CONSTRAINT [PK_precio] PRIMARY KEY CLUSTERED 
(
	[tipo_servicio_id] ASC,
	[fecha_desde] ASC,
	[fecha_hasta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[rol]    Script Date: 05/08/2019 23:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[rol](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
CONSTRAINT [PK_rol] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[sala]    Script Date: 05/08/2019 23:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[sala](
	[numero] [int] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[tipo_sala] [varchar](50) NOT NULL,
CONSTRAINT [PK_sala] PRIMARY KEY CLUSTERED 
(
	[numero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tipo_movimiento] Script Date: 05/08/2019 23:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tipo_movimiento](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[multiplicador] [smallint] NOT NULL,
CONSTRAINT [PK_tipo_movimiento] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tipo_servicio] Script Date: 05/08/2019 23:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tipo_servicio](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
CONSTRAINT [PK_tipo_servicio] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[usuario]    Script Date: 05/08/2019 23:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[usuario](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[clave] [varchar](50) NOT NULL,
CONSTRAINT [PK_usuario] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[usuario_rol]    Script Date: 05/08/2019 23:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuario_rol](
	[usuario_id] [int] NOT NULL,
	[rol_id] [int] NOT NULL,
CONSTRAINT [PK_usuario_rol] PRIMARY KEY CLUSTERED 
(
	[usuario_id] ASC,
	[rol_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[cita] ADD  CONSTRAINT [DF_cita_deleted]  DEFAULT ((0)) FOR [deleted]
GO
ALTER TABLE [dbo].[cita]  WITH CHECK ADD  CONSTRAINT [FK_cita_medico] FOREIGN KEY([medico_legajo])
REFERENCES [dbo].[medico] ([legajo])
GO
ALTER TABLE [dbo].[cita] CHECK CONSTRAINT [FK_cita_medico]
GO
ALTER TABLE [dbo].[cita]  WITH CHECK ADD  CONSTRAINT [FK_cita_paciente] FOREIGN KEY([paciente_codigo])
REFERENCES [dbo].[paciente] ([codigo])
GO
ALTER TABLE [dbo].[cita] CHECK CONSTRAINT [FK_cita_paciente]
GO
ALTER TABLE [dbo].[cita]  WITH CHECK ADD  CONSTRAINT [FK_cita_sala] FOREIGN KEY([sala_numero])
REFERENCES [dbo].[sala] ([numero])
GO
ALTER TABLE [dbo].[cita] CHECK CONSTRAINT [FK_cita_sala]
GO
ALTER TABLE [dbo].[cita]  WITH CHECK ADD  CONSTRAINT [FK_cita_tipo_servicio] FOREIGN KEY([tipo_servicio_id])
REFERENCES [dbo].[tipo_servicio] ([id])
GO
ALTER TABLE [dbo].[cita] CHECK CONSTRAINT [FK_cita_tipo_servicio]
GO
ALTER TABLE [dbo].[movimiento]  WITH CHECK ADD CONSTRAINT [FK_movimiento_cliente] FOREIGN KEY([cliente_codigo])
REFERENCES [dbo].[cliente] ([codigo])
GO
ALTER TABLE [dbo].[movimiento] CHECK CONSTRAINT [FK_movimiento_cliente]
GO
ALTER TABLE [dbo].[movimiento]  WITH CHECK ADD CONSTRAINT [FK_movimiento_tipo_movimiento] FOREIGN KEY([tipo_movimiento_id])
REFERENCES [dbo].[tipo_movimiento] ([id])
GO
ALTER TABLE [dbo].[movimiento] CHECK CONSTRAINT [FK_movimiento_tipo_movimiento]
GO
ALTER TABLE [dbo].[paciente]  WITH CHECK ADD CONSTRAINT [FK_paciente_cliente] FOREIGN KEY([cliente_codigo])
REFERENCES [dbo].[cliente] ([codigo])
GO
ALTER TABLE [dbo].[paciente] CHECK CONSTRAINT [FK_paciente_cliente]
GO
ALTER TABLE [dbo].[paciente]  WITH CHECK ADD CONSTRAINT [FK_paciente_especie] FOREIGN KEY([especie_id])
REFERENCES [dbo].[especie] ([id])
GO
ALTER TABLE [dbo].[paciente] CHECK CONSTRAINT [FK_paciente_especie]
GO
ALTER TABLE [dbo].[precio]  WITH CHECK ADD CONSTRAINT [FK_precio_tipo_servicio] FOREIGN KEY([tipo_servicio_id])
REFERENCES [dbo].[tipo_servicio] ([id])
GO
ALTER TABLE [dbo].[precio] CHECK CONSTRAINT [FK_precio_tipo_servicio]
GO
ALTER TABLE [dbo].[usuario_rol]  WITH CHECK ADD CONSTRAINT [FK_usuario_rol_rol] FOREIGN KEY([rol_id])
REFERENCES [dbo].[rol] ([id])
GO
ALTER TABLE [dbo].[usuario_rol] CHECK CONSTRAINT [FK_usuario_rol_rol]
GO
ALTER TABLE [dbo].[usuario_rol]  WITH CHECK ADD CONSTRAINT [FK_usuario_rol_usuario] FOREIGN KEY([usuario_id])
REFERENCES [dbo].[usuario] ([id])
GO
ALTER TABLE [dbo].[usuario_rol] CHECK CONSTRAINT [FK_usuario_rol_usuario]
GO
ALTER TABLE [dbo].[cita]  WITH CHECK ADD  CONSTRAINT [CK_cita] CHECK  (([estado]='Cancelado' OR [estado]='Realizado' OR [estado]='Confirmado' OR [estado]='Reservado'))
GO
ALTER TABLE [dbo].[cita] CHECK CONSTRAINT [CK_cita]
GO
ALTER TABLE [dbo].[medico]  WITH CHECK ADD CONSTRAINT [CK_medico] CHECK (([tipo_matricula]='MP' OR [tipo_matricula]='MN'))
GO
ALTER TABLE [dbo].[medico] CHECK CONSTRAINT [CK_medico]
GO
ALTER TABLE [dbo].[sala]  WITH CHECK ADD CONSTRAINT [CK_sala] CHECK (([tipo_sala]='Recuperación' OR [tipo_sala]='Quirófano' OR [tipo_sala]='Vacunatorio'))
GO
ALTER TABLE [dbo].[sala] CHECK CONSTRAINT [CK_sala]
GO
