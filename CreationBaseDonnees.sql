USE master 
GO

ALTER DATABASE dbContact SET AUTO_CLOSE OFF 
GO

DROP DATABASE IF EXISTS dbContact
GO
 
CREATE DATABASE dbContact
GO

USE dbContact

DROP Table IF EXISTS Utilisateurs 
GO

CREATE TABLE [dbo].[Utilisateurs]
(
	Id Int Not Null  identity (100,8) Primary Key Clustered,
	[username] [varchar](25) NOT NULL Unique,
	[password] [varchar](15) NOT NULL
)

DROP Table IF EXISTS [Contacts] 
GO

CREATE TABLE [dbo].[Contacts]
(
	Id Int Not Null  identity (1,1) Primary Key Clustered,
	[Id_utilisateurs] int NOT NULL Foreign Key References [Utilisateurs](Id),
	[nom] [varchar](15) NOT NULL,
	[prenom] [varchar](15) NOT NULL,
	[telephone] [varchar](13) NULL,
	[courriel] [varchar](30) NULL,
	CONSTRAINT C_TelContact CHECK (telephone LIKE '([0-9][0-9][0-9])[0-9][0-9][0-9]-[0-9][0-9][0-9][0-9]'),
)
