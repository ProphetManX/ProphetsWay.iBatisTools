CREATE TABLE [dbo].[Users] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [Name]      VARCHAR (MAX) NULL,
    [Whatever]  VARCHAR (MAX) NULL,
    [CompanyId] INT           NULL,
    [JobId]     INT           NULL,
    CONSTRAINT [FK_Users_Companies] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[Companies] ([Id]),
    CONSTRAINT [FK_Users_Jobs] FOREIGN KEY ([JobId]) REFERENCES [dbo].[Jobs] ([Id]), 
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id])
);

