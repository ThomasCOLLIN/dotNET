USE [Hopplr]
GO
SET IDENTITY_INSERT [dbo].[T_MediaType] ON 

INSERT [dbo].[T_MediaType] ([Id], [Description]) VALUES (1, N'Image')
INSERT [dbo].[T_MediaType] ([Id], [Description]) VALUES (2, N'Vidéo')
INSERT [dbo].[T_MediaType] ([Id], [Description]) VALUES (3, N'Musique')
SET IDENTITY_INSERT [dbo].[T_MediaType] OFF
SET IDENTITY_INSERT [dbo].[T_Style] ON 

INSERT [dbo].[T_Style] ([Id], [CSSPath], [Description]) VALUES (1, N'~/Content/css/style1.css', N'Default')
INSERT [dbo].[T_Style] ([Id], [CSSPath], [Description]) VALUES (2, N'~/Content/css/style2.css', N'Snowy')
INSERT [dbo].[T_Style] ([Id], [CSSPath], [Description]) VALUES (3, N'~/Content/css/style3.css', N'Dark')
INSERT [dbo].[T_Style] ([Id], [CSSPath], [Description]) VALUES (3, N'~/Content/css/style4.css', N'Sunny')
INSERT [dbo].[T_Style] ([Id], [CSSPath], [Description]) VALUES (3, N'~/Content/css/style5.css', N'Pinky')
SET IDENTITY_INSERT [dbo].[T_Style] OFF
SET IDENTITY_INSERT [dbo].[T_Theme] ON 

INSERT [dbo].[T_Theme] ([Id], [Description]) VALUES (1, N'Manga')
INSERT [dbo].[T_Theme] ([Id], [Description]) VALUES (2, N'Cinéma')
INSERT [dbo].[T_Theme] ([Id], [Description]) VALUES (3, N'Musique')
INSERT [dbo].[T_Theme] ([Id], [Description]) VALUES (4, N'JeuxVidéos')
INSERT [dbo].[T_Theme] ([Id], [Description]) VALUES (5, N'Sport')
SET IDENTITY_INSERT [dbo].[T_Theme] OFF
SET IDENTITY_INSERT [dbo].[T_User] ON 

INSERT [dbo].[T_User] ([Id], [StyleId], [Login], [LastName], [FirstName], [Email], [HashPassword]) VALUES (2, 1, N'Deiwos', N'Collin', N'Thomas', N'thmcollin@gmail.com', N'test')
INSERT [dbo].[T_User] ([Id], [StyleId], [Login], [LastName], [FirstName], [Email], [HashPassword]) VALUES (3, 2, N'Allpo', N'Chailloux', N'Kévin', N'kvnchailloux@gmail.com', N'test')
INSERT [dbo].[T_User] ([Id], [StyleId], [Login], [LastName], [FirstName], [Email], [HashPassword]) VALUES (4, 3, N'Eselfar', N'Boulier', N'Remi', N'rmboulier@yahoo.fr', N'test')
INSERT [dbo].[T_User] ([Id], [StyleId], [Login], [LastName], [FirstName], [Email], [HashPassword]) VALUES (8, 2, N'3rry', N'Morice', N'Erika', N'erkmorice', N'test')
INSERT [dbo].[T_User] ([Id], [StyleId], [Login], [LastName], [FirstName], [Email], [HashPassword]) VALUES (9, 1, N'Cloe', N'Goldsztejn', N'Cloe', N'clgolsztejn', N'test')
SET IDENTITY_INSERT [dbo].[T_User] OFF
SET IDENTITY_INSERT [dbo].[T_Blog] ON 

INSERT [dbo].[T_Blog] ([Id], [UserId], [StyleId], [ThemeId], [Name], [Description], [CreationDate]) VALUES (2, 2, 1, 1, N'Mes Mangas', N'Voici une présentation de mes mangas préférés', CAST(0x0000A1E6010115AC AS DateTime))
SET IDENTITY_INSERT [dbo].[T_Blog] OFF
SET IDENTITY_INSERT [dbo].[T_Article] ON 

