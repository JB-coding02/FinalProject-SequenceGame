USE master;
GO

DROP DATABASE IF EXISTS SequenceGameDB;
GO

Create Database SequenceGameDB;

GO
USE SequenceGameDB;
GO

CREATE TABLE [dbo].[CardData] (
[CardIdentity] VARCHAR (3) NOT NULL,
PRIMARY KEY CLUSTERED ([CardIdentity] ASC)
);

CREATE TABLE [dbo].[GameData] (
[GameID] INT IDENTITY (1, 1) NOT NULL,
[GameStartTime] DATETIME2 (7) NOT NULL,
[GameEndTime] DATETIME2 (7) NOT NULL,
[GameDuration] DATETIME2 (7) NOT NULL,
[CardsPerPlayer] INT NOT NULL,
[TotalTeams] INT NOT NULL,
[TeamId] INT NOT NULL,
[WinningTeamId] INT NULL,
PRIMARY KEY CLUSTERED ([GameID] ASC)
);

CREATE TABLE [dbo].[GameDeckCards] (
[GameID] INT NOT NULL,
[CardIdentity] VARCHAR (3) NOT NULL,
PRIMARY KEY CLUSTERED ([GameID] ASC, [CardIdentity] ASC),
FOREIGN KEY ([GameID]) REFERENCES [dbo].[GameData] ([GameID]),
FOREIGN KEY ([CardIdentity]) REFERENCES [dbo].[CardData] ([CardIdentity])
);

CREATE TABLE [dbo].[GameDiscardedCards] (
[GameID] INT NOT NULL,
[CardIdentity] VARCHAR (3) NOT NULL,
PRIMARY KEY CLUSTERED ([GameID] ASC, [CardIdentity] ASC),
FOREIGN KEY ([GameID]) REFERENCES [dbo].[GameData] ([GameID]),
FOREIGN KEY ([CardIdentity]) REFERENCES [dbo].[CardData] ([CardIdentity])
);

CREATE TABLE [dbo].[TeamData] (
[TeamID] INT IDENTITY (1, 1) NOT NULL,
[TeamName] NVARCHAR (100) NOT NULL,
PRIMARY KEY CLUSTERED ([TeamID] ASC)
);

CREATE TABLE [dbo].[GameParticipatingTeams] (
[GameID] INT NOT NULL,
[TeamID] INT NOT NULL,
PRIMARY KEY CLUSTERED ([GameID] ASC, [TeamID] ASC),
FOREIGN KEY ([GameID]) REFERENCES [dbo].[GameData] ([GameID]),
FOREIGN KEY ([TeamID]) REFERENCES [dbo].[TeamData] ([TeamID])
);

CREATE TABLE [dbo].[PlayerData] (
[PlayerID] INT IDENTITY (1, 1) NOT NULL,
[Username] NVARCHAR (100) NOT NULL,
PRIMARY KEY CLUSTERED ([PlayerID] ASC)
);

CREATE TABLE [dbo].[GamePlayers] (
[GameID] INT NOT NULL,
[PlayerID] INT NOT NULL,
PRIMARY KEY CLUSTERED ([GameID] ASC, [PlayerID] ASC),
FOREIGN KEY ([GameID]) REFERENCES [dbo].[GameData] ([GameID]),
FOREIGN KEY ([PlayerID]) REFERENCES [dbo].[PlayerData] ([PlayerID])
);

CREATE TABLE [dbo].[Teams] (
[TeamID] INT IDENTITY (1, 1) NOT NULL,
[TeamName] NVARCHAR (100) NOT NULL,
PRIMARY KEY CLUSTERED ([TeamID] ASC)
);