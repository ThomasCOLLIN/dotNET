USE [Hopplr]
GO
SET IDENTITY_INSERT [dbo].[Style] ON 

INSERT [dbo].[Style] ([id], [CSSPath], [Description]) VALUES (1, N'~/css/style1.css', N'style1')
INSERT [dbo].[Style] ([id], [CSSPath], [Description]) VALUES (2, N'~/css/style2.css', N'style2')
INSERT [dbo].[Style] ([id], [CSSPath], [Description]) VALUES (3, N'~/css/style3.css', N'style3')
SET IDENTITY_INSERT [dbo].[Style] OFF
SET IDENTITY_INSERT [dbo].[Theme] ON 

INSERT [dbo].[Theme] ([id], [Description]) VALUES (1, N'Manga')
INSERT [dbo].[Theme] ([id], [Description]) VALUES (2, N'Cinema')
INSERT [dbo].[Theme] ([id], [Description]) VALUES (3, N'Musique')
INSERT [dbo].[Theme] ([id], [Description]) VALUES (4, N'JeuxVideos')
INSERT [dbo].[Theme] ([id], [Description]) VALUES (5, N'Sport')
SET IDENTITY_INSERT [dbo].[Theme] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([id], [StyleId], [Pseudo], [Nom], [Prenom], [Email], [HashPassword]) VALUES (2, 1, N'Deiwos', N'Collin', N'Thomas', N'thmcollin', N'test')
INSERT [dbo].[User] ([id], [StyleId], [Pseudo], [Nom], [Prenom], [Email], [HashPassword]) VALUES (4, 2, N'Allpo', N'Chailloux', N'Kevin', N'kvnchailloux', N'test')
INSERT [dbo].[User] ([id], [StyleId], [Pseudo], [Nom], [Prenom], [Email], [HashPassword]) VALUES (5, 3, N'Eselfar', N'Boulier', N'Remi', N'rmboulier', N'test')
INSERT [dbo].[User] ([id], [StyleId], [Pseudo], [Nom], [Prenom], [Email], [HashPassword]) VALUES (6, 2, N'3rry', N'Morice', N'Erika', N'erkmorice', N'test')
INSERT [dbo].[User] ([id], [StyleId], [Pseudo], [Nom], [Prenom], [Email], [HashPassword]) VALUES (7, 1, N'Cloe', N'G', N'Cloe', N'clg', N'test')
SET IDENTITY_INSERT [dbo].[User] OFF
SET IDENTITY_INSERT [dbo].[Blog] ON 

INSERT [dbo].[Blog] ([id], [UserId], [StyleId], [ThemeId], [Nom], [Description]) VALUES (2, 2, 1, 1, N'MesMangas', N'Voici une presentation de mes mangas preferes')
SET IDENTITY_INSERT [dbo].[Blog] OFF
SET IDENTITY_INSERT [dbo].[MediaType] ON 

INSERT [dbo].[MediaType] ([id], [Description]) VALUES (1, N'Image')
INSERT [dbo].[MediaType] ([id], [Description]) VALUES (2, N'Video')
INSERT [dbo].[MediaType] ([id], [Description]) VALUES (3, N'Musique')
SET IDENTITY_INSERT [dbo].[MediaType] OFF
SET IDENTITY_INSERT [dbo].[Article] ON 

INSERT [dbo].[Article] ([id], [blogId], [MediaUrl], [MediaTypeId], [Text]) VALUES (2, 2, N'url', 1, N'School Rumble')
INSERT [dbo].[Article] ([id], [blogId], [MediaUrl], [MediaTypeId], [Text]) VALUES (3, 2, N'url', 1, N'Air Gear')
INSERT [dbo].[Article] ([id], [blogId], [MediaUrl], [MediaTypeId], [Text]) VALUES (4, 2, N'url', 1, N'Mar')
SET IDENTITY_INSERT [dbo].[Article] OFF
SET IDENTITY_INSERT [dbo].[Tag] ON 

INSERT [dbo].[Tag] ([id], [name]) VALUES (1, N'anime')
INSERT [dbo].[Tag] ([id], [name]) VALUES (2, N'tennis')
INSERT [dbo].[Tag] ([id], [name]) VALUES (3, N'hockey')
INSERT [dbo].[Tag] ([id], [name]) VALUES (4, N'dotNET')
SET IDENTITY_INSERT [dbo].[Tag] OFF
SET IDENTITY_INSERT [dbo].[ArticleTag] ON 

INSERT [dbo].[ArticleTag] ([id], [TagId], [ArticleId]) VALUES (2, 1, 2)
INSERT [dbo].[ArticleTag] ([id], [TagId], [ArticleId]) VALUES (3, 2, 2)
INSERT [dbo].[ArticleTag] ([id], [TagId], [ArticleId]) VALUES (4, 1, 3)
INSERT [dbo].[ArticleTag] ([id], [TagId], [ArticleId]) VALUES (5, 1, 4)
SET IDENTITY_INSERT [dbo].[ArticleTag] OFF
SET IDENTITY_INSERT [dbo].[Comment] ON 

INSERT [dbo].[Comment] ([id], [UserId], [ArticleId], [Comment], [Date]) VALUES (1, 4, 2, N'cool', CAST(0x0000A1F900000000 AS DateTime))
INSERT [dbo].[Comment] ([id], [UserId], [ArticleId], [Comment], [Date]) VALUES (2, 5, 3, N'naze', CAST(0x0000A1F900000000 AS DateTime))
INSERT [dbo].[Comment] ([id], [UserId], [ArticleId], [Comment], [Date]) VALUES (3, 7, 4, N'nul', CAST(0x0000A1F900000000 AS DateTime))
INSERT [dbo].[Comment] ([id], [UserId], [ArticleId], [Comment], [Date]) VALUES (4, 2, 4, N'noob', CAST(0x0000A1F900000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[Comment] OFF
SET IDENTITY_INSERT [dbo].[Follow] ON 

INSERT [dbo].[Follow] ([Id], [UserId], [BlogId]) VALUES (1, 5, 2)
INSERT [dbo].[Follow] ([Id], [UserId], [BlogId]) VALUES (3, 4, 2)
INSERT [dbo].[Follow] ([Id], [UserId], [BlogId]) VALUES (4, 6, 2)
INSERT [dbo].[Follow] ([Id], [UserId], [BlogId]) VALUES (5, 7, 2)
SET IDENTITY_INSERT [dbo].[Follow] OFF
