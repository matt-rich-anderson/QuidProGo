USE [master]

IF db_id('QuidProGo') IS NULl
  CREATE DATABASE [QuidProGo]
GO

USE [QuidProGo]
GO


DROP TABLE IF EXISTS [UserProfile];
DROP TABLE IF EXISTS [UserType];
DROP TABLE IF EXISTS [Consultation];
DROP TABLE IF EXISTS [Category];
DROP TABLE IF EXISTS [ConsultationCategory];

GO

CREATE TABLE [UserProfile] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Name] nvarchar(255) NOT NULL,
  [Email] nvarchar(255) NOT NULL,
  [UserTypeId] int NOT NULL,
  [FirebaseUserId] nvarchar(255) NOT NULL
)
GO

CREATE TABLE [UserType] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [UserTypeName] nvarchar(255) NOT NULL
)
GO

CREATE TABLE [Consultation] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Title] nvarchar(255) NOT NULL,
  [Description] nvarchar(255) NOT NULL,
  [ClientUserId] int NOT NULL,
  [AttorneyUserId] int NOT NULL,
  [CreateDateTime] datetime NOT NULL
)
GO

CREATE TABLE [Category] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Category] nvarchar(255) NOT NULL
)
GO

CREATE TABLE [ConsultationCategory] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [ConsultationId] int NOT NULL,
  [CategoryId] int NOT NULL
)
GO

ALTER TABLE [Consultation] ADD FOREIGN KEY ([ClientUserId]) REFERENCES [UserProfile] ([Id])
GO

ALTER TABLE [Consultation] ADD FOREIGN KEY ([AttorneyUserId]) REFERENCES [UserProfile] ([Id])
GO

ALTER TABLE [ConsultationCategory] ADD FOREIGN KEY ([ConsultationId]) REFERENCES [Consultation] ([Id]) ON DELETE CASCADE
GO

ALTER TABLE [ConsultationCategory] ADD FOREIGN KEY ([CategoryId]) REFERENCES [Category] ([Id])
GO

ALTER TABLE [UserProfile] ADD FOREIGN KEY ([UserTypeId]) REFERENCES [UserType] ([Id])
GO