INSERT [dbo].[T_Article] ([Id], [BlogId], [MediaUrl], [MediaTypeId], [Text], [CreationDate]) VALUES (2, 2, N'url1', 1, N'School Rumble', CAST(0x0000A1E60101E89C AS DateTime))
INSERT [dbo].[T_Article] ([Id], [BlogId], [MediaUrl], [MediaTypeId], [Text], [CreationDate]) VALUES (3, 2, N'url2', 1, N'Air Gear', CAST(0x0000A1E601022EEC AS DateTime))
INSERT [dbo].[T_Article] ([Id], [BlogId], [MediaUrl], [MediaTypeId], [Text], [CreationDate]) VALUES (4, 2, N'url3', 1, N'Mar', CAST(0x0000A1E60111906C AS DateTime))
SET IDENTITY_INSERT [dbo].[T_Article] OFF
SET IDENTITY_INSERT [dbo].[T_Tag] ON 

INSERT [dbo].[T_Tag] ([Id], [Name]) VALUES (1, N'Anime')
INSERT [dbo].[T_Tag] ([Id], [Name]) VALUES (2, N'Tennis')
INSERT [dbo].[T_Tag] ([Id], [Name]) VALUES (3, N'Hockey')
INSERT [dbo].[T_Tag] ([Id], [Name]) VALUES (4, N'dotNet')
SET IDENTITY_INSERT [dbo].[T_Tag] OFF
SET IDENTITY_INSERT [dbo].[T_ArticleTag] ON 

INSERT [dbo].[T_ArticleTag] ([Id], [TagId], [ArticleId]) VALUES (1, 1, 2)
INSERT [dbo].[T_ArticleTag] ([Id], [TagId], [ArticleId]) VALUES (2, 2, 2)
INSERT [dbo].[T_ArticleTag] ([Id], [TagId], [ArticleId]) VALUES (3, 1, 3)
INSERT [dbo].[T_ArticleTag] ([Id], [TagId], [ArticleId]) VALUES (4, 1, 4)
SET IDENTITY_INSERT [dbo].[T_ArticleTag] OFF
SET IDENTITY_INSERT [dbo].[T_Comment] ON 

INSERT [dbo].[T_Comment] ([Id], [UserId], [ArticleId], [Comment], [CreationDate]) VALUES (1, 4, 2, N'Cool', CAST(0x0000A1E6010115AC AS DateTime))
INSERT [dbo].[T_Comment] ([Id], [UserId], [ArticleId], [Comment], [CreationDate]) VALUES (8, 8, 3, N'Naze', CAST(0x0000A1E60103D4CC AS DateTime))
INSERT [dbo].[T_Comment] ([Id], [UserId], [ArticleId], [Comment], [CreationDate]) VALUES (9, 9, 4, N'Nul', CAST(0x0000A1E6010693EC AS DateTime))
INSERT [dbo].[T_Comment] ([Id], [UserId], [ArticleId], [Comment], [CreationDate]) VALUES (10, 2, 4, N'Noob', CAST(0x0000A1E60111906C AS DateTime))
SET IDENTITY_INSERT [dbo].[T_Comment] OFF
SET IDENTITY_INSERT [dbo].[T_Follow] ON 

INSERT [dbo].[T_Follow] ([Id], [UserId], [BlogId]) VALUES (4, 8, 2)
INSERT [dbo].[T_Follow] ([Id], [UserId], [BlogId]) VALUES (5, 4, 2)
INSERT [dbo].[T_Follow] ([Id], [UserId], [BlogId]) VALUES (8, 9, 2)
INSERT [dbo].[T_Follow] ([Id], [UserId], [BlogId]) VALUES (9, 3, 2)
SET IDENTITY_INSERT [dbo].[T_Follow] OFF
