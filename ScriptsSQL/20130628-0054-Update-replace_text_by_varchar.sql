USE [Hopplr]
BEGIN TRANSACTION
ALTER TABLE [T_Article]
ALTER COLUMN [Text] varchar(MAX)
GO

ALTER TABLE [T_Article]
ALTER COLUMN [MediaUrl] varchar(MAX)
GO

ALTER TABLE [T_Blog]
ALTER COLUMN [Description] varchar(MAX)
GO

ALTER TABLE [T_Comment]
ALTER COLUMN [Comment] varchar(MAX)
GO

ALTER TABLE [T_MediaType]
ALTER COLUMN [Description] varchar(50)
GO

ALTER TABLE [T_Style]
ALTER COLUMN [Description] varchar(50)
GO

ALTER TABLE [T_Theme]
ALTER COLUMN [Description] varchar(50)
GO
COMMIT