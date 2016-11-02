
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/02/2016 23:09:23
-- Generated from EDMX file: C:\Users\Lucato\Documents\Visual Studio 2013\Projects\Biblioteka\Biblioteka\Models\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MVC];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_AccountRent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RentSet] DROP CONSTRAINT [FK_AccountRent];
GO
IF OBJECT_ID(N'[dbo].[FK_BookRent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RentSet] DROP CONSTRAINT [FK_BookRent];
GO
IF OBJECT_ID(N'[dbo].[FK_BookTag]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TagSet] DROP CONSTRAINT [FK_BookTag];
GO
IF OBJECT_ID(N'[dbo].[FK_RentRentHistory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RentSet] DROP CONSTRAINT [FK_RentRentHistory];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AccountSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AccountSet];
GO
IF OBJECT_ID(N'[dbo].[BookSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BookSet];
GO
IF OBJECT_ID(N'[dbo].[RentHistorySet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RentHistorySet];
GO
IF OBJECT_ID(N'[dbo].[RentSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RentSet];
GO
IF OBJECT_ID(N'[dbo].[TagSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TagSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'BookSet'
CREATE TABLE [dbo].[BookSet] (
    [IdBook] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Author] nvarchar(max)  NOT NULL,
    [ISBN] nvarchar(max)  NOT NULL,
    [Category] nvarchar(max)  NOT NULL,
    [State] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'TagSet'
CREATE TABLE [dbo].[TagSet] (
    [IdTag] int IDENTITY(1,1) NOT NULL,
    [BookIdBook] int  NOT NULL,
    [TagName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'AccountSet'
CREATE TABLE [dbo].[AccountSet] (
    [IdAcount] int IDENTITY(1,1) NOT NULL,
    [Login] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Permission] nvarchar(max)  NOT NULL,
    [Mail] nvarchar(max)  NOT NULL,
    [Question] nvarchar(max)  NOT NULL,
    [Answer] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Surname] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'RentSet'
CREATE TABLE [dbo].[RentSet] (
    [IdRent] int IDENTITY(1,1) NOT NULL,
    [RentDate] nvarchar(max)  NOT NULL,
    [BookIdBook] int  NOT NULL,
    [AccountIdAcount] int  NOT NULL,
    [RentHistory_IdRentHistory] int  NOT NULL
);
GO

-- Creating table 'RentHistorySet'
CREATE TABLE [dbo].[RentHistorySet] (
    [IdRentHistory] int IDENTITY(1,1) NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IdBook] in table 'BookSet'
ALTER TABLE [dbo].[BookSet]
ADD CONSTRAINT [PK_BookSet]
    PRIMARY KEY CLUSTERED ([IdBook] ASC);
GO

-- Creating primary key on [IdTag] in table 'TagSet'
ALTER TABLE [dbo].[TagSet]
ADD CONSTRAINT [PK_TagSet]
    PRIMARY KEY CLUSTERED ([IdTag] ASC);
GO

-- Creating primary key on [IdAcount] in table 'AccountSet'
ALTER TABLE [dbo].[AccountSet]
ADD CONSTRAINT [PK_AccountSet]
    PRIMARY KEY CLUSTERED ([IdAcount] ASC);
GO

-- Creating primary key on [IdRent] in table 'RentSet'
ALTER TABLE [dbo].[RentSet]
ADD CONSTRAINT [PK_RentSet]
    PRIMARY KEY CLUSTERED ([IdRent] ASC);
GO

-- Creating primary key on [IdRentHistory] in table 'RentHistorySet'
ALTER TABLE [dbo].[RentHistorySet]
ADD CONSTRAINT [PK_RentHistorySet]
    PRIMARY KEY CLUSTERED ([IdRentHistory] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [BookIdBook] in table 'TagSet'
ALTER TABLE [dbo].[TagSet]
ADD CONSTRAINT [FK_BookTag]
    FOREIGN KEY ([BookIdBook])
    REFERENCES [dbo].[BookSet]
        ([IdBook])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BookTag'
CREATE INDEX [IX_FK_BookTag]
ON [dbo].[TagSet]
    ([BookIdBook]);
GO

-- Creating foreign key on [BookIdBook] in table 'RentSet'
ALTER TABLE [dbo].[RentSet]
ADD CONSTRAINT [FK_BookRent]
    FOREIGN KEY ([BookIdBook])
    REFERENCES [dbo].[BookSet]
        ([IdBook])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BookRent'
CREATE INDEX [IX_FK_BookRent]
ON [dbo].[RentSet]
    ([BookIdBook]);
GO

-- Creating foreign key on [AccountIdAcount] in table 'RentSet'
ALTER TABLE [dbo].[RentSet]
ADD CONSTRAINT [FK_AccountRent]
    FOREIGN KEY ([AccountIdAcount])
    REFERENCES [dbo].[AccountSet]
        ([IdAcount])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AccountRent'
CREATE INDEX [IX_FK_AccountRent]
ON [dbo].[RentSet]
    ([AccountIdAcount]);
GO

-- Creating foreign key on [RentHistory_IdRentHistory] in table 'RentSet'
ALTER TABLE [dbo].[RentSet]
ADD CONSTRAINT [FK_RentRentHistory]
    FOREIGN KEY ([RentHistory_IdRentHistory])
    REFERENCES [dbo].[RentHistorySet]
        ([IdRentHistory])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RentRentHistory'
CREATE INDEX [IX_FK_RentRentHistory]
ON [dbo].[RentSet]
    ([RentHistory_IdRentHistory]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------