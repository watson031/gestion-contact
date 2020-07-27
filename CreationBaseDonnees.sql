USE master 
GO

DROP DATABASE IF EXISTS dbContacts
GO
 
CREATE DATABASE dbContacts
GO

USE dbContacts

DROP Table IF EXISTS Utilisateurs 
GO

CREATE TABLE [dbo].[Utilisateurs]
(
	Id Int Not Null  identity (1,1) Primary Key Clustered,
	[username] [varchar](25) NOT NULL Unique,
	[password] [varchar](8) NOT NULL,
	[nom] [varchar](15) NOT NULL,
	[prenom] [varchar](15) NOT NULL,
)

DROP Table IF EXISTS [Contacts] 
GO

CREATE TABLE [dbo].[Contacts]
(
	Id Int Not Null  identity (1,1) Primary Key Clustered,
	[Id_contacts] int NOT NULL Foreign Key References [Utilisateurs](Id),
	[nom] [varchar](15) NOT NULL,
	[prenom] [varchar](15) NOT NULL,
	[telephone] [varchar](13) NULL,
	CONSTRAINT C_TelContact CHECK (telephone LIKE '([0-9][0-9][0-9])[0-9][0-9][0-9]-[0-9][0-9][0-9][0-9]'),
)
