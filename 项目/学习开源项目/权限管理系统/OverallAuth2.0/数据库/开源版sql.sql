USE [ProjectManage_Starter]
GO
/****** Object:  Table [dbo].[Sys_Button]    Script Date: 2024/12/6 9:02:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_Button](
	[ButtonId] [int] IDENTITY(1,1) NOT NULL,
	[ButtonName] [varchar](50) NOT NULL,
	[ButtonKey] [varchar](50) NOT NULL,
	[ButtonStyleId] [int] NOT NULL,
	[OrderBy] [int] NULL,
	[MenuId] [int] NOT NULL,
	[CreateTime] [datetime] NULL,
	[CreateUser] [varchar](50) NULL,
 CONSTRAINT [PK_Button] PRIMARY KEY CLUSTERED 
(
	[ButtonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sys_ButtonRole]    Script Date: 2024/12/6 9:02:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_ButtonRole](
	[ButtonRoleId] [int] IDENTITY(1,1) NOT NULL,
	[MenuId] [int] NOT NULL,
	[ButtonId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
	[CreateTime] [datetime] NULL,
	[CreateUser] [varchar](50) NULL,
 CONSTRAINT [PK_ButtonRole] PRIMARY KEY CLUSTERED 
(
	[ButtonRoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sys_ButtonStyle]    Script Date: 2024/12/6 9:02:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_ButtonStyle](
	[ButtonStyleId] [int] IDENTITY(1,1) NOT NULL,
	[BordersStyle] [varchar](100) NULL,
	[Size] [varchar](50) NULL,
	[Types] [varchar](50) NULL,
	[Icon] [varchar](20) NULL,
	[ButtonStyleName] [varchar](50) NOT NULL,
	[OrderBy] [int] NULL,
	[Borders] [varchar](50) NULL,
	[IsRadius] [bit] NULL,
	[CreateTime] [datetime] NULL,
	[CreateUser] [varchar](50) NULL,
 CONSTRAINT [PK_ButtonStyle] PRIMARY KEY CLUSTERED 
(
	[ButtonStyleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sys_Department]    Script Date: 2024/12/6 9:02:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_Department](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentName] [varchar](50) NULL,
	[Pid] [int] NULL,
	[Sort] [int] NULL,
 CONSTRAINT [PK_Sys_Department] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sys_ExceptionLog]    Script Date: 2024/12/6 9:02:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_ExceptionLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ExceptionType] [int] NOT NULL,
	[ExceptionMsg] [text] NOT NULL,
	[ExceptionTime] [datetime] NOT NULL,
	[OperateUserName] [nvarchar](50) NOT NULL,
	[OperateUserId] [nvarchar](50) NOT NULL,
	[IsHandle] [bit] NOT NULL,
	[HandleUserName] [nvarchar](50) NULL,
	[HandleUserId] [nvarchar](50) NULL,
 CONSTRAINT [PK_Sys_ErrorLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sys_Menu]    Script Date: 2024/12/6 9:02:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_Menu](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MenuUrl] [varchar](50) NOT NULL,
	[MenuIcon] [varchar](50) NOT NULL,
	[MenuTitle] [varchar](50) NOT NULL,
	[Pid] [int] NOT NULL,
	[IsOpen] [bit] NULL,
	[CreateTime] [datetime] NULL,
	[CreateUser] [varchar](50) NULL,
	[Component] [varchar](500) NULL,
	[Path] [varchar](500) NULL,
	[RequireAuth] [bit] NULL,
	[Name] [varchar](500) NULL,
	[Redirect] [varchar](500) NULL,
 CONSTRAINT [PK_Menu] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sys_MenuRoleRelation]    Script Date: 2024/12/6 9:02:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_MenuRoleRelation](
	[MenuRoleId] [int] IDENTITY(1,1) NOT NULL,
	[MenuId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
	[CreateTime] [datetime] NULL,
	[CreateUser] [varchar](50) NULL,
 CONSTRAINT [PK_Sys_MenuRoleRelation] PRIMARY KEY CLUSTERED 
(
	[MenuRoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sys_MenuTableCols]    Script Date: 2024/12/6 9:02:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_MenuTableCols](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MenuId] [int] NOT NULL,
	[FieldName] [varchar](255) NOT NULL,
	[FieldType] [varchar](255) NOT NULL,
	[FieldTitle] [varchar](255) NOT NULL,
	[FieldOrderBy] [int] NOT NULL,
	[FieldWidth] [int] NULL,
	[FieldSort] [varchar](50) NULL,
	[FieldCustomSlot] [varchar](50) NULL,
	[FieldAlign] [varchar](50) NULL,
	[FieldFixed] [varchar](50) NULL,
	[FieldMinWidth] [int] NULL,
	[FieldEllipsisTooltip] [bit] NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[CreateUser] [varchar](50) NOT NULL,
	[IsSystemData] [int] NULL,
	[DataRowAuthType] [int] NOT NULL,
	[DataRowAuthField] [varchar](255) NULL,
	[DataRowAuthFieldName] [varchar](255) NULL,
 CONSTRAINT [PK__Sys_Menu__3214EC0754506B6A] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sys_MenuTableColsRole]    Script Date: 2024/12/6 9:02:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_MenuTableColsRole](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MenuId] [int] NOT NULL,
	[MenuTableColsId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[CreateUser] [varchar](50) NOT NULL,
 CONSTRAINT [PK__Sys_Menu__3214EC07183B2F00] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sys_MenuTableRowAuth]    Script Date: 2024/12/6 9:02:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_MenuTableRowAuth](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MenuId] [int] NOT NULL,
	[RuleJson] [text] NOT NULL,
	[IsOpen] [bit] NOT NULL,
	[Remark] [varchar](255) NULL,
	[Sort] [int] NULL,
	[CreateTime] [datetime] NOT NULL,
	[CreateUser] [varchar](50) NOT NULL,
 CONSTRAINT [PK__Sys_Menu__3214EC07AEAC0E63] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sys_MenuTableRowAuthConfig]    Script Date: 2024/12/6 9:02:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_MenuTableRowAuthConfig](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MenuId] [int] NOT NULL,
	[PermissionsField] [varchar](50) NOT NULL,
	[PermissionsFieldName] [varchar](255) NOT NULL,
	[ConditionalEquationValue] [int] NOT NULL,
	[ShowControl] [int] NOT NULL,
	[ShowControlDataSource] [int] NOT NULL,
	[IsOpen] [bit] NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[CreateUser] [varchar](50) NOT NULL,
 CONSTRAINT [PK__Sys_Menu__3214EC07976D5966] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sys_Role]    Script Date: 2024/12/6 9:02:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_Role](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [varchar](50) NOT NULL,
	[CreateTime] [datetime] NULL,
	[CreateUser] [varchar](50) NULL,
 CONSTRAINT [PK_Sys_Role] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sys_User]    Script Date: 2024/12/6 9:02:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Age] [int] NULL,
	[Sex] [int] NULL,
	[DepartmentId] [int] NOT NULL,
	[CreateTime] [datetime] NULL,
	[CreateUser] [varchar](50) NULL,
 CONSTRAINT [PK_Sys_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sys_UserRoleRelation]    Script Date: 2024/12/6 9:02:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_UserRoleRelation](
	[UserRoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NULL,
	[UserId] [int] NULL,
	[CreateTime] [datetime] NULL,
	[CreateUser] [varchar](50) NULL,
 CONSTRAINT [PK_Sys_UserRoleRelation] PRIMARY KEY CLUSTERED 
(
	[UserRoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Sys_Button] ON 

INSERT [dbo].[Sys_Button] ([ButtonId], [ButtonName], [ButtonKey], [ButtonStyleId], [OrderBy], [MenuId], [CreateTime], [CreateUser]) VALUES (15, N'新增菜单', N'AddMenuKey', 24, 1, 5, CAST(N'2024-01-18T16:36:32.333' AS DateTime), N'1')
INSERT [dbo].[Sys_Button] ([ButtonId], [ButtonName], [ButtonKey], [ButtonStyleId], [OrderBy], [MenuId], [CreateTime], [CreateUser]) VALUES (16, N'删除菜单', N'DelMenuKey', 33, 2, 5, CAST(N'2024-01-18T16:36:18.927' AS DateTime), N'1')
INSERT [dbo].[Sys_Button] ([ButtonId], [ButtonName], [ButtonKey], [ButtonStyleId], [OrderBy], [MenuId], [CreateTime], [CreateUser]) VALUES (17, N'测试页面间传值', N'Key1', 37, 1, 40, CAST(N'2023-11-20T17:36:53.830' AS DateTime), N'1')
INSERT [dbo].[Sys_Button] ([ButtonId], [ButtonName], [ButtonKey], [ButtonStyleId], [OrderBy], [MenuId], [CreateTime], [CreateUser]) VALUES (18, N'测试页面间传值2', N'Key2', 38, 2, 40, CAST(N'2023-11-20T17:37:14.037' AS DateTime), N'1')
INSERT [dbo].[Sys_Button] ([ButtonId], [ButtonName], [ButtonKey], [ButtonStyleId], [OrderBy], [MenuId], [CreateTime], [CreateUser]) VALUES (21, N'新增用户', N'AddUserKey', 28, 1, 37, CAST(N'2024-01-21T00:24:35.823' AS DateTime), N'1')
INSERT [dbo].[Sys_Button] ([ButtonId], [ButtonName], [ButtonKey], [ButtonStyleId], [OrderBy], [MenuId], [CreateTime], [CreateUser]) VALUES (22, N'新增按钮', N'AddButtonKey', 24, 1, 48, CAST(N'2023-12-07T15:52:53.000' AS DateTime), N'1')
INSERT [dbo].[Sys_Button] ([ButtonId], [ButtonName], [ButtonKey], [ButtonStyleId], [OrderBy], [MenuId], [CreateTime], [CreateUser]) VALUES (23, N'新增样式', N'AddButtonStyleKey', 29, 1, 35, CAST(N'2023-12-07T16:20:16.003' AS DateTime), N'1')
INSERT [dbo].[Sys_Button] ([ButtonId], [ButtonName], [ButtonKey], [ButtonStyleId], [OrderBy], [MenuId], [CreateTime], [CreateUser]) VALUES (24, N'新增角色', N'AddRoleKey', 44, 1, 39, CAST(N'2023-12-07T17:00:06.270' AS DateTime), N'1')
INSERT [dbo].[Sys_Button] ([ButtonId], [ButtonName], [ButtonKey], [ButtonStyleId], [OrderBy], [MenuId], [CreateTime], [CreateUser]) VALUES (25, N'新增数据列', N'AddDataColsKey', 29, 1, 71, CAST(N'2023-12-07T17:09:26.797' AS DateTime), N'1')
INSERT [dbo].[Sys_Button] ([ButtonId], [ButtonName], [ButtonKey], [ButtonStyleId], [OrderBy], [MenuId], [CreateTime], [CreateUser]) VALUES (26, N'333', N'333', 45, 0, 5, CAST(N'2024-01-21T01:43:59.177' AS DateTime), N'1')
INSERT [dbo].[Sys_Button] ([ButtonId], [ButtonName], [ButtonKey], [ButtonStyleId], [OrderBy], [MenuId], [CreateTime], [CreateUser]) VALUES (27, N'344', N'444', 44, 0, 5, CAST(N'2024-01-21T01:45:06.383' AS DateTime), N'2')
INSERT [dbo].[Sys_Button] ([ButtonId], [ButtonName], [ButtonKey], [ButtonStyleId], [OrderBy], [MenuId], [CreateTime], [CreateUser]) VALUES (28, N'5555', N'5555', 45, 0, 52, CAST(N'2024-01-24T08:17:23.177' AS DateTime), N'1')
SET IDENTITY_INSERT [dbo].[Sys_Button] OFF
SET IDENTITY_INSERT [dbo].[Sys_ButtonRole] ON 

INSERT [dbo].[Sys_ButtonRole] ([ButtonRoleId], [MenuId], [ButtonId], [RoleId], [CreateTime], [CreateUser]) VALUES (12, 40, 17, 1, CAST(N'2023-11-23T15:03:57.637' AS DateTime), N'1')
INSERT [dbo].[Sys_ButtonRole] ([ButtonRoleId], [MenuId], [ButtonId], [RoleId], [CreateTime], [CreateUser]) VALUES (13, 40, 18, 1, CAST(N'2023-11-23T15:03:57.637' AS DateTime), N'1')
INSERT [dbo].[Sys_ButtonRole] ([ButtonRoleId], [MenuId], [ButtonId], [RoleId], [CreateTime], [CreateUser]) VALUES (41, 5, 15, 1, CAST(N'2024-01-21T00:25:33.513' AS DateTime), N'1')
INSERT [dbo].[Sys_ButtonRole] ([ButtonRoleId], [MenuId], [ButtonId], [RoleId], [CreateTime], [CreateUser]) VALUES (42, 5, 16, 1, CAST(N'2024-01-21T00:25:33.513' AS DateTime), N'1')
INSERT [dbo].[Sys_ButtonRole] ([ButtonRoleId], [MenuId], [ButtonId], [RoleId], [CreateTime], [CreateUser]) VALUES (43, 35, 23, 1, CAST(N'2024-01-21T00:25:38.167' AS DateTime), N'1')
INSERT [dbo].[Sys_ButtonRole] ([ButtonRoleId], [MenuId], [ButtonId], [RoleId], [CreateTime], [CreateUser]) VALUES (44, 48, 22, 1, CAST(N'2024-01-21T00:25:40.217' AS DateTime), N'1')
INSERT [dbo].[Sys_ButtonRole] ([ButtonRoleId], [MenuId], [ButtonId], [RoleId], [CreateTime], [CreateUser]) VALUES (45, 37, 21, 1, CAST(N'2024-01-21T00:25:42.113' AS DateTime), N'1')
INSERT [dbo].[Sys_ButtonRole] ([ButtonRoleId], [MenuId], [ButtonId], [RoleId], [CreateTime], [CreateUser]) VALUES (46, 39, 24, 1, CAST(N'2024-01-21T00:25:44.050' AS DateTime), N'1')
INSERT [dbo].[Sys_ButtonRole] ([ButtonRoleId], [MenuId], [ButtonId], [RoleId], [CreateTime], [CreateUser]) VALUES (47, 71, 25, 1, CAST(N'2024-01-21T00:25:49.197' AS DateTime), N'1')
INSERT [dbo].[Sys_ButtonRole] ([ButtonRoleId], [MenuId], [ButtonId], [RoleId], [CreateTime], [CreateUser]) VALUES (48, 35, 23, 2, CAST(N'2024-01-21T00:44:10.650' AS DateTime), N'1')
INSERT [dbo].[Sys_ButtonRole] ([ButtonRoleId], [MenuId], [ButtonId], [RoleId], [CreateTime], [CreateUser]) VALUES (50, 37, 21, 2, CAST(N'2024-01-21T00:44:16.423' AS DateTime), N'1')
INSERT [dbo].[Sys_ButtonRole] ([ButtonRoleId], [MenuId], [ButtonId], [RoleId], [CreateTime], [CreateUser]) VALUES (51, 39, 24, 2, CAST(N'2024-01-21T00:44:18.370' AS DateTime), N'1')
INSERT [dbo].[Sys_ButtonRole] ([ButtonRoleId], [MenuId], [ButtonId], [RoleId], [CreateTime], [CreateUser]) VALUES (52, 40, 17, 2, CAST(N'2024-01-21T00:44:22.843' AS DateTime), N'1')
INSERT [dbo].[Sys_ButtonRole] ([ButtonRoleId], [MenuId], [ButtonId], [RoleId], [CreateTime], [CreateUser]) VALUES (53, 40, 18, 2, CAST(N'2024-01-21T00:44:22.843' AS DateTime), N'1')
INSERT [dbo].[Sys_ButtonRole] ([ButtonRoleId], [MenuId], [ButtonId], [RoleId], [CreateTime], [CreateUser]) VALUES (54, 71, 25, 2, CAST(N'2024-01-21T00:44:26.277' AS DateTime), N'1')
INSERT [dbo].[Sys_ButtonRole] ([ButtonRoleId], [MenuId], [ButtonId], [RoleId], [CreateTime], [CreateUser]) VALUES (55, 48, 22, 2, CAST(N'2024-01-21T00:45:10.207' AS DateTime), N'1')
INSERT [dbo].[Sys_ButtonRole] ([ButtonRoleId], [MenuId], [ButtonId], [RoleId], [CreateTime], [CreateUser]) VALUES (56, 52, 28, 2, CAST(N'2024-01-24T08:17:34.547' AS DateTime), N'1')
SET IDENTITY_INSERT [dbo].[Sys_ButtonRole] OFF
SET IDENTITY_INSERT [dbo].[Sys_ButtonStyle] ON 

INSERT [dbo].[Sys_ButtonStyle] ([ButtonStyleId], [BordersStyle], [Size], [Types], [Icon], [ButtonStyleName], [OrderBy], [Borders], [IsRadius], [CreateTime], [CreateUser]) VALUES (24, N'soild', N'md', N'primary', N'layui-icon-add-one', N'新增绿色', 0, N'', 0, CAST(N'2023-11-18T16:00:03.227' AS DateTime), N'1')
INSERT [dbo].[Sys_ButtonStyle] ([ButtonStyleId], [BordersStyle], [Size], [Types], [Icon], [ButtonStyleName], [OrderBy], [Borders], [IsRadius], [CreateTime], [CreateUser]) VALUES (25, N'soild', N'md', N'normal', N'layui-icon-add-one', N'新增百搭', 0, N'', 0, CAST(N'2023-11-18T16:00:31.100' AS DateTime), N'1')
INSERT [dbo].[Sys_ButtonStyle] ([ButtonStyleId], [BordersStyle], [Size], [Types], [Icon], [ButtonStyleName], [OrderBy], [Borders], [IsRadius], [CreateTime], [CreateUser]) VALUES (26, N'soild', N'md', N'', N'layui-icon-add-one', N'新增默认', 0, N'', 0, CAST(N'2023-11-18T16:00:51.283' AS DateTime), N'1')
INSERT [dbo].[Sys_ButtonStyle] ([ButtonStyleId], [BordersStyle], [Size], [Types], [Icon], [ButtonStyleName], [OrderBy], [Borders], [IsRadius], [CreateTime], [CreateUser]) VALUES (27, N'soild', N'md', N'primary', N'layui-icon-add-one', N'新增绿色圆角', 0, N'', 1, CAST(N'2023-11-18T16:01:03.227' AS DateTime), N'1')
INSERT [dbo].[Sys_ButtonStyle] ([ButtonStyleId], [BordersStyle], [Size], [Types], [Icon], [ButtonStyleName], [OrderBy], [Borders], [IsRadius], [CreateTime], [CreateUser]) VALUES (28, N'soild', N'md', N'normal', N'layui-icon-add-one', N'新增百搭圆角', 0, N'', 1, CAST(N'2023-11-18T16:01:31.100' AS DateTime), N'1')
INSERT [dbo].[Sys_ButtonStyle] ([ButtonStyleId], [BordersStyle], [Size], [Types], [Icon], [ButtonStyleName], [OrderBy], [Borders], [IsRadius], [CreateTime], [CreateUser]) VALUES (29, N'soild', N'md', N'', N'layui-icon-add-one', N'新增默认圆角', 0, N'', 1, CAST(N'2023-11-18T16:01:51.283' AS DateTime), N'1')
INSERT [dbo].[Sys_ButtonStyle] ([ButtonStyleId], [BordersStyle], [Size], [Types], [Icon], [ButtonStyleName], [OrderBy], [Borders], [IsRadius], [CreateTime], [CreateUser]) VALUES (30, N'soild', N'md', N'normal', N'layui-icon-edit', N'编辑百搭圆角', 0, N'', 1, CAST(N'2023-11-18T16:06:10.303' AS DateTime), N'1')
INSERT [dbo].[Sys_ButtonStyle] ([ButtonStyleId], [BordersStyle], [Size], [Types], [Icon], [ButtonStyleName], [OrderBy], [Borders], [IsRadius], [CreateTime], [CreateUser]) VALUES (31, N'soild', N'md', N'warm', N'layui-icon-edit', N'编辑暖色', 0, N'', 0, CAST(N'2023-11-18T16:07:13.793' AS DateTime), N'1')
INSERT [dbo].[Sys_ButtonStyle] ([ButtonStyleId], [BordersStyle], [Size], [Types], [Icon], [ButtonStyleName], [OrderBy], [Borders], [IsRadius], [CreateTime], [CreateUser]) VALUES (32, N'soild', N'md', N'primary', N'layui-icon-edit', N'编辑绿色', 0, N'', 0, CAST(N'2023-11-18T16:07:31.467' AS DateTime), N'1')
INSERT [dbo].[Sys_ButtonStyle] ([ButtonStyleId], [BordersStyle], [Size], [Types], [Icon], [ButtonStyleName], [OrderBy], [Borders], [IsRadius], [CreateTime], [CreateUser]) VALUES (33, N'soild', N'md', N'danger', N'layui-icon-delete', N'删除', 0, N'', 0, CAST(N'2023-11-18T16:08:09.300' AS DateTime), N'1')
INSERT [dbo].[Sys_ButtonStyle] ([ButtonStyleId], [BordersStyle], [Size], [Types], [Icon], [ButtonStyleName], [OrderBy], [Borders], [IsRadius], [CreateTime], [CreateUser]) VALUES (34, N'soild', N'md', N'danger', N'layui-icon-delete', N'删除圆角', 0, N'', 1, CAST(N'2023-11-18T16:08:31.150' AS DateTime), N'1')
INSERT [dbo].[Sys_ButtonStyle] ([ButtonStyleId], [BordersStyle], [Size], [Types], [Icon], [ButtonStyleName], [OrderBy], [Borders], [IsRadius], [CreateTime], [CreateUser]) VALUES (35, N'soild', N'sm', N'primary', N'layui-icon-add-one', N'新增中型按钮', 0, N'', 0, CAST(N'2023-11-18T16:09:39.663' AS DateTime), N'1')
INSERT [dbo].[Sys_ButtonStyle] ([ButtonStyleId], [BordersStyle], [Size], [Types], [Icon], [ButtonStyleName], [OrderBy], [Borders], [IsRadius], [CreateTime], [CreateUser]) VALUES (36, N'soild', N'xs', N'normal', N'layui-icon-add-one', N'新增小型按钮', 0, N'', 0, CAST(N'2023-11-18T16:10:05.167' AS DateTime), N'1')
INSERT [dbo].[Sys_ButtonStyle] ([ButtonStyleId], [BordersStyle], [Size], [Types], [Icon], [ButtonStyleName], [OrderBy], [Borders], [IsRadius], [CreateTime], [CreateUser]) VALUES (37, N'soild', N'sm', N'primary', N'layui-icon-edit', N'编辑中型按钮', 0, N'', 0, CAST(N'2023-11-18T16:10:44.750' AS DateTime), N'1')
INSERT [dbo].[Sys_ButtonStyle] ([ButtonStyleId], [BordersStyle], [Size], [Types], [Icon], [ButtonStyleName], [OrderBy], [Borders], [IsRadius], [CreateTime], [CreateUser]) VALUES (38, N'soild', N'xs', N'normal', N'layui-icon-edit', N'编辑小型按钮', 0, N'', 0, CAST(N'2023-11-18T16:11:01.483' AS DateTime), N'1')
INSERT [dbo].[Sys_ButtonStyle] ([ButtonStyleId], [BordersStyle], [Size], [Types], [Icon], [ButtonStyleName], [OrderBy], [Borders], [IsRadius], [CreateTime], [CreateUser]) VALUES (39, N'soild', N'sm', N'danger', N'layui-icon-delete', N'删除中型按钮', 0, N'', 0, CAST(N'2023-11-18T16:11:28.170' AS DateTime), N'1')
INSERT [dbo].[Sys_ButtonStyle] ([ButtonStyleId], [BordersStyle], [Size], [Types], [Icon], [ButtonStyleName], [OrderBy], [Borders], [IsRadius], [CreateTime], [CreateUser]) VALUES (40, N'soild', N'xs', N'danger', N'layui-icon-delete', N'删除小型按钮', 0, N'', 0, CAST(N'2023-11-18T16:11:41.603' AS DateTime), N'1')
INSERT [dbo].[Sys_ButtonStyle] ([ButtonStyleId], [BordersStyle], [Size], [Types], [Icon], [ButtonStyleName], [OrderBy], [Borders], [IsRadius], [CreateTime], [CreateUser]) VALUES (41, N'soild', N'md', N'', N'layui-icon-delete', N'默认删除按钮', 0, N'', 0, CAST(N'2023-11-18T16:13:18.550' AS DateTime), N'1')
INSERT [dbo].[Sys_ButtonStyle] ([ButtonStyleId], [BordersStyle], [Size], [Types], [Icon], [ButtonStyleName], [OrderBy], [Borders], [IsRadius], [CreateTime], [CreateUser]) VALUES (42, N'dashed', N'md', N'danger', N'layui-icon-delete', N'虚线删除', 0, N'', 0, CAST(N'2023-11-18T16:14:11.933' AS DateTime), N'1')
INSERT [dbo].[Sys_ButtonStyle] ([ButtonStyleId], [BordersStyle], [Size], [Types], [Icon], [ButtonStyleName], [OrderBy], [Borders], [IsRadius], [CreateTime], [CreateUser]) VALUES (43, N'dashed', N'md', N'primary', N'layui-icon-edit', N'虚线编辑', 0, N'', 0, CAST(N'2023-11-18T16:14:31.027' AS DateTime), N'1')
INSERT [dbo].[Sys_ButtonStyle] ([ButtonStyleId], [BordersStyle], [Size], [Types], [Icon], [ButtonStyleName], [OrderBy], [Borders], [IsRadius], [CreateTime], [CreateUser]) VALUES (44, N'dashed', N'md', N'primary', N'layui-icon-add-one', N'虚线新增', 0, N'', 0, CAST(N'2023-11-18T16:15:01.743' AS DateTime), N'1')
INSERT [dbo].[Sys_ButtonStyle] ([ButtonStyleId], [BordersStyle], [Size], [Types], [Icon], [ButtonStyleName], [OrderBy], [Borders], [IsRadius], [CreateTime], [CreateUser]) VALUES (45, N'dashed', N'md', N'normal', N'layui-icon-add-one', N'百搭虚线编辑', 0, N'', 0, CAST(N'2023-11-18T16:15:23.383' AS DateTime), N'1')
SET IDENTITY_INSERT [dbo].[Sys_ButtonStyle] OFF
SET IDENTITY_INSERT [dbo].[Sys_ExceptionLog] ON 

INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (1, 1, N'错误位置：ProjectManageWebApi.Controllers.MenuController.GetAllChildren (ProjectManageWebApi)
错误行号：49
错误信息：对象名 ''Sys_Menu1'' 无效。', CAST(N'2023-09-13T17:01:42.753' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (2, 1, N'错误位置：ProjectManageWebApi.Controllers.MenuController.GetAllChildren (ProjectManageWebApi)
错误行号：49
错误信息：对象名 ''Sys_Menu1'' 无效。', CAST(N'2023-09-13T17:04:17.867' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (3, 1, N'错误位置：ProjectManageWebApi.Controllers.MenuController.GetAllChildren (ProjectManageWebApi)
错误行号：49
错误信息：对象名 ''Sys_Menu1'' 无效。', CAST(N'2023-09-13T17:07:32.430' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (4, 1, N'错误位置：ProjectManageWebApi.Controllers.MenuController.GetAllChildren (ProjectManageWebApi)
错误行号：49
错误信息：对象名 ''Sys_Menu1'' 无效。', CAST(N'2023-09-13T17:09:56.373' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (5, 1, N'错误位置：ProjectManageWebApi.Controllers.MenuController.GetAllChildren (ProjectManageWebApi)
错误行号：49
错误信息：对象名 ''Sys_Menu1'' 无效。', CAST(N'2023-09-13T17:19:20.300' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (6, 1, N'错误位置：ProjectManageWebApi.Controllers.MenuController.GetAllChildren (ProjectManageWebApi)
错误行号：49
错误信息：对象名 ''Sys_Menu1'' 无效。', CAST(N'2023-09-13T17:20:40.470' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (7, 1, N'错误位置：ProjectManageWebApi.Controllers.MenuController.GetAllChildren (ProjectManageWebApi)
错误行号：49
错误信息：对象名 ''Sys_Menu1'' 无效。', CAST(N'2023-09-13T17:20:41.003' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (8, 1, N'错误位置：ProjectManageWebApi.Controllers.MenuController.GetAllChildren (ProjectManageWebApi)
错误行号：49
错误信息：对象名 ''Sys_Menu1'' 无效。', CAST(N'2023-09-13T17:20:49.697' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (9, 1, N'错误位置：ProjectManageWebApi.Controllers.MenuController.GetAllChildren (ProjectManageWebApi)
错误行号：49
错误信息：对象名 ''Sys_Menu1'' 无效。', CAST(N'2023-09-13T17:21:36.380' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (10, 1, N'错误位置：ProjectManageWebApi.Controllers.MenuController.GetAllChildren (ProjectManageWebApi)
错误行号：49
错误信息：对象名 ''Sys_Menu1'' 无效。', CAST(N'2023-09-13T17:21:44.010' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (11, 1, N'错误位置：ProjectManageWebApi.Controllers.UserController.Login (ProjectManageWebApi)
错误行号：32
错误信息：Object reference not set to an instance of an object.', CAST(N'2023-09-15T13:33:58.903' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (12, 1, N'错误位置：ProjectManageWebApi.Controllers.UserController.Login (ProjectManageWebApi)
错误行号：50
错误信息：Object reference not set to an instance of an object.', CAST(N'2023-09-15T13:58:06.413' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (13, 1, N'错误位置：ProjectManageWebApi.Controllers.UserController.Login (ProjectManageWebApi)
错误行号：47
错误信息：用户名不能为空！', CAST(N'2023-09-15T14:45:45.850' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (14, 1, N'错误位置：ProjectManageWebApi.Controllers.MenuController.GetMenuByUserId (ProjectManageWebApi)
错误行号：62
错误信息：关键字 ''in'' 附近有语法错误。', CAST(N'2023-09-28T09:36:04.857' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (15, 1, N'错误位置：ProjectManageWebApi.Controllers.MenuController.GetMenuByUserId (ProjectManageWebApi)
错误行号：62
错误信息：关键字 ''in'' 附近有语法错误。', CAST(N'2023-09-28T09:36:07.463' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (16, 1, N'错误位置：ProjectManageWebApi.Controllers.MenuController.GetMenuByUserId (ProjectManageWebApi)
错误行号：62
错误信息：关键字 ''in'' 附近有语法错误。', CAST(N'2023-09-28T10:00:58.863' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (17, 1, N'错误位置：ProjectManageWebApi.Controllers.MenuController.GetMenuByUserId (ProjectManageWebApi)
错误行号：62
错误信息：关键字 ''in'' 附近有语法错误。', CAST(N'2023-09-28T10:01:00.547' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (18, 1, N'错误位置：ProjectManageWebApi.Controllers.SysRoleController.GetMenuByRoleId (ProjectManageWebApi)
错误行号：63
错误信息：Object reference not set to an instance of an object.', CAST(N'2023-09-28T14:23:59.200' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (19, 1, N'错误位置：ProjectManageWebApi.Controllers.SysRoleController.GetMenuByRoleId (ProjectManageWebApi)
错误行号：63
错误信息：Object reference not set to an instance of an object.', CAST(N'2023-09-28T14:25:10.240' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (20, 1, N'错误位置：ProjectManageWebApi.Controllers.SysRoleController.GetMenuByRoleId (ProjectManageWebApi)
错误行号：63
错误信息：Object reference not set to an instance of an object.', CAST(N'2023-09-28T14:26:04.510' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (21, 1, N'错误位置：ProjectManageWebApi.Controllers.SysRoleController.GetMenuByRoleId (ProjectManageWebApi)
错误行号：62
错误信息：Object reference not set to an instance of an object.', CAST(N'2023-10-07T16:02:08.977' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (22, 1, N'错误位置：ProjectManageWebApi.Controllers.SysRoleController.GetMenuByRoleId (ProjectManageWebApi)
错误行号：62
错误信息：Object reference not set to an instance of an object.', CAST(N'2023-10-07T16:21:44.070' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (23, 1, N'错误位置：ProjectManageWebApi.Controllers.SysRoleController.GetMenuByRoleId (ProjectManageWebApi)
错误行号：62
错误信息：Object reference not set to an instance of an object.', CAST(N'2023-10-07T16:21:58.973' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (24, 1, N'错误位置：ProjectManageWebApi.Controllers.UserController.Login (ProjectManageWebApi)
错误行号：101
错误信息：Cookie.Expiration is ignored, use ExpireTimeSpan instead.', CAST(N'2023-10-07T17:54:18.843' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (25, 1, N'错误位置：ProjectManageWebApi.Controllers.UserController.Login (ProjectManageWebApi)
错误行号：124
错误信息：No sign-in authentication handlers are registered. Did you forget to call AddAuthentication().AddCookie("Cookies",...)?', CAST(N'2023-10-08T16:05:02.977' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (26, 1, N'错误位置：ProjectManageWebApi.Controllers.UserController.Login (ProjectManageWebApi)
错误行号：124
错误信息：No sign-in authentication handlers are registered. Did you forget to call AddAuthentication().AddCookie("Cookies",...)?', CAST(N'2023-10-08T16:05:13.747' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (27, 1, N'错误位置：ProjectManageWebApi.Controllers.UserController.Login (ProjectManageWebApi)
错误行号：67
错误信息：登录信息无效', CAST(N'2023-10-08T17:04:10.380' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (28, 1, N'错误位置：ProjectManageWebApi.Controllers.UserController.Login (ProjectManageWebApi)
错误行号：52
错误信息：Object reference not set to an instance of an object.', CAST(N'2023-10-09T16:32:10.457' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (29, 1, N'错误位置：ProjectManageWebApi.Controllers.SysRoleController.GetMenuByRoleId (ProjectManageWebApi)
错误行号：73
错误信息：No authentication handler is registered for the scheme ''Cookies''. The registered schemes are: Bearer. Did you forget to call AddAuthentication().Add[SomeAuthHandler]("Cookies",...)?', CAST(N'2023-10-11T16:41:39.017' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (30, 1, N'错误位置：ProjectManageWebApi.Controllers.SysRoleController.GetMenuByRoleId (ProjectManageWebApi)
错误行号：73
错误信息：No authentication handler is registered for the scheme ''Cookies''. The registered schemes are: Bearer. Did you forget to call AddAuthentication().Add[SomeAuthHandler]("Cookies",...)?', CAST(N'2023-10-11T16:41:48.770' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (31, 1, N'错误位置：ProjectManageWebApi.Controllers.SysRoleController.GetMenuByRoleId (ProjectManageWebApi)
错误行号：73
错误信息：No authentication handler is registered for the scheme ''Cookies''. The registered schemes are: Bearer. Did you forget to call AddAuthentication().Add[SomeAuthHandler]("Cookies",...)?', CAST(N'2023-10-11T16:41:54.377' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (32, 1, N'错误位置：ProjectManageWebApi.Controllers.SysRoleController.GetMenuByRoleId (ProjectManageWebApi)
错误行号：73
错误信息：No authentication handler is registered for the scheme ''Cookies''. The registered schemes are: Bearer. Did you forget to call AddAuthentication().Add[SomeAuthHandler]("Cookies",...)?', CAST(N'2023-10-11T16:42:59.333' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (33, 1, N'错误位置：ProjectManageWebApi.Controllers.SysRoleController.GetMenuByRoleId (ProjectManageWebApi)
错误行号：73
错误信息：No authentication handler is registered for the scheme ''Cookies''. The registered schemes are: Bearer. Did you forget to call AddAuthentication().Add[SomeAuthHandler]("Cookies",...)?', CAST(N'2023-10-11T16:43:06.960' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (34, 1, N'错误位置：ProjectManageWebApi.Controllers.SysRoleController.GetMenuByRoleId (ProjectManageWebApi)
错误行号：73
错误信息：No authentication handler is registered for the scheme ''Cookies''. The registered schemes are: Bearer. Did you forget to call AddAuthentication().Add[SomeAuthHandler]("Cookies",...)?', CAST(N'2023-10-11T16:43:13.053' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (35, 1, N'错误位置：ProjectManageWebApi.Controllers.SysRoleController.GetMenuByRoleId (ProjectManageWebApi)
错误行号：73
错误信息：No authentication handler is registered for the scheme ''Cookies''. The registered schemes are: Bearer. Did you forget to call AddAuthentication().Add[SomeAuthHandler]("Cookies",...)?', CAST(N'2023-10-11T16:43:32.150' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (36, 1, N'错误位置：ProjectManageWebApi.Controllers.MenuController.AddMenuMsg (ProjectManageWebApi)
错误行号：106
错误信息：不能将值 NULL 插入列 ''MenuUrl''，表 ''ProjectManage.dbo.Sys_Menu''；列不允许有 Null 值。INSERT 失败。
语句已终止。', CAST(N'2023-10-12T15:15:17.113' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (37, 1, N'错误位置：ProjectManageWebApi.Controllers.UserController.UpdateUserMsg (ProjectManageWebApi)
错误行号：104
错误信息：不能将值 NULL 插入列 ''Password''，表 ''ProjectManage.dbo.Sys_User''；列不允许有 Null 值。UPDATE 失败。
语句已终止。', CAST(N'2023-10-18T13:49:31.863' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (38, 1, N'错误位置：ProjectManageWebApi.Controllers.UserController.Login (ProjectManageWebApi)
错误行号：51
错误信息：Sequence contains no elements', CAST(N'2023-11-07T13:54:26.910' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (39, 1, N'错误位置：ProjectManageWebApi.Controllers.UserController.Login (ProjectManageWebApi)
错误行号：51
错误信息：Sequence contains no elements', CAST(N'2023-11-07T14:02:15.917' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (40, 1, N'错误位置：ProjectManageWebApi.Controllers.UserController.Login (ProjectManageWebApi)
错误行号：51
错误信息：Sequence contains no elements', CAST(N'2023-11-07T14:03:22.340' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (41, 1, N'错误位置：ProjectManageWebApi.Controllers.UserController.Login (ProjectManageWebApi)
错误行号：51
错误信息：Sequence contains no elements', CAST(N'2023-11-07T14:05:20.483' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (42, 1, N'错误位置：ProjectManageWebApi.Controllers.UserController.Login (ProjectManageWebApi)
错误行号：51
错误信息：Sequence contains no elements', CAST(N'2023-11-07T14:53:29.223' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (43, 1, N'错误位置：ProjectManageWebApi.Controllers.UserController.Login (ProjectManageWebApi)
错误行号：51
错误信息：Sequence contains no elements', CAST(N'2023-11-07T14:54:11.333' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (44, 1, N'错误位置：ProjectManageWebApi.Controllers.UserController.Login (ProjectManageWebApi)
错误行号：51
错误信息：Sequence contains no elements', CAST(N'2023-11-07T14:54:24.937' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (45, 1, N'错误位置：ProjectManageWebApi.Controllers.SysUserController.test (ProjectManageWebApi)
错误行号：64
错误信息：Parameter count mismatch.', CAST(N'2023-11-24T16:07:14.897' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (46, 1, N'错误位置：ProjectManageWebApi.Controllers.SysButtonController.Insert (ProjectManageWebApi)
错误行号：63
错误信息：INSERT 语句与 FOREIGN KEY 约束"FK_Button_ButtonStyle"冲突。该冲突发生于数据库"ProjectManage"，表"dbo.Sys_ButtonStyle", column ''ButtonStyleId''。
语句已终止。', CAST(N'2023-11-29T13:39:47.090' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (47, 1, N'错误位置：ProjectManageWebApi.Controllers.SysButtonController.Insert (ProjectManageWebApi)
错误行号：63
错误信息：INSERT 语句与 FOREIGN KEY 约束"FK_Button_ButtonStyle"冲突。该冲突发生于数据库"ProjectManage"，表"dbo.Sys_ButtonStyle", column ''ButtonStyleId''。
语句已终止。', CAST(N'2023-11-29T13:41:30.097' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (48, 1, N'错误位置：ProjectManageWebApi.Controllers.SysButtonController.Insert (ProjectManageWebApi)
错误行号：63
错误信息：该菜单已存在按钮名称为【0】的按钮', CAST(N'2023-12-16T15:48:13.603' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (49, 1, N'错误位置：ProjectManageWebApi.Controllers.SysButtonController.Insert (ProjectManageWebApi)
错误行号：63
错误信息：该菜单已存在按钮名称为【新增菜单】的按钮,请重新输入', CAST(N'2023-12-16T15:49:15.857' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (50, 1, N'错误位置：ProjectManageWebApi.Controllers.SysButtonController.Insert (ProjectManageWebApi)
错误行号：63
错误信息：该菜单已存在按钮Key为【3433333】的按钮,请重新输入', CAST(N'2023-12-16T15:50:01.320' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (51, 1, N'错误位置：ProjectManageWebApi.Controllers.SysMenuTableColsController.Insert (ProjectManageWebApi)
错误行号：52
错误信息：该菜单已存在字段名称名称为【roleName】的数据,请重新输入', CAST(N'2023-12-16T16:06:50.660' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (52, 1, N'错误位置：ProjectManageWebApi.Controllers.SysMenuTableColsController.Insert (ProjectManageWebApi)
错误行号：52
错误信息：该菜单已存在字段插槽为【】的数据,请重新输入', CAST(N'2023-12-16T16:07:20.630' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (53, 1, N'错误位置：ProjectManageWebApi.Controllers.SysMenuTableRowAuthController.SaveRuleConfig (ProjectManageWebApi)
错误行号：97
错误信息：Requested value ''='' was not found.', CAST(N'2024-01-08T08:44:44.453' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (54, 1, N'错误位置：ProjectManageWebApi.Controllers.SysMenuController.GetMenusList (ProjectManageWebApi)
错误行号：74
错误信息：列名 ''CurrentUser'' 无效。
列名 ''CurrentUser'' 无效。', CAST(N'2024-01-08T13:53:44.050' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (55, 1, N'错误位置：ProjectManageWebApi.Controllers.SysMenuController.GetMenusList (ProjectManageWebApi)
错误行号：74
错误信息：列名 ''RoleId'' 无效。
列名 ''RoleId'' 无效。', CAST(N'2024-01-08T17:58:18.587' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (56, 1, N'错误位置：ProjectManageWebApi.Controllers.SysMenuController.GetMenusList (ProjectManageWebApi)
错误行号：74
错误信息：列名 ''RoleId'' 无效。
列名 ''RoleId'' 无效。
列名 ''RoleId'' 无效。
列名 ''RoleId'' 无效。', CAST(N'2024-01-08T18:00:02.803' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (57, 1, N'错误位置：ProjectManageWebApi.Controllers.SysMenuController.GetMenusList (ProjectManageWebApi)
错误行号：74
错误信息：列名 ''RoleId'' 无效。
列名 ''RoleId'' 无效。', CAST(N'2024-01-09T17:42:26.300' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (58, 1, N'错误位置：ProjectManageWebApi.Controllers.SysMenuController.GetMenusList (ProjectManageWebApi)
错误行号：74
错误信息：列名 ''RoleId'' 无效。
列名 ''RoleId'' 无效。', CAST(N'2024-01-09T17:43:29.623' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (59, 1, N'错误位置：ProjectManageWebApi.Controllers.SysMenuController.GetMenusList (ProjectManageWebApi)
错误行号：74
错误信息：列名 ''RoleId'' 无效。
列名 ''RoleId'' 无效。', CAST(N'2024-01-09T17:43:49.760' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (60, 1, N'错误位置：ProjectManageWebApi.Controllers.SysMenuController.GetMenusList (ProjectManageWebApi)
错误行号：74
错误信息：关键字 ''EXISTS'' 附近有语法错误。
关键字 ''EXISTS'' 附近有语法错误。
“)”附近有语法错误。', CAST(N'2024-01-09T17:55:02.680' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (61, 1, N'错误位置：ProjectManageWebApi.Controllers.SysMenuController.GetMenusList (ProjectManageWebApi)
错误行号：74
错误信息：关键字 ''EXISTS'' 附近有语法错误。
关键字 ''EXISTS'' 附近有语法错误。
“)”附近有语法错误。', CAST(N'2024-01-10T08:16:05.910' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (62, 1, N'错误位置：ProjectManageWebApi.Controllers.SysMenuController.GetMenusList (ProjectManageWebApi)
错误行号：74
错误信息：关键字 ''Contains'' 附近有语法错误。
关键字 ''Contains'' 附近有语法错误。', CAST(N'2024-01-10T08:20:58.270' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (63, 1, N'错误位置：ProjectManageWebApi.Controllers.SysMenuController.GetMenusList (ProjectManageWebApi)
错误行号：74
错误信息：“6”附近有语法错误。
“6”附近有语法错误。', CAST(N'2024-01-10T09:38:54.663' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (64, 1, N'错误位置：ProjectManageWebApi.Controllers.SysMenuController.GetMenusList (ProjectManageWebApi)
错误行号：74
错误信息：列名 ''RoleId'' 无效。
列名 ''RoleId'' 无效。
列名 ''RoleId'' 无效。
列名 ''RoleId'' 无效。', CAST(N'2024-01-10T09:59:01.367' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (65, 1, N'错误位置：ProjectManageWebApi.Controllers.SysMenuController.GetMenusList (ProjectManageWebApi)
错误行号：74
错误信息：列名 ''RoleId'' 无效。
列名 ''RoleId'' 无效。
列名 ''RoleId'' 无效。
列名 ''RoleId'' 无效。', CAST(N'2024-01-10T10:02:13.563' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (66, 1, N'错误位置：ProjectManageWebApi.Controllers.SysMenuController.GetMenusList (ProjectManageWebApi)
错误行号：74
错误信息：“”附近有语法错误。
“”附近有语法错误。', CAST(N'2024-01-10T10:40:35.170' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (67, 1, N'错误位置：ProjectManageWebApi.Controllers.SysMenuController.GetMenusList (ProjectManageWebApi)
错误行号：74
错误信息：“”附近有语法错误。
“”附近有语法错误。', CAST(N'2024-01-10T10:41:56.870' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (68, 1, N'错误位置：ProjectManageWebApi.Controllers.SysMenuController.GetMenusList (ProjectManageWebApi)
错误行号：74
错误信息：“,”附近有语法错误。
“,”附近有语法错误。', CAST(N'2024-01-10T17:14:42.537' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (69, 1, N'错误位置：ProjectManageWebApi.Controllers.SysMenuController.GetMenusList (ProjectManageWebApi)
错误行号：74
错误信息：“,”附近有语法错误。
“,”附近有语法错误。', CAST(N'2024-01-10T17:18:36.483' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (70, 1, N'错误位置：ProjectManageWebApi.Controllers.SysMenuController.GetMenusList (ProjectManageWebApi)
错误行号：74
错误信息：“,”附近有语法错误。
“,”附近有语法错误。', CAST(N'2024-01-11T08:41:13.963' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (71, 1, N'错误位置：ProjectManageWebApi.Controllers.SysMenuController.GetMenusList (ProjectManageWebApi)
错误行号：74
错误信息：“,”附近有语法错误。
“,”附近有语法错误。', CAST(N'2024-01-11T08:43:35.313' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (72, 1, N'错误位置：ProjectManageWebApi.Controllers.SysMenuController.GetMenusList (ProjectManageWebApi)
错误行号：74
错误信息：“,”附近有语法错误。
“,”附近有语法错误。', CAST(N'2024-01-11T08:49:20.410' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (73, 1, N'错误位置：ProjectManageWebApi.Controllers.SysMenuController.GetMenusList (ProjectManageWebApi)
错误行号：74
错误信息：“,”附近有语法错误。
“,”附近有语法错误。', CAST(N'2024-01-11T09:33:51.707' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (74, 1, N'错误位置：ProjectManageWebApi.Controllers.SysMenuController.GetMenusList (ProjectManageWebApi)
错误行号：74
错误信息：在应使用条件的上下文(在 ''And'' 附近)中指定了非布尔类型的表达式。
在应使用条件的上下文(在 ''And'' 附近)中指定了非布尔类型的表达式。', CAST(N'2024-01-11T11:06:49.490' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (75, 1, N'错误位置：ProjectManageWebApi.Controllers.SysMenuController.GetMenusList (ProjectManageWebApi)
错误行号：74
错误信息：在应使用条件的上下文(在 ''And'' 附近)中指定了非布尔类型的表达式。
在应使用条件的上下文(在 ''And'' 附近)中指定了非布尔类型的表达式。', CAST(N'2024-01-11T11:06:56.673' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (76, 1, N'错误位置：ProjectManageWebApi.Controllers.SysMenuController.GetMenusList (ProjectManageWebApi)
错误行号：74
错误信息：在应使用条件的上下文(在 ''And'' 附近)中指定了非布尔类型的表达式。
在应使用条件的上下文(在 ''And'' 附近)中指定了非布尔类型的表达式。', CAST(N'2024-01-11T11:07:34.943' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (77, 1, N'错误位置：ProjectManageWebApi.Controllers.SysMenuController.GetMenusList (ProjectManageWebApi)
错误行号：74
错误信息：菜单id不能为空', CAST(N'2024-01-11T16:05:37.473' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (78, 1, N'错误位置：ProjectManageWebApi.Controllers.SysMenuController.GetMenusList (ProjectManageWebApi)
错误行号：74
错误信息：列名 '''' 无效。
列名 '''' 无效。
列名 '''' 无效。
列名 '''' 无效。
列名 '''' 无效。
列名 '''' 无效。
列名 '''' 无效。
列名 '''' 无效。
列名 '''' 无效。
列名 '''' 无效。
列名 '''' 无效。
列名 '''' 无效。', CAST(N'2024-01-11T16:26:57.863' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (79, 1, N'错误位置：ProjectManageWebApi.Controllers.SysMenuTableRowAuthController.SaveRuleConfig (ProjectManageWebApi)
错误行号：112
错误信息：该菜单已存在字段名称名称为【创建时间】的规则数据,请重新输入!', CAST(N'2024-01-13T09:48:48.757' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (80, 1, N'错误位置：ProjectManageWebApi.Controllers.SysMenuTableRowAuthController.SaveRuleConfig (ProjectManageWebApi)
错误行号：112
错误信息：该菜单已存在字段名称名称为【创建时间】的规则数据,请重新输入!', CAST(N'2024-01-13T09:49:14.587' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (81, 1, N'错误位置：ProjectManageWebApi.Controllers.SysMenuTableRowAuthController.SaveRuleConfig (ProjectManageWebApi)
错误行号：112
错误信息：该菜单已存在字段名称名称为【创建时间】的规则数据,请重新输入!', CAST(N'2024-01-13T09:49:45.353' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (82, 1, N'错误位置：ProjectManageWebApi.Controllers.SysMenuController.GetMenusList (ProjectManageWebApi)
错误行号：74
错误信息：菜单id不能为空', CAST(N'2024-01-13T10:33:38.453' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (83, 1, N'错误位置：ProjectManageWebApi.Controllers.SysMenuController.GetMenusList (ProjectManageWebApi)
错误行号：74
错误信息：The binary operator Equal is not defined for the types ''System.String'' and ''System.Int32''.', CAST(N'2024-01-13T16:09:21.360' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (84, 1, N'错误位置：ProjectManageWebApi.Controllers.SysMenuController.GetMenusList (ProjectManageWebApi)
错误行号：74
错误信息：“1”附近有语法错误。
“1”附近有语法错误。', CAST(N'2024-01-13T16:54:45.810' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (85, 1, N'错误位置：ProjectManageWebApi.Controllers.SysMenuController.GetMenusList (ProjectManageWebApi)
错误行号：74
错误信息：“1”附近有语法错误。
“1”附近有语法错误。', CAST(N'2024-01-13T16:55:27.473' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (86, 1, N'错误位置：ProjectManageWebApi.Controllers.SysMenuController.GetMenusList (ProjectManageWebApi)
错误行号：74
错误信息：列名 ''RoleId'' 无效。
列名 ''RoleId'' 无效。', CAST(N'2024-01-13T17:00:10.753' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (87, 1, N'错误位置：ProjectManageWebApi.Controllers.SysMenuController.GetMenusList (ProjectManageWebApi)
错误行号：74
错误信息：列名 ''RoleId'' 无效。
列名 ''RoleId'' 无效。', CAST(N'2024-01-13T17:09:37.820' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (88, 1, N'错误位置：ProjectManageWebApi.Controllers.SysMenuController.GetMenusList (ProjectManageWebApi)
错误行号：74
错误信息：列名 ''RoleId'' 无效。
列名 ''RoleId'' 无效。', CAST(N'2024-01-13T17:10:05.080' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (89, 1, N'错误位置：ProjectManageWebApi.Controllers.SysRoleController.UpdataRoleAuthorityMsg (ProjectManageWebApi)
错误行号：111
错误信息：列名 ''CreateUser1'' 无效。', CAST(N'2024-01-16T08:24:47.477' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (90, 1, N'错误位置：ProjectManageWebApi.Controllers.SysRoleController.UpdataRoleAuthorityMsg (ProjectManageWebApi)
错误行号：111
错误信息：事务发生错误：列名 ''CreateUser1'' 无效。', CAST(N'2024-01-16T08:25:49.190' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (91, 1, N'错误位置：ProjectManageWebApi.Controllers.SysUserController.Login (ProjectManageWebApi)
错误行号：52
错误信息：Sequence contains no elements', CAST(N'2024-01-16T08:39:39.580' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (92, 1, N'错误位置：ProjectManageWebApi.Controllers.SysButtonController.GetButtonList (ProjectManageWebApi)
错误行号：97
错误信息：菜单id不能为空', CAST(N'2024-01-18T17:23:23.163' AS DateTime), N'admin', N'1', 0, NULL, NULL)
INSERT [dbo].[Sys_ExceptionLog] ([Id], [ExceptionType], [ExceptionMsg], [ExceptionTime], [OperateUserName], [OperateUserId], [IsHandle], [HandleUserName], [HandleUserId]) VALUES (93, 1, N'错误位置：ProjectManageWebApi.Controllers.SysUserController.GetUserList (ProjectManageWebApi)
错误行号：130
错误信息：列名 ''Age'' 无效。
列名 ''Age'' 无效。
列名 ''Age'' 无效。
列名 ''Age'' 无效。', CAST(N'2024-01-21T20:33:13.540' AS DateTime), N'admin', N'1', 0, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Sys_ExceptionLog] OFF
SET IDENTITY_INSERT [dbo].[Sys_Menu] ON 

INSERT [dbo].[Sys_Menu] ([Id], [MenuUrl], [MenuIcon], [MenuTitle], [Pid], [IsOpen], [CreateTime], [CreateUser], [Component], [Path], [RequireAuth], [Name], [Redirect]) VALUES (4, N'/menu', N'layui-icon-templeate-one', N'菜单管理', 0, 1, CAST(N'2023-08-15T00:00:00.000' AS DateTime), N'1', N'BaseLayout', N'/menu', 1, N'', N'')
INSERT [dbo].[Sys_Menu] ([Id], [MenuUrl], [MenuIcon], [MenuTitle], [Pid], [IsOpen], [CreateTime], [CreateUser], [Component], [Path], [RequireAuth], [Name], [Redirect]) VALUES (5, N'/menu', N'layui-icon-slider', N'菜单', 4, 1, CAST(N'2023-12-16T14:35:27.203' AS DateTime), N'1', N'../views/menu/index', N'/menu', 0, NULL, NULL)
INSERT [dbo].[Sys_Menu] ([Id], [MenuUrl], [MenuIcon], [MenuTitle], [Pid], [IsOpen], [CreateTime], [CreateUser], [Component], [Path], [RequireAuth], [Name], [Redirect]) VALUES (34, N'/button', N'layui-icon-app', N'按钮管理', 0, 1, CAST(N'2023-08-15T00:00:00.000' AS DateTime), N'1', N'BaseLayout', N'/button', 1, N'', N'')
INSERT [dbo].[Sys_Menu] ([Id], [MenuUrl], [MenuIcon], [MenuTitle], [Pid], [IsOpen], [CreateTime], [CreateUser], [Component], [Path], [RequireAuth], [Name], [Redirect]) VALUES (35, N'/buttonStyle', N'layui-icon-theme', N'按钮样式', 34, 1, CAST(N'2023-08-15T00:00:00.000' AS DateTime), N'1', N'../views/buttonStyle/styleIndex', N'/buttonStyle', 1, N'buttonStyle', N'')
INSERT [dbo].[Sys_Menu] ([Id], [MenuUrl], [MenuIcon], [MenuTitle], [Pid], [IsOpen], [CreateTime], [CreateUser], [Component], [Path], [RequireAuth], [Name], [Redirect]) VALUES (36, N'/user', N'layui-icon-user', N'用户管理', 0, 1, CAST(N'2023-09-26T14:27:27.983' AS DateTime), N'1', N'BaseLayout', N'/user', 1, N'', N'')
INSERT [dbo].[Sys_Menu] ([Id], [MenuUrl], [MenuIcon], [MenuTitle], [Pid], [IsOpen], [CreateTime], [CreateUser], [Component], [Path], [RequireAuth], [Name], [Redirect]) VALUES (37, N'/user', N'layui-icon-username', N'用户列表', 36, 1, CAST(N'2023-09-26T14:30:12.687' AS DateTime), N'1', N'../views/user/index', N'/user', 1, N'', N'')
INSERT [dbo].[Sys_Menu] ([Id], [MenuUrl], [MenuIcon], [MenuTitle], [Pid], [IsOpen], [CreateTime], [CreateUser], [Component], [Path], [RequireAuth], [Name], [Redirect]) VALUES (38, N'/authority', N'layui-icon-vercode', N'权限管理', 0, 1, CAST(N'2023-09-28T10:57:46.583' AS DateTime), N'1', N'BaseLayout', N'/authority', 1, N'', N'')
INSERT [dbo].[Sys_Menu] ([Id], [MenuUrl], [MenuIcon], [MenuTitle], [Pid], [IsOpen], [CreateTime], [CreateUser], [Component], [Path], [RequireAuth], [Name], [Redirect]) VALUES (39, N'/authority', N'layui-icon-tabs', N'角色列表', 38, 1, CAST(N'2023-09-28T10:58:43.557' AS DateTime), N'1', N'../views/authority/roleIndex', N'/authority', 1, N'', N'')
INSERT [dbo].[Sys_Menu] ([Id], [MenuUrl], [MenuIcon], [MenuTitle], [Pid], [IsOpen], [CreateTime], [CreateUser], [Component], [Path], [RequireAuth], [Name], [Redirect]) VALUES (40, N'/authority/menu', N'layui-icon-home', N'菜单权限', 38, 1, CAST(N'2024-01-03T08:14:42.347' AS DateTime), N'1', N'../views/authority/menu/index', N'/authority/menu', 0, NULL, NULL)
INSERT [dbo].[Sys_Menu] ([Id], [MenuUrl], [MenuIcon], [MenuTitle], [Pid], [IsOpen], [CreateTime], [CreateUser], [Component], [Path], [RequireAuth], [Name], [Redirect]) VALUES (48, N'/button', N'layui-icon-cols', N'按钮列表', 34, 1, CAST(N'2023-12-16T14:25:29.040' AS DateTime), N'1', N'../views/button/index', N'/button', 0, NULL, NULL)
INSERT [dbo].[Sys_Menu] ([Id], [MenuUrl], [MenuIcon], [MenuTitle], [Pid], [IsOpen], [CreateTime], [CreateUser], [Component], [Path], [RequireAuth], [Name], [Redirect]) VALUES (52, N'/authority/button', N'layui-icon-home', N'按钮权限', 38, 1, CAST(N'2023-12-16T16:27:07.570' AS DateTime), N'1', N'../views/authority/button/index', N'/authority/button', 0, NULL, NULL)
INSERT [dbo].[Sys_Menu] ([Id], [MenuUrl], [MenuIcon], [MenuTitle], [Pid], [IsOpen], [CreateTime], [CreateUser], [Component], [Path], [RequireAuth], [Name], [Redirect]) VALUES (71, N'/authority/tableCols', N'layui-icon-cols', N'显示列设置', 38, 1, CAST(N'2024-01-21T00:45:39.810' AS DateTime), N'2', N'../views/authority/tableCols/index', N'/authority/tableCols', 0, NULL, NULL)
INSERT [dbo].[Sys_Menu] ([Id], [MenuUrl], [MenuIcon], [MenuTitle], [Pid], [IsOpen], [CreateTime], [CreateUser], [Component], [Path], [RequireAuth], [Name], [Redirect]) VALUES (72, N'/authority/tableRow', N'layui-icon-slider', N'数据行权限', 38, 1, CAST(N'2023-12-25T08:20:03.960' AS DateTime), N'3', N'../views/authority/tableRow/index', N'/authority/tableRow', 0, NULL, NULL)
INSERT [dbo].[Sys_Menu] ([Id], [MenuUrl], [MenuIcon], [MenuTitle], [Pid], [IsOpen], [CreateTime], [CreateUser], [Component], [Path], [RequireAuth], [Name], [Redirect]) VALUES (74, N'/authority/cols', N'layui-icon-home', N'数据列权限', 38, 1, CAST(N'2023-12-16T16:27:07.570' AS DateTime), N'1', N'../views/authority/cols/index', N'/authority/cols', 0, N'', N'')
SET IDENTITY_INSERT [dbo].[Sys_Menu] OFF
SET IDENTITY_INSERT [dbo].[Sys_MenuRoleRelation] ON 

INSERT [dbo].[Sys_MenuRoleRelation] ([MenuRoleId], [MenuId], [RoleId], [CreateTime], [CreateUser]) VALUES (258, 4, 2, CAST(N'2024-01-22T17:04:23.990' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuRoleRelation] ([MenuRoleId], [MenuId], [RoleId], [CreateTime], [CreateUser]) VALUES (259, 5, 2, CAST(N'2024-01-22T17:04:23.990' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuRoleRelation] ([MenuRoleId], [MenuId], [RoleId], [CreateTime], [CreateUser]) VALUES (260, 34, 2, CAST(N'2024-01-22T17:04:23.990' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuRoleRelation] ([MenuRoleId], [MenuId], [RoleId], [CreateTime], [CreateUser]) VALUES (261, 35, 2, CAST(N'2024-01-22T17:04:23.990' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuRoleRelation] ([MenuRoleId], [MenuId], [RoleId], [CreateTime], [CreateUser]) VALUES (262, 48, 2, CAST(N'2024-01-22T17:04:23.990' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuRoleRelation] ([MenuRoleId], [MenuId], [RoleId], [CreateTime], [CreateUser]) VALUES (263, 36, 2, CAST(N'2024-01-22T17:04:23.990' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuRoleRelation] ([MenuRoleId], [MenuId], [RoleId], [CreateTime], [CreateUser]) VALUES (264, 37, 2, CAST(N'2024-01-22T17:04:23.990' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuRoleRelation] ([MenuRoleId], [MenuId], [RoleId], [CreateTime], [CreateUser]) VALUES (265, 38, 2, CAST(N'2024-01-22T17:04:23.990' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuRoleRelation] ([MenuRoleId], [MenuId], [RoleId], [CreateTime], [CreateUser]) VALUES (266, 39, 2, CAST(N'2024-01-22T17:04:23.990' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuRoleRelation] ([MenuRoleId], [MenuId], [RoleId], [CreateTime], [CreateUser]) VALUES (267, 40, 2, CAST(N'2024-01-22T17:04:23.990' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuRoleRelation] ([MenuRoleId], [MenuId], [RoleId], [CreateTime], [CreateUser]) VALUES (268, 52, 2, CAST(N'2024-01-22T17:04:23.990' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuRoleRelation] ([MenuRoleId], [MenuId], [RoleId], [CreateTime], [CreateUser]) VALUES (269, 71, 2, CAST(N'2024-01-22T17:04:23.990' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuRoleRelation] ([MenuRoleId], [MenuId], [RoleId], [CreateTime], [CreateUser]) VALUES (270, 72, 2, CAST(N'2024-01-22T17:04:23.990' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuRoleRelation] ([MenuRoleId], [MenuId], [RoleId], [CreateTime], [CreateUser]) VALUES (271, 74, 2, CAST(N'2024-01-22T17:04:23.990' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuRoleRelation] ([MenuRoleId], [MenuId], [RoleId], [CreateTime], [CreateUser]) VALUES (272, 4, 1, CAST(N'2024-01-22T17:04:48.900' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuRoleRelation] ([MenuRoleId], [MenuId], [RoleId], [CreateTime], [CreateUser]) VALUES (273, 5, 1, CAST(N'2024-01-22T17:04:48.900' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuRoleRelation] ([MenuRoleId], [MenuId], [RoleId], [CreateTime], [CreateUser]) VALUES (274, 73, 1, CAST(N'2024-01-22T17:04:48.900' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuRoleRelation] ([MenuRoleId], [MenuId], [RoleId], [CreateTime], [CreateUser]) VALUES (275, 34, 1, CAST(N'2024-01-22T17:04:48.900' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuRoleRelation] ([MenuRoleId], [MenuId], [RoleId], [CreateTime], [CreateUser]) VALUES (276, 35, 1, CAST(N'2024-01-22T17:04:48.900' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuRoleRelation] ([MenuRoleId], [MenuId], [RoleId], [CreateTime], [CreateUser]) VALUES (277, 48, 1, CAST(N'2024-01-22T17:04:48.900' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuRoleRelation] ([MenuRoleId], [MenuId], [RoleId], [CreateTime], [CreateUser]) VALUES (278, 36, 1, CAST(N'2024-01-22T17:04:48.900' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuRoleRelation] ([MenuRoleId], [MenuId], [RoleId], [CreateTime], [CreateUser]) VALUES (279, 37, 1, CAST(N'2024-01-22T17:04:48.900' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuRoleRelation] ([MenuRoleId], [MenuId], [RoleId], [CreateTime], [CreateUser]) VALUES (280, 38, 1, CAST(N'2024-01-22T17:04:48.900' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuRoleRelation] ([MenuRoleId], [MenuId], [RoleId], [CreateTime], [CreateUser]) VALUES (281, 39, 1, CAST(N'2024-01-22T17:04:48.900' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuRoleRelation] ([MenuRoleId], [MenuId], [RoleId], [CreateTime], [CreateUser]) VALUES (282, 40, 1, CAST(N'2024-01-22T17:04:48.900' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuRoleRelation] ([MenuRoleId], [MenuId], [RoleId], [CreateTime], [CreateUser]) VALUES (283, 52, 1, CAST(N'2024-01-22T17:04:48.900' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuRoleRelation] ([MenuRoleId], [MenuId], [RoleId], [CreateTime], [CreateUser]) VALUES (284, 71, 1, CAST(N'2024-01-22T17:04:48.900' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuRoleRelation] ([MenuRoleId], [MenuId], [RoleId], [CreateTime], [CreateUser]) VALUES (285, 72, 1, CAST(N'2024-01-22T17:04:48.900' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuRoleRelation] ([MenuRoleId], [MenuId], [RoleId], [CreateTime], [CreateUser]) VALUES (286, 74, 1, CAST(N'2024-01-22T17:04:48.900' AS DateTime), N'1')
SET IDENTITY_INSERT [dbo].[Sys_MenuRoleRelation] OFF
SET IDENTITY_INSERT [dbo].[Sys_MenuTableCols] ON 

INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (171, 5, N'id', N'Int32', N'id', 0, 50, NULL, NULL, NULL, NULL, 0, 0, CAST(N'2024-01-12T08:43:13.957' AS DateTime), N'1', 1, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (172, 5, N'menuUrl', N'String', N'菜单路径', 3, 100, NULL, NULL, NULL, NULL, 0, 0, CAST(N'2023-12-16T14:37:26.450' AS DateTime), N'1', 1, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (173, 5, N'menuIcon', N'String', N'菜单图标', 2, NULL, NULL, NULL, NULL, NULL, NULL, 0, CAST(N'2023-12-01T17:02:33.420' AS DateTime), N'1', 1, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (174, 5, N'menuTitle', N'String', N'菜单标题', 1, 200, NULL, N'menuTitleSlot', NULL, NULL, 0, 0, CAST(N'2024-01-19T17:37:23.667' AS DateTime), N'1', 1, 1, N'MenuTitle', N'菜单标题')
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (175, 5, N'pid', N'Int32', N'父级菜单id', 4, NULL, NULL, NULL, NULL, NULL, NULL, 0, CAST(N'2023-12-01T17:02:33.420' AS DateTime), N'1', 1, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (176, 5, N'isOpen', N'Boolean', N'是否启用', 5, 80, NULL, NULL, NULL, NULL, 0, 0, CAST(N'2024-01-12T08:42:55.443' AS DateTime), N'1', 1, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (177, 5, N'createTime', N'DateTime', N'创建时间', 6, NULL, NULL, NULL, NULL, NULL, NULL, 0, CAST(N'2023-12-01T17:02:33.420' AS DateTime), N'1', 1, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (178, 5, N'createUser', N'String', N'创建人id', 7, NULL, NULL, NULL, NULL, NULL, NULL, 0, CAST(N'2023-12-01T17:02:33.420' AS DateTime), N'1', 1, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (179, 5, N'component', N'String', N'菜单地址', 8, NULL, NULL, NULL, NULL, NULL, NULL, 0, CAST(N'2023-12-01T17:02:33.420' AS DateTime), N'1', 1, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (180, 5, N'path', N'String', N'菜单路径', 9, NULL, NULL, NULL, NULL, NULL, NULL, 0, CAST(N'2023-12-01T17:02:33.420' AS DateTime), N'1', 1, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (181, 5, N'requireAuth', N'Boolean', N'是否验证', 10, NULL, NULL, NULL, NULL, NULL, NULL, 0, CAST(N'2023-12-01T17:02:33.420' AS DateTime), N'1', 1, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (182, 5, N'name', N'String', N'名称', 11, NULL, NULL, NULL, NULL, NULL, NULL, 0, CAST(N'2023-12-01T17:02:33.420' AS DateTime), N'1', 1, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (183, 5, N'redirect', N'String', N'重定向', 12, NULL, NULL, NULL, NULL, NULL, NULL, 0, CAST(N'2023-12-01T17:02:33.420' AS DateTime), N'1', 1, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (184, 48, N'buttonId', N'Int32', N'按钮id', 0, 100, N'desc', NULL, N'left', NULL, NULL, 0, CAST(N'2023-12-01T17:02:33.657' AS DateTime), N'1', 1, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (185, 48, N'buttonStyleId', N'Int32', N'按钮样式id', 1, 200, NULL, NULL, N'left', NULL, NULL, 0, CAST(N'2023-12-01T17:02:33.657' AS DateTime), N'1', 1, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (186, 48, N'menuId', N'Int32', N'菜单id', 2, 80, NULL, NULL, N'left', NULL, NULL, 0, CAST(N'2023-12-01T17:02:33.657' AS DateTime), N'1', 1, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (187, 48, N'buttonName', N'String', N'按钮名称', 3, 150, NULL, NULL, N'left', NULL, NULL, 0, CAST(N'2023-12-01T17:02:33.657' AS DateTime), N'1', 1, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (188, 48, N'buttonKey', N'String', N'按钮事件key', 4, 100, NULL, NULL, N'left', NULL, NULL, 0, CAST(N'2023-12-01T17:02:33.657' AS DateTime), N'1', 1, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (189, 48, N'bordersStyle', N'String', N'按钮样式', 19, 200, NULL, N'buttonStyle', N'left', NULL, 0, 0, CAST(N'2024-01-20T19:20:07.307' AS DateTime), N'1', 1, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (190, 48, N'size', N'String', N'按钮大小', 6, 80, NULL, NULL, N'left', NULL, NULL, 0, CAST(N'2023-12-01T17:02:33.657' AS DateTime), N'1', 1, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (191, 48, N'types', N'String', N'边框样式', 7, 150, NULL, NULL, N'left', NULL, 0, 0, CAST(N'2023-12-16T14:46:25.643' AS DateTime), N'1', 1, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (192, 48, N'icon', N'String', N'按钮图标', 8, 80, NULL, NULL, N'left', NULL, NULL, 0, CAST(N'2023-12-01T17:02:33.657' AS DateTime), N'1', 1, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (193, 48, N'buttonStyleName', N'String', N'样式名称', 9, 150, NULL, NULL, N'left', NULL, NULL, 0, CAST(N'2023-12-01T17:02:33.657' AS DateTime), N'1', 1, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (194, 48, N'borders', N'String', N'边框颜色', 10, 150, NULL, NULL, N'left', NULL, NULL, 0, CAST(N'2023-12-01T17:02:33.657' AS DateTime), N'1', 1, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (195, 48, N'isRadius', N'Boolean', N'是否圆角', 11, 150, NULL, NULL, N'left', NULL, NULL, 0, CAST(N'2023-12-01T17:02:33.657' AS DateTime), N'1', 1, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (196, 48, N'menuTitle', N'String', N'所属菜单', 4, 150, NULL, NULL, N'left', NULL, 0, 0, CAST(N'2024-01-20T19:20:45.493' AS DateTime), N'1', 1, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (197, 48, N'orderBy', N'Int32', N'排序', 13, 150, NULL, NULL, N'left', NULL, NULL, 0, CAST(N'2023-12-01T17:02:33.657' AS DateTime), N'1', 1, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (198, 48, N'id', N'String', N'主键', 0, 50, NULL, NULL, N'left', NULL, 0, 0, CAST(N'2024-01-20T19:19:26.837' AS DateTime), N'1', 1, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (199, 35, N'buttonStyleId', N'Int32', N'按钮样式id', 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, CAST(N'2023-12-01T17:02:33.660' AS DateTime), N'1', 1, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (200, 35, N'bordersStyle', N'String', N'边框样式', 1, 80, NULL, NULL, NULL, NULL, 0, 0, CAST(N'2023-12-16T14:42:42.930' AS DateTime), N'1', 1, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (201, 35, N'size', N'String', N'按钮大小', 2, 80, NULL, NULL, NULL, NULL, 0, 0, CAST(N'2023-12-16T14:40:49.170' AS DateTime), N'1', 1, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (202, 35, N'types', N'String', N'按钮样式', 3, 80, NULL, NULL, NULL, NULL, 0, 0, CAST(N'2023-12-16T14:41:20.507' AS DateTime), N'1', 1, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (203, 35, N'icon', N'String', N'按钮图标', 4, 100, NULL, NULL, NULL, NULL, 0, 0, CAST(N'2023-12-16T14:40:37.277' AS DateTime), N'1', 1, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (204, 35, N'buttonStyleName', N'String', N'样式名称', 5, 100, NULL, NULL, NULL, NULL, 0, 0, CAST(N'2023-12-16T14:41:57.447' AS DateTime), N'1', 1, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (205, 35, N'borders', N'String', N'边框颜色', 6, 80, NULL, NULL, NULL, NULL, 0, 0, CAST(N'2023-12-16T14:41:32.077' AS DateTime), N'1', 1, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (206, 35, N'isRadius', N'Boolean', N'是否圆角', 7, 80, NULL, NULL, NULL, NULL, 0, 0, CAST(N'2023-12-16T14:40:27.460' AS DateTime), N'1', 1, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (207, 35, N'orderBy', N'Int32', N'排序', 8, NULL, NULL, NULL, NULL, NULL, NULL, 0, CAST(N'2023-12-01T17:02:33.660' AS DateTime), N'1', 1, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (208, 35, N'createTime', N'DateTime', N'创建时间', 9, 120, NULL, NULL, NULL, NULL, 0, 0, CAST(N'2024-01-23T08:41:56.267' AS DateTime), N'2', 1, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (209, 35, N'createUser', N'String', N'创建人员id', 10, NULL, NULL, NULL, NULL, NULL, NULL, 0, CAST(N'2023-12-01T17:02:33.660' AS DateTime), N'1', 1, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (210, 35, N'id', N'String', N'主键', 0, 50, NULL, NULL, NULL, NULL, 0, 0, CAST(N'2024-01-20T19:18:13.167' AS DateTime), N'1', 1, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (211, 71, N'id', N'String', N'主键', 0, 50, NULL, NULL, NULL, NULL, 0, 0, CAST(N'2023-12-16T14:50:47.350' AS DateTime), N'1', 1, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (212, 71, N'menuId', N'Int32', N'菜单id', 1, NULL, NULL, NULL, NULL, NULL, NULL, 0, CAST(N'2023-12-01T17:02:33.667' AS DateTime), N'1', 1, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (213, 71, N'menuTitle', N'String', N'所属菜单', 2, 200, NULL, NULL, NULL, NULL, 0, 0, CAST(N'2023-12-16T14:51:46.067' AS DateTime), N'1', 1, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (214, 71, N'fieldName', N'String', N'字段名称', 3, 100, NULL, NULL, NULL, NULL, 0, 0, CAST(N'2023-12-16T14:51:00.587' AS DateTime), N'1', 1, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (215, 71, N'fieldType', N'String', N'字段类型', 4, NULL, NULL, NULL, NULL, NULL, NULL, 0, CAST(N'2023-12-01T17:02:33.667' AS DateTime), N'1', 1, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (216, 71, N'fieldTitle', N'String', N'字段标题', 5, NULL, NULL, NULL, NULL, NULL, NULL, 0, CAST(N'2023-12-01T17:02:33.667' AS DateTime), N'1', 1, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (217, 71, N'fieldOrderBy', N'Int32', N'字段排序', 6, NULL, NULL, NULL, NULL, NULL, NULL, 0, CAST(N'2023-12-01T17:02:33.667' AS DateTime), N'1', 1, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (218, 71, N'fieldWidth', N'String', N'字段宽度', 7, NULL, NULL, NULL, NULL, NULL, NULL, 0, CAST(N'2023-12-01T17:02:33.667' AS DateTime), N'1', 1, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (219, 71, N'fieldSort', N'String', N'排序方式', 8, NULL, NULL, NULL, NULL, NULL, NULL, 0, CAST(N'2023-12-01T17:02:33.667' AS DateTime), N'1', 1, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (220, 71, N'fieldCustomSlot', N'String', N'自定义插槽', 9, NULL, NULL, NULL, NULL, NULL, NULL, 0, CAST(N'2023-12-01T17:02:33.667' AS DateTime), N'1', 1, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (221, 71, N'fieldAlign', N'String', N'对齐方式', 10, NULL, NULL, NULL, NULL, NULL, NULL, 0, CAST(N'2023-12-01T17:02:33.667' AS DateTime), N'1', 1, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (222, 71, N'fieldFixed', N'String', N'固定方式', 11, NULL, NULL, NULL, NULL, NULL, NULL, 0, CAST(N'2023-12-01T17:02:33.667' AS DateTime), N'1', 1, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (223, 71, N'fieldMinWidth', N'String', N'最小宽度', 12, NULL, NULL, NULL, NULL, NULL, NULL, 0, CAST(N'2023-12-01T17:02:33.667' AS DateTime), N'1', 1, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (224, 71, N'fieldEllipsisTooltip', N'Boolean', N'是否隐藏提示', 13, NULL, NULL, NULL, NULL, NULL, NULL, 0, CAST(N'2023-12-01T17:02:33.667' AS DateTime), N'1', 1, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (225, 71, N'createTime', N'DateTime', N'创建时间', 14, NULL, NULL, NULL, NULL, NULL, NULL, 0, CAST(N'2023-12-01T17:02:33.667' AS DateTime), N'1', 1, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (226, 71, N'createUser', N'String', N'创建人员id', 15, NULL, NULL, NULL, NULL, NULL, NULL, 0, CAST(N'2023-12-01T17:02:33.667' AS DateTime), N'1', 1, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (227, 39, N'roleId', N'Int32', N'角色id', 0, 100, N'desc', N'', N'left', N'left', 100, 1, CAST(N'2023-12-06T08:58:06.877' AS DateTime), N'1', 1, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (228, 39, N'roleName', N'String', N'角色名称', 1, NULL, NULL, NULL, NULL, NULL, NULL, 0, CAST(N'2023-12-01T17:02:33.673' AS DateTime), N'1', 1, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (229, 39, N'createTime', N'DateTime', N'创建时间', 2, NULL, NULL, NULL, NULL, NULL, NULL, 0, CAST(N'2023-12-01T17:02:33.673' AS DateTime), N'1', 1, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (230, 39, N'createUser', N'String', N'创建人员id', 3, NULL, NULL, NULL, NULL, NULL, NULL, 0, CAST(N'2023-12-01T17:02:33.673' AS DateTime), N'1', 1, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (232, 5, N'operator', N'string', N'操作', 13, 150, NULL, N'operator', NULL, NULL, NULL, 0, CAST(N'2023-12-01T17:02:33.420' AS DateTime), N'1', 2, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (233, 0, N'33', N'333', N'3', 0, 0, N'', N'', N'', N'', 0, 0, CAST(N'2023-12-07T08:20:14.693' AS DateTime), N'1', 1, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (234, 48, N'operator', N'string', N'操作', 20, 1, N'', N'operator', N'', NULL, 0, 0, CAST(N'2024-01-20T19:19:18.567' AS DateTime), N'1', 1, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (235, 35, N'buttonStyle', N'string', N'按钮预览', 13, 200, N'', N'buttonStyle', N'', N'', 0, 0, CAST(N'2024-01-20T19:17:45.150' AS DateTime), N'1', 2, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (236, 35, N'operator', N'string', N'操作', 14, 100, N'', N'operator', N'', N'', 0, 0, CAST(N'2024-01-20T19:18:01.457' AS DateTime), N'1', 2, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (237, 37, N'operator', N'string', N'操作', 10, 80, N'', N'operator', N'', N'', 0, 0, CAST(N'2024-01-20T19:21:20.157' AS DateTime), N'1', 2, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (238, 71, N'isSystemData', N'Int32', N'是否系统数据', 16, 0, NULL, NULL, NULL, NULL, 0, 0, CAST(N'2023-12-07T16:41:28.050' AS DateTime), N'1', 1, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (239, 37, N'userId', N'Int32', N'用户id', 0, 80, NULL, NULL, NULL, NULL, 0, 0, CAST(N'2023-12-16T14:58:25.513' AS DateTime), N'1', 1, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (240, 37, N'userName', N'String', N'用户名', 1, 100, NULL, NULL, NULL, NULL, 0, 0, CAST(N'2024-01-21T01:29:07.007' AS DateTime), N'1', 1, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (241, 37, N'password', N'String', N'密码', 2, 100, NULL, NULL, NULL, NULL, 0, 0, CAST(N'2023-12-16T14:58:57.020' AS DateTime), N'1', 1, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (242, 37, N'age', N'Int32', N'年龄', 3, 50, NULL, NULL, NULL, NULL, 0, 0, CAST(N'2024-01-21T20:29:58.300' AS DateTime), N'1', 1, 1, N'Age', N'年龄')
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (243, 37, N'sex', N'String', N'性别', 4, 50, NULL, NULL, NULL, NULL, 0, 0, CAST(N'2023-12-16T14:59:08.490' AS DateTime), N'1', 1, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (244, 37, N'departmentId', N'Int32', N'部门id', 5, 0, NULL, NULL, NULL, NULL, 0, 0, CAST(N'2023-12-07T16:44:37.437' AS DateTime), N'1', 1, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (245, 37, N'roleId', N'String', N'角色id', 6, 50, NULL, NULL, NULL, NULL, 0, 0, CAST(N'2023-12-16T14:59:14.627' AS DateTime), N'1', 1, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (246, 37, N'roleName', N'String', N'角色名称', 4, 150, NULL, NULL, NULL, NULL, 150, 0, CAST(N'2024-01-20T19:21:37.963' AS DateTime), N'1', 1, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (247, 37, N'createTime', N'DateTime', N'创建时间', 8, 120, NULL, NULL, NULL, NULL, 0, 0, CAST(N'2024-07-13T10:16:41.443' AS DateTime), N'2', 1, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (248, 37, N'createUser', N'String', N'创建人员id', 9, 0, NULL, NULL, NULL, NULL, 0, 0, CAST(N'2023-12-07T16:44:37.437' AS DateTime), N'1', 1, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (249, 39, N'operator', N'string', N'操作', 4, 200, N'', N'operator', N'', N'', 0, 0, CAST(N'2024-01-20T19:22:24.210' AS DateTime), N'1', 2, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (250, 71, N'operator', N'string', N'操作', 20, 150, N'', N'operator', N'', N'', 0, 0, CAST(N'2024-01-20T19:23:17.733' AS DateTime), N'1', 2, 2, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (251, 5, N'children', N'List`1', N'子集', 13, 0, NULL, NULL, NULL, NULL, 0, 0, CAST(N'2024-01-20T19:04:13.187' AS DateTime), N'1', 1, 0, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (252, 71, N'dataRowAuthType', N'Int32', N'数据权限类型', 17, 0, NULL, NULL, NULL, NULL, 0, 0, CAST(N'2024-01-20T19:04:14.633' AS DateTime), N'1', 1, 0, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (253, 71, N'dataRowAuthField', N'String', N'数据行权限字段', 18, 0, NULL, NULL, NULL, NULL, 0, 0, CAST(N'2024-01-20T19:04:14.633' AS DateTime), N'1', 1, 0, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (254, 71, N'dataRowAuthFieldName', N'String', N'数据行权限字段名称', 19, 0, NULL, NULL, NULL, NULL, 0, 0, CAST(N'2024-01-20T19:04:14.633' AS DateTime), N'1', 1, 0, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (255, 72, N'id', N'Int32', N'主键', 0, 0, NULL, NULL, NULL, NULL, 0, 0, CAST(N'2024-01-20T19:04:14.660' AS DateTime), N'1', 1, 0, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (256, 72, N'menuId', N'Int32', N'菜单id', 1, 0, NULL, NULL, NULL, NULL, 0, 0, CAST(N'2024-01-20T19:04:14.660' AS DateTime), N'1', 1, 0, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (257, 72, N'ruleJson', N'String', N'规则json', 2, 0, NULL, NULL, NULL, NULL, 0, 0, CAST(N'2024-01-20T19:04:14.660' AS DateTime), N'1', 1, 0, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (258, 72, N'isOpen', N'Boolean', N'是否使用', 3, 0, NULL, NULL, NULL, NULL, 0, 0, CAST(N'2024-01-20T19:04:14.660' AS DateTime), N'1', 1, 0, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (259, 72, N'remark', N'String', N'备注', 4, 0, NULL, NULL, NULL, NULL, 0, 0, CAST(N'2024-01-20T19:04:14.660' AS DateTime), N'1', 1, 0, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (260, 72, N'sort', N'Int32', N'排序', 5, 0, NULL, NULL, NULL, NULL, 0, 0, CAST(N'2024-01-20T19:04:14.660' AS DateTime), N'1', 1, 0, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (261, 72, N'createTime', N'DateTime', N'创建时间', 6, 0, NULL, NULL, NULL, NULL, 0, 0, CAST(N'2024-01-20T19:04:14.660' AS DateTime), N'1', 1, 0, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (262, 72, N'createUser', N'String', N'创建人员', 7, 0, NULL, NULL, NULL, NULL, 0, 0, CAST(N'2024-01-20T19:04:14.660' AS DateTime), N'1', 1, 0, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (263, 37, N'id', N'String', N'主键', 0, 0, NULL, NULL, NULL, NULL, 0, 0, CAST(N'2024-01-20T19:21:10.207' AS DateTime), N'1', 1, 0, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (264, 48, N'createUser', N'String', N'创建人员id', 13, 0, NULL, NULL, NULL, NULL, 0, 0, CAST(N'2024-01-21T01:41:54.967' AS DateTime), N'1', 1, 0, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (265, 39, N'id', N'String', N'主键', 0, 0, NULL, NULL, NULL, NULL, 0, 0, CAST(N'2024-01-21T01:41:55.093' AS DateTime), N'1', 1, 0, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (266, 35, N'3333', N'333', N'33333', 0, 2, N'', N'', N'', N'', 0, 0, CAST(N'2024-01-21T01:55:13.407' AS DateTime), N'2', 2, 2, N'', N'')
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (267, 5, N'userName', N'String', N'创建人姓名', 8, 100, NULL, NULL, NULL, NULL, 0, 0, CAST(N'2024-01-21T19:21:07.480' AS DateTime), N'1', 1, 0, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (268, 48, N'userName', N'String', N'创建人姓名', 14, 80, NULL, NULL, NULL, NULL, 0, 0, CAST(N'2024-01-23T08:48:39.147' AS DateTime), N'2', 1, 0, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (269, 35, N'userName', N'String', N'创建人姓名', 11, 80, NULL, NULL, NULL, NULL, 0, 0, CAST(N'2024-01-23T08:42:40.777' AS DateTime), N'2', 1, 0, NULL, NULL)
INSERT [dbo].[Sys_MenuTableCols] ([Id], [MenuId], [FieldName], [FieldType], [FieldTitle], [FieldOrderBy], [FieldWidth], [FieldSort], [FieldCustomSlot], [FieldAlign], [FieldFixed], [FieldMinWidth], [FieldEllipsisTooltip], [CreateTime], [CreateUser], [IsSystemData], [DataRowAuthType], [DataRowAuthField], [DataRowAuthFieldName]) VALUES (270, 48, N'createTime', N'DateTime', N'创建时间', 13, 100, NULL, NULL, NULL, NULL, 0, 0, CAST(N'2024-01-23T08:52:55.930' AS DateTime), N'2', 1, 0, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Sys_MenuTableCols] OFF
SET IDENTITY_INSERT [dbo].[Sys_MenuTableColsRole] ON 

INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (128, 35, 200, 1, CAST(N'2024-01-21T00:38:03.330' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (129, 35, 201, 1, CAST(N'2024-01-21T00:38:03.330' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (130, 35, 202, 1, CAST(N'2024-01-21T00:38:03.330' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (131, 35, 203, 1, CAST(N'2024-01-21T00:38:03.330' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (132, 35, 204, 1, CAST(N'2024-01-21T00:38:03.330' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (133, 35, 205, 1, CAST(N'2024-01-21T00:38:03.330' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (134, 35, 206, 1, CAST(N'2024-01-21T00:38:03.330' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (135, 35, 210, 1, CAST(N'2024-01-21T00:38:03.330' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (136, 35, 235, 1, CAST(N'2024-01-21T00:38:03.330' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (137, 35, 236, 1, CAST(N'2024-01-21T00:38:03.330' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (148, 48, 184, 1, CAST(N'2024-01-21T00:38:42.360' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (149, 48, 187, 1, CAST(N'2024-01-21T00:38:42.360' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (150, 48, 189, 1, CAST(N'2024-01-21T00:38:42.360' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (151, 48, 193, 1, CAST(N'2024-01-21T00:38:42.360' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (152, 48, 196, 1, CAST(N'2024-01-21T00:38:42.360' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (153, 48, 198, 1, CAST(N'2024-01-21T00:38:42.360' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (154, 48, 234, 1, CAST(N'2024-01-21T00:38:42.360' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (161, 37, 237, 1, CAST(N'2024-01-21T00:39:38.490' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (162, 37, 239, 1, CAST(N'2024-01-21T00:39:38.490' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (163, 37, 240, 1, CAST(N'2024-01-21T00:39:38.490' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (164, 37, 242, 1, CAST(N'2024-01-21T00:39:38.490' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (165, 37, 241, 1, CAST(N'2024-01-21T00:39:38.490' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (166, 37, 243, 1, CAST(N'2024-01-21T00:39:38.490' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (167, 37, 245, 1, CAST(N'2024-01-21T00:39:38.490' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (168, 37, 246, 1, CAST(N'2024-01-21T00:39:38.490' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (177, 39, 227, 1, CAST(N'2024-01-21T00:40:27.637' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (178, 39, 228, 1, CAST(N'2024-01-21T00:40:27.637' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (179, 39, 229, 1, CAST(N'2024-01-21T00:40:27.637' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (180, 39, 230, 1, CAST(N'2024-01-21T00:40:27.637' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (181, 39, 249, 1, CAST(N'2024-01-21T00:40:27.637' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (182, 39, 227, 2, CAST(N'2024-01-21T00:40:34.533' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (183, 39, 228, 2, CAST(N'2024-01-21T00:40:34.533' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (184, 39, 229, 2, CAST(N'2024-01-21T00:40:34.533' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (185, 39, 230, 2, CAST(N'2024-01-21T00:40:34.533' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (186, 39, 249, 2, CAST(N'2024-01-21T00:40:34.533' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (199, 71, 211, 1, CAST(N'2024-01-21T00:41:28.877' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (200, 71, 213, 1, CAST(N'2024-01-21T00:41:28.877' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (201, 71, 214, 1, CAST(N'2024-01-21T00:41:28.877' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (202, 71, 215, 1, CAST(N'2024-01-21T00:41:28.877' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (203, 71, 216, 1, CAST(N'2024-01-21T00:41:28.877' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (204, 71, 217, 1, CAST(N'2024-01-21T00:41:28.877' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (205, 71, 218, 1, CAST(N'2024-01-21T00:41:28.877' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (206, 71, 219, 1, CAST(N'2024-01-21T00:41:28.877' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (207, 71, 220, 1, CAST(N'2024-01-21T00:41:28.877' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (208, 71, 221, 1, CAST(N'2024-01-21T00:41:28.877' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (209, 71, 222, 1, CAST(N'2024-01-21T00:41:28.877' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (210, 71, 250, 1, CAST(N'2024-01-21T00:41:28.877' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (245, 5, 171, 2, CAST(N'2024-01-21T19:22:57.047' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (246, 5, 172, 2, CAST(N'2024-01-21T19:22:57.047' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (247, 5, 174, 2, CAST(N'2024-01-21T19:22:57.047' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (248, 5, 176, 2, CAST(N'2024-01-21T19:22:57.047' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (249, 5, 179, 2, CAST(N'2024-01-21T19:22:57.047' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (250, 5, 267, 2, CAST(N'2024-01-21T19:22:57.047' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (251, 5, 171, 1, CAST(N'2024-01-21T19:23:29.497' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (252, 5, 172, 1, CAST(N'2024-01-21T19:23:29.497' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (253, 5, 174, 1, CAST(N'2024-01-21T19:23:29.497' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (254, 5, 176, 1, CAST(N'2024-01-21T19:23:29.497' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (255, 5, 179, 1, CAST(N'2024-01-21T19:23:29.497' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (256, 5, 232, 1, CAST(N'2024-01-21T19:23:29.497' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (257, 5, 267, 1, CAST(N'2024-01-21T19:23:29.497' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (269, 37, 237, 2, CAST(N'2024-01-23T08:25:36.427' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (270, 37, 239, 2, CAST(N'2024-01-23T08:25:36.427' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (271, 37, 240, 2, CAST(N'2024-01-23T08:25:36.427' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (272, 37, 241, 2, CAST(N'2024-01-23T08:25:36.427' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (273, 37, 242, 2, CAST(N'2024-01-23T08:25:36.427' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (274, 37, 243, 2, CAST(N'2024-01-23T08:25:36.427' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (275, 37, 245, 2, CAST(N'2024-01-23T08:25:36.427' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (276, 37, 246, 2, CAST(N'2024-01-23T08:25:36.427' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (277, 37, 247, 2, CAST(N'2024-01-23T08:25:36.427' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (278, 71, 211, 2, CAST(N'2024-01-23T08:26:07.443' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (279, 71, 213, 2, CAST(N'2024-01-23T08:26:07.443' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (280, 71, 214, 2, CAST(N'2024-01-23T08:26:07.443' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (281, 71, 215, 2, CAST(N'2024-01-23T08:26:07.443' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (282, 71, 216, 2, CAST(N'2024-01-23T08:26:07.443' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (283, 71, 217, 2, CAST(N'2024-01-23T08:26:07.443' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (284, 71, 218, 2, CAST(N'2024-01-23T08:26:07.443' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (285, 71, 219, 2, CAST(N'2024-01-23T08:26:07.443' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (286, 71, 220, 2, CAST(N'2024-01-23T08:26:07.443' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (287, 71, 221, 2, CAST(N'2024-01-23T08:26:07.443' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (288, 71, 222, 2, CAST(N'2024-01-23T08:26:07.443' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (289, 71, 250, 2, CAST(N'2024-01-23T08:26:07.443' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (290, 71, 225, 2, CAST(N'2024-01-23T08:26:07.443' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (303, 35, 200, 2, CAST(N'2024-01-23T08:43:56.060' AS DateTime), N'2')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (304, 35, 201, 2, CAST(N'2024-01-23T08:43:56.060' AS DateTime), N'2')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (305, 35, 202, 2, CAST(N'2024-01-23T08:43:56.060' AS DateTime), N'2')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (306, 35, 204, 2, CAST(N'2024-01-23T08:43:56.060' AS DateTime), N'2')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (307, 35, 206, 2, CAST(N'2024-01-23T08:43:56.060' AS DateTime), N'2')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (308, 35, 203, 2, CAST(N'2024-01-23T08:43:56.060' AS DateTime), N'2')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (309, 35, 210, 2, CAST(N'2024-01-23T08:43:56.060' AS DateTime), N'2')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (310, 35, 236, 2, CAST(N'2024-01-23T08:43:56.060' AS DateTime), N'2')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (311, 35, 235, 2, CAST(N'2024-01-23T08:43:56.060' AS DateTime), N'2')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (312, 35, 208, 2, CAST(N'2024-01-23T08:43:56.060' AS DateTime), N'2')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (313, 35, 269, 2, CAST(N'2024-01-23T08:43:56.060' AS DateTime), N'2')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (321, 48, 187, 2, CAST(N'2024-01-23T08:53:16.740' AS DateTime), N'2')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (322, 48, 189, 2, CAST(N'2024-01-23T08:53:16.740' AS DateTime), N'2')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (323, 48, 193, 2, CAST(N'2024-01-23T08:53:16.740' AS DateTime), N'2')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (324, 48, 196, 2, CAST(N'2024-01-23T08:53:16.740' AS DateTime), N'2')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (325, 48, 198, 2, CAST(N'2024-01-23T08:53:16.740' AS DateTime), N'2')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (326, 48, 234, 2, CAST(N'2024-01-23T08:53:16.740' AS DateTime), N'2')
GO
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (327, 48, 268, 2, CAST(N'2024-01-23T08:53:16.740' AS DateTime), N'2')
INSERT [dbo].[Sys_MenuTableColsRole] ([Id], [MenuId], [MenuTableColsId], [RoleId], [CreateTime], [CreateUser]) VALUES (328, 48, 270, 2, CAST(N'2024-01-23T08:53:16.740' AS DateTime), N'2')
SET IDENTITY_INSERT [dbo].[Sys_MenuTableColsRole] OFF
SET IDENTITY_INSERT [dbo].[Sys_MenuTableRowAuth] ON 

INSERT [dbo].[Sys_MenuTableRowAuth] ([Id], [MenuId], [RuleJson], [IsOpen], [Remark], [Sort], [CreateTime], [CreateUser]) VALUES (8, 37, N'[{"id":"1","pid":"0","matchGroup":"Or","level":1,"matchingWhere":[{"id":"8216664147","fieldKey":"CurrentRole","matchSymbolKey":"NotContains","matchSymbolOptions":[{"label":"包含","value":"Contains","disabled":false},{"label":"不包含","value":"NotContains","disabled":false}],"showControl":3,"matchData":[{"label":"超级管理员","value":"1","disabled":false,"closable":false},{"label":"普通","value":"2","disabled":false,"closable":false},{"label":"444444","value":"3","disabled":false,"closable":false},{"label":"5555555","value":"4","disabled":false,"closable":false},{"label":"45566777","value":"5","disabled":false,"closable":false},{"label":"22222","value":"6","disabled":false}],"matchDataKey":"","matchDataKeys":["5"]},{"id":"4188757325","fieldKey":"Age","matchSymbolKey":">=","matchSymbolOptions":[{"label":"等于","value":"=","disabled":false},{"label":"不等于","value":"!=","disabled":false},{"label":"大于","value":">","disabled":false},{"label":"大于等于","value":">=","disabled":false},{"label":"小于","value":"<","disabled":false},{"label":"小于等于","value":"<=","disabled":false}],"showControl":1,"matchData":[],"matchDataKey":"20"},{"id":"8389974188","fieldKey":"Age","matchSymbolKey":"<=","matchSymbolOptions":[{"label":"等于","value":"=","disabled":false},{"label":"不等于","value":"!=","disabled":false},{"label":"大于","value":">","disabled":false},{"label":"大于等于","value":">=","disabled":false},{"label":"小于","value":"<","disabled":false},{"label":"小于等于","value":"<=","disabled":false}],"showControl":1,"matchData":[],"matchDataKey":"50"}],"children":[]}]', 1, N'登录用户角色不包含xxx,年龄大于等于20小于、等于50的数据', 0, CAST(N'2024-01-23T08:31:10.983' AS DateTime), N'2')
SET IDENTITY_INSERT [dbo].[Sys_MenuTableRowAuth] OFF
SET IDENTITY_INSERT [dbo].[Sys_MenuTableRowAuthConfig] ON 

INSERT [dbo].[Sys_MenuTableRowAuthConfig] ([Id], [MenuId], [PermissionsField], [PermissionsFieldName], [ConditionalEquationValue], [ShowControl], [ShowControlDataSource], [IsOpen], [CreateTime], [CreateUser]) VALUES (17, 5, N'CurrentUser', N'当前登录用户', 192, 3, 2, 1, CAST(N'2024-01-23T13:07:08.553' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableRowAuthConfig] ([Id], [MenuId], [PermissionsField], [PermissionsFieldName], [ConditionalEquationValue], [ShowControl], [ShowControlDataSource], [IsOpen], [CreateTime], [CreateUser]) VALUES (18, 5, N'CurrentRole', N'当前登录用户角色', 192, 3, 3, 1, CAST(N'2024-01-16T08:34:39.547' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableRowAuthConfig] ([Id], [MenuId], [PermissionsField], [PermissionsFieldName], [ConditionalEquationValue], [ShowControl], [ShowControlDataSource], [IsOpen], [CreateTime], [CreateUser]) VALUES (19, 5, N'CreateUser', N'创建用户', 195, 3, 2, 1, CAST(N'2024-01-16T08:35:43.370' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableRowAuthConfig] ([Id], [MenuId], [PermissionsField], [PermissionsFieldName], [ConditionalEquationValue], [ShowControl], [ShowControlDataSource], [IsOpen], [CreateTime], [CreateUser]) VALUES (20, 5, N'MenuTitle', N'菜单标题', 3, 1, 1, 1, CAST(N'2024-01-16T08:36:19.597' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableRowAuthConfig] ([Id], [MenuId], [PermissionsField], [PermissionsFieldName], [ConditionalEquationValue], [ShowControl], [ShowControlDataSource], [IsOpen], [CreateTime], [CreateUser]) VALUES (21, 35, N'CurrentUser', N'当前登录用户', 192, 3, 2, 1, CAST(N'2024-01-16T08:34:25.823' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableRowAuthConfig] ([Id], [MenuId], [PermissionsField], [PermissionsFieldName], [ConditionalEquationValue], [ShowControl], [ShowControlDataSource], [IsOpen], [CreateTime], [CreateUser]) VALUES (22, 35, N'CurrentRole', N'当前登录用户角色', 192, 3, 3, 1, CAST(N'2024-01-16T08:34:39.547' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableRowAuthConfig] ([Id], [MenuId], [PermissionsField], [PermissionsFieldName], [ConditionalEquationValue], [ShowControl], [ShowControlDataSource], [IsOpen], [CreateTime], [CreateUser]) VALUES (23, 35, N'CreateUser', N'创建用户', 195, 3, 2, 1, CAST(N'2024-01-16T08:35:43.370' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableRowAuthConfig] ([Id], [MenuId], [PermissionsField], [PermissionsFieldName], [ConditionalEquationValue], [ShowControl], [ShowControlDataSource], [IsOpen], [CreateTime], [CreateUser]) VALUES (24, 37, N'CurrentUser', N'当前登录用户', 192, 3, 2, 1, CAST(N'2024-01-16T08:34:25.823' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableRowAuthConfig] ([Id], [MenuId], [PermissionsField], [PermissionsFieldName], [ConditionalEquationValue], [ShowControl], [ShowControlDataSource], [IsOpen], [CreateTime], [CreateUser]) VALUES (25, 37, N'CurrentRole', N'当前登录用户角色', 192, 3, 3, 1, CAST(N'2024-01-16T08:34:39.547' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableRowAuthConfig] ([Id], [MenuId], [PermissionsField], [PermissionsFieldName], [ConditionalEquationValue], [ShowControl], [ShowControlDataSource], [IsOpen], [CreateTime], [CreateUser]) VALUES (26, 37, N'CreateUser', N'创建用户', 195, 3, 2, 1, CAST(N'2024-01-16T08:35:43.370' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableRowAuthConfig] ([Id], [MenuId], [PermissionsField], [PermissionsFieldName], [ConditionalEquationValue], [ShowControl], [ShowControlDataSource], [IsOpen], [CreateTime], [CreateUser]) VALUES (27, 39, N'CurrentUser', N'当前登录用户', 192, 3, 2, 1, CAST(N'2024-01-16T08:34:25.823' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableRowAuthConfig] ([Id], [MenuId], [PermissionsField], [PermissionsFieldName], [ConditionalEquationValue], [ShowControl], [ShowControlDataSource], [IsOpen], [CreateTime], [CreateUser]) VALUES (28, 39, N'CurrentRole', N'当前登录用户角色', 192, 3, 3, 1, CAST(N'2024-01-16T08:34:39.547' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableRowAuthConfig] ([Id], [MenuId], [PermissionsField], [PermissionsFieldName], [ConditionalEquationValue], [ShowControl], [ShowControlDataSource], [IsOpen], [CreateTime], [CreateUser]) VALUES (29, 39, N'CreateUser', N'创建用户', 195, 3, 2, 1, CAST(N'2024-01-16T08:35:43.370' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableRowAuthConfig] ([Id], [MenuId], [PermissionsField], [PermissionsFieldName], [ConditionalEquationValue], [ShowControl], [ShowControlDataSource], [IsOpen], [CreateTime], [CreateUser]) VALUES (30, 48, N'CurrentUser', N'当前登录用户', 192, 3, 2, 1, CAST(N'2024-01-16T08:34:25.823' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableRowAuthConfig] ([Id], [MenuId], [PermissionsField], [PermissionsFieldName], [ConditionalEquationValue], [ShowControl], [ShowControlDataSource], [IsOpen], [CreateTime], [CreateUser]) VALUES (31, 48, N'CurrentRole', N'当前登录用户角色', 192, 3, 3, 1, CAST(N'2024-01-16T08:34:39.547' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableRowAuthConfig] ([Id], [MenuId], [PermissionsField], [PermissionsFieldName], [ConditionalEquationValue], [ShowControl], [ShowControlDataSource], [IsOpen], [CreateTime], [CreateUser]) VALUES (32, 48, N'CreateUser', N'创建用户', 195, 3, 2, 1, CAST(N'2024-01-16T08:35:43.370' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableRowAuthConfig] ([Id], [MenuId], [PermissionsField], [PermissionsFieldName], [ConditionalEquationValue], [ShowControl], [ShowControlDataSource], [IsOpen], [CreateTime], [CreateUser]) VALUES (33, 71, N'CurrentUser', N'当前登录用户', 192, 3, 2, 1, CAST(N'2024-01-16T08:34:25.823' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableRowAuthConfig] ([Id], [MenuId], [PermissionsField], [PermissionsFieldName], [ConditionalEquationValue], [ShowControl], [ShowControlDataSource], [IsOpen], [CreateTime], [CreateUser]) VALUES (34, 71, N'CurrentRole', N'当前登录用户角色', 192, 3, 3, 1, CAST(N'2024-01-16T08:34:39.547' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableRowAuthConfig] ([Id], [MenuId], [PermissionsField], [PermissionsFieldName], [ConditionalEquationValue], [ShowControl], [ShowControlDataSource], [IsOpen], [CreateTime], [CreateUser]) VALUES (35, 71, N'CreateUser', N'创建用户', 195, 3, 2, 1, CAST(N'2024-01-16T08:35:43.370' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableRowAuthConfig] ([Id], [MenuId], [PermissionsField], [PermissionsFieldName], [ConditionalEquationValue], [ShowControl], [ShowControlDataSource], [IsOpen], [CreateTime], [CreateUser]) VALUES (36, 72, N'CurrentUser', N'当前登录用户', 192, 3, 2, 1, CAST(N'2024-01-16T08:34:25.823' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableRowAuthConfig] ([Id], [MenuId], [PermissionsField], [PermissionsFieldName], [ConditionalEquationValue], [ShowControl], [ShowControlDataSource], [IsOpen], [CreateTime], [CreateUser]) VALUES (37, 72, N'CurrentRole', N'当前登录用户角色', 192, 3, 3, 1, CAST(N'2024-01-16T08:34:39.547' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableRowAuthConfig] ([Id], [MenuId], [PermissionsField], [PermissionsFieldName], [ConditionalEquationValue], [ShowControl], [ShowControlDataSource], [IsOpen], [CreateTime], [CreateUser]) VALUES (38, 72, N'CreateUser', N'创建用户', 195, 3, 2, 1, CAST(N'2024-01-16T08:35:43.370' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableRowAuthConfig] ([Id], [MenuId], [PermissionsField], [PermissionsFieldName], [ConditionalEquationValue], [ShowControl], [ShowControlDataSource], [IsOpen], [CreateTime], [CreateUser]) VALUES (39, 5, N'Age', N'年龄', 63, 1, 1, 1, CAST(N'2024-01-21T20:30:20.513' AS DateTime), N'1')
INSERT [dbo].[Sys_MenuTableRowAuthConfig] ([Id], [MenuId], [PermissionsField], [PermissionsFieldName], [ConditionalEquationValue], [ShowControl], [ShowControlDataSource], [IsOpen], [CreateTime], [CreateUser]) VALUES (40, 37, N'Age', N'年龄', 63, 1, 1, 1, CAST(N'2024-01-21T20:30:54.450' AS DateTime), N'1')
SET IDENTITY_INSERT [dbo].[Sys_MenuTableRowAuthConfig] OFF
SET IDENTITY_INSERT [dbo].[Sys_Role] ON 

INSERT [dbo].[Sys_Role] ([RoleId], [RoleName], [CreateTime], [CreateUser]) VALUES (1, N'超级管理员', CAST(N'2023-09-28T00:00:00.000' AS DateTime), N'1')
INSERT [dbo].[Sys_Role] ([RoleId], [RoleName], [CreateTime], [CreateUser]) VALUES (2, N'普通', CAST(N'2023-10-12T15:22:45.243' AS DateTime), N'1')
INSERT [dbo].[Sys_Role] ([RoleId], [RoleName], [CreateTime], [CreateUser]) VALUES (3, N'李四独享角色', CAST(N'2024-07-13T10:01:32.173' AS DateTime), N'2')
SET IDENTITY_INSERT [dbo].[Sys_Role] OFF
SET IDENTITY_INSERT [dbo].[Sys_User] ON 

INSERT [dbo].[Sys_User] ([UserId], [UserName], [Password], [Age], [Sex], [DepartmentId], [CreateTime], [CreateUser]) VALUES (1, N'admin', N'admin140724', 30, 1, 0, CAST(N'2024-01-21T01:14:07.593' AS DateTime), N'2')
INSERT [dbo].[Sys_User] ([UserId], [UserName], [Password], [Age], [Sex], [DepartmentId], [CreateTime], [CreateUser]) VALUES (2, N'张三', N'111111', 19, 1, 0, CAST(N'2023-10-18T09:28:49.690' AS DateTime), N'1')
INSERT [dbo].[Sys_User] ([UserId], [UserName], [Password], [Age], [Sex], [DepartmentId], [CreateTime], [CreateUser]) VALUES (3, N'李四', N'111111', 18, 1, 0, CAST(N'2024-07-13T10:01:10.937' AS DateTime), N'2')
SET IDENTITY_INSERT [dbo].[Sys_User] OFF
SET IDENTITY_INSERT [dbo].[Sys_UserRoleRelation] ON 

INSERT [dbo].[Sys_UserRoleRelation] ([UserRoleId], [RoleId], [UserId], [CreateTime], [CreateUser]) VALUES (25, 1, 1, CAST(N'2024-01-21T00:50:09.003' AS DateTime), N'2')
INSERT [dbo].[Sys_UserRoleRelation] ([UserRoleId], [RoleId], [UserId], [CreateTime], [CreateUser]) VALUES (26, 2, 2, CAST(N'2024-07-13T09:57:09.587' AS DateTime), N'2')
SET IDENTITY_INSERT [dbo].[Sys_UserRoleRelation] OFF
ALTER TABLE [dbo].[Sys_Button] ADD  DEFAULT ((0)) FOR [OrderBy]
GO
ALTER TABLE [dbo].[Sys_ButtonRole] ADD  DEFAULT ((1)) FOR [RoleId]
GO
ALTER TABLE [dbo].[Sys_MenuTableCols] ADD  CONSTRAINT [DF__Sys_MenuT__IsDat__778AC167]  DEFAULT ((2)) FOR [DataRowAuthType]
GO
ALTER TABLE [dbo].[Sys_MenuTableColsRole] ADD  CONSTRAINT [DF__Sys_MenuT__RoleI__619B8048]  DEFAULT ((1)) FOR [RoleId]
GO
ALTER TABLE [dbo].[Sys_Button]  WITH CHECK ADD  CONSTRAINT [FK_Button_ButtonStyle] FOREIGN KEY([ButtonStyleId])
REFERENCES [dbo].[Sys_ButtonStyle] ([ButtonStyleId])
GO
ALTER TABLE [dbo].[Sys_Button] CHECK CONSTRAINT [FK_Button_ButtonStyle]
GO
ALTER TABLE [dbo].[Sys_MenuTableCols]  WITH CHECK ADD  CONSTRAINT [FK_Sys_MenuTableCols_Sys_MenuTableCols] FOREIGN KEY([Id])
REFERENCES [dbo].[Sys_MenuTableCols] ([Id])
GO
ALTER TABLE [dbo].[Sys_MenuTableCols] CHECK CONSTRAINT [FK_Sys_MenuTableCols_Sys_MenuTableCols]
GO
ALTER TABLE [dbo].[Sys_MenuTableColsRole]  WITH CHECK ADD  CONSTRAINT [FK_Sys_MenuTableColsRole_Sys_MenuTableCols] FOREIGN KEY([MenuTableColsId])
REFERENCES [dbo].[Sys_MenuTableCols] ([Id])
GO
ALTER TABLE [dbo].[Sys_MenuTableColsRole] CHECK CONSTRAINT [FK_Sys_MenuTableColsRole_Sys_MenuTableCols]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'按钮名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Button', @level2type=N'COLUMN',@level2name=N'ButtonName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'按钮key（事件）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Button', @level2type=N'COLUMN',@level2name=N'ButtonKey'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'样式id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Button', @level2type=N'COLUMN',@level2name=N'ButtonStyleId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Button', @level2type=N'COLUMN',@level2name=N'OrderBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Button', @level2type=N'COLUMN',@level2name=N'MenuId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Button', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人员' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Button', @level2type=N'COLUMN',@level2name=N'CreateUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'按钮表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Button'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_ButtonRole', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人员' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_ButtonRole', @level2type=N'COLUMN',@level2name=N'CreateUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'按钮权限表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_ButtonRole'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'边框样式  soild dashed dotted' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_ButtonStyle', @level2type=N'COLUMN',@level2name=N'BordersStyle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'按钮大小  lg sm xs' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_ButtonStyle', @level2type=N'COLUMN',@level2name=N'Size'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'样式 primary normal warm danger' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_ButtonStyle', @level2type=N'COLUMN',@level2name=N'Types'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'图标' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_ButtonStyle', @level2type=N'COLUMN',@level2name=N'Icon'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'样式名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_ButtonStyle', @level2type=N'COLUMN',@level2name=N'ButtonStyleName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_ButtonStyle', @level2type=N'COLUMN',@level2name=N'OrderBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'边框颜色  green blue orange red' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_ButtonStyle', @level2type=N'COLUMN',@level2name=N'Borders'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否圆角' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_ButtonStyle', @level2type=N'COLUMN',@level2name=N'IsRadius'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_ButtonStyle', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人员' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_ButtonStyle', @level2type=N'COLUMN',@level2name=N'CreateUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'按钮样式表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_ButtonStyle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'部门名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Department', @level2type=N'COLUMN',@level2name=N'DepartmentName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上级部门id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Department', @level2type=N'COLUMN',@level2name=N'Pid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Department', @level2type=N'COLUMN',@level2name=N'Sort'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'部门表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Department'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'错误类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_ExceptionLog', @level2type=N'COLUMN',@level2name=N'ExceptionType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'错误信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_ExceptionLog', @level2type=N'COLUMN',@level2name=N'ExceptionMsg'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'错误时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_ExceptionLog', @level2type=N'COLUMN',@level2name=N'ExceptionTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作人员姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_ExceptionLog', @level2type=N'COLUMN',@level2name=N'OperateUserName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作人员id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_ExceptionLog', @level2type=N'COLUMN',@level2name=N'OperateUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否处理' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_ExceptionLog', @level2type=N'COLUMN',@level2name=N'IsHandle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'处理人姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_ExceptionLog', @level2type=N'COLUMN',@level2name=N'HandleUserName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'处理人id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_ExceptionLog', @level2type=N'COLUMN',@level2name=N'HandleUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'错误日志' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_ExceptionLog'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Menu', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单路径' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Menu', @level2type=N'COLUMN',@level2name=N'MenuUrl'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单图标' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Menu', @level2type=N'COLUMN',@level2name=N'MenuIcon'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单标题' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Menu', @level2type=N'COLUMN',@level2name=N'MenuTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'父级id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Menu', @level2type=N'COLUMN',@level2name=N'Pid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否开启菜单' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Menu', @level2type=N'COLUMN',@level2name=N'IsOpen'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Menu', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人员' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Menu', @level2type=N'COLUMN',@level2name=N'CreateUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'路径' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Menu', @level2type=N'COLUMN',@level2name=N'Path'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否验证' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Menu', @level2type=N'COLUMN',@level2name=N'RequireAuth'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'重定向' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Menu', @level2type=N'COLUMN',@level2name=N'Redirect'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Menu'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单角色关系主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_MenuRoleRelation', @level2type=N'COLUMN',@level2name=N'MenuRoleId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_MenuRoleRelation', @level2type=N'COLUMN',@level2name=N'MenuId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_MenuRoleRelation', @level2type=N'COLUMN',@level2name=N'RoleId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_MenuRoleRelation', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人员' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_MenuRoleRelation', @level2type=N'COLUMN',@level2name=N'CreateUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单与角色关系表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_MenuRoleRelation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_MenuTableCols', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_MenuTableCols', @level2type=N'COLUMN',@level2name=N'MenuId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'字段名称（userName）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_MenuTableCols', @level2type=N'COLUMN',@level2name=N'FieldName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'字段类型（stirng、int等）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_MenuTableCols', @level2type=N'COLUMN',@level2name=N'FieldType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'字段标题（用户名称）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_MenuTableCols', @level2type=N'COLUMN',@level2name=N'FieldTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'字段排序（当前菜单下的排序）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_MenuTableCols', @level2type=N'COLUMN',@level2name=N'FieldOrderBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'字段所占宽度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_MenuTableCols', @level2type=N'COLUMN',@level2name=N'FieldWidth'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'字段排序方式（desc、asc）为空不排序' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_MenuTableCols', @level2type=N'COLUMN',@level2name=N'FieldSort'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'字段自定义插槽（要配合layui vue table插件使用）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_MenuTableCols', @level2type=N'COLUMN',@level2name=N'FieldCustomSlot'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'字段对齐方式（left right center）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_MenuTableCols', @level2type=N'COLUMN',@level2name=N'FieldAlign'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'字段列固定（left right）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_MenuTableCols', @level2type=N'COLUMN',@level2name=N'FieldFixed'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'字段所占最小宽度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_MenuTableCols', @level2type=N'COLUMN',@level2name=N'FieldMinWidth'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'当内容过长被隐藏时显示 tooltip' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_MenuTableCols', @level2type=N'COLUMN',@level2name=N'FieldEllipsisTooltip'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_MenuTableCols', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人员' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_MenuTableCols', @level2type=N'COLUMN',@level2name=N'CreateUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1:系统数据 2:创建数据' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_MenuTableCols', @level2type=N'COLUMN',@level2name=N'IsSystemData'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1:属于数据行权限字段 2:不属于数据行权限字段' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_MenuTableCols', @level2type=N'COLUMN',@level2name=N'DataRowAuthType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数据行权限字段（必须和查询表中的字段对应）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_MenuTableCols', @level2type=N'COLUMN',@level2name=N'DataRowAuthField'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数据行权限字段名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_MenuTableCols', @level2type=N'COLUMN',@level2name=N'DataRowAuthFieldName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单table列（设置数据列权限使用）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_MenuTableCols'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_MenuTableColsRole', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人员' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_MenuTableColsRole', @level2type=N'COLUMN',@level2name=N'CreateUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单数据列权限表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_MenuTableColsRole'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_MenuTableRowAuth', @level2type=N'COLUMN',@level2name=N'MenuId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'规则json数据' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_MenuTableRowAuth', @level2type=N'COLUMN',@level2name=N'RuleJson'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否使用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_MenuTableRowAuth', @level2type=N'COLUMN',@level2name=N'IsOpen'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_MenuTableRowAuth', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_MenuTableRowAuth', @level2type=N'COLUMN',@level2name=N'Sort'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_MenuTableRowAuth', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人员' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_MenuTableRowAuth', @level2type=N'COLUMN',@level2name=N'CreateUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单数据行权限' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_MenuTableRowAuth'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_MenuTableRowAuthConfig', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_MenuTableRowAuthConfig', @level2type=N'COLUMN',@level2name=N'MenuId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'权限字段' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_MenuTableRowAuthConfig', @level2type=N'COLUMN',@level2name=N'PermissionsField'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'权限字段名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_MenuTableRowAuthConfig', @level2type=N'COLUMN',@level2name=N'PermissionsFieldName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'条件等式（枚举值）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_MenuTableRowAuthConfig', @level2type=N'COLUMN',@level2name=N'ConditionalEquationValue'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'显示控件（枚举值）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_MenuTableRowAuthConfig', @level2type=N'COLUMN',@level2name=N'ShowControl'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'显示控件的数据源' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_MenuTableRowAuthConfig', @level2type=N'COLUMN',@level2name=N'ShowControlDataSource'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否使用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_MenuTableRowAuthConfig', @level2type=N'COLUMN',@level2name=N'IsOpen'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_MenuTableRowAuthConfig', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人员' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_MenuTableRowAuthConfig', @level2type=N'COLUMN',@level2name=N'CreateUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Role', @level2type=N'COLUMN',@level2name=N'RoleId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Role', @level2type=N'COLUMN',@level2name=N'RoleName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Role', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人员' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Role', @level2type=N'COLUMN',@level2name=N'CreateUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_Role'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_User', @level2type=N'COLUMN',@level2name=N'UserName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_User', @level2type=N'COLUMN',@level2name=N'Password'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户年龄' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_User', @level2type=N'COLUMN',@level2name=N'Age'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户年龄 1:男 2:女' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_User', @level2type=N'COLUMN',@level2name=N'Sex'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'部门id（表Department主键）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_User', @level2type=N'COLUMN',@level2name=N'DepartmentId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_User', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人员' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_User', @level2type=N'COLUMN',@level2name=N'CreateUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'人员表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_User'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_UserRoleRelation', @level2type=N'COLUMN',@level2name=N'RoleId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_UserRoleRelation', @level2type=N'COLUMN',@level2name=N'UserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_UserRoleRelation', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人员' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_UserRoleRelation', @level2type=N'COLUMN',@level2name=N'CreateUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'人员和角色关系表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sys_UserRoleRelation'
GO
