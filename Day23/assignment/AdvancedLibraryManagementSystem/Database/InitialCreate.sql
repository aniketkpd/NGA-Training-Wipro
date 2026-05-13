IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
CREATE TABLE [Authors] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(120) NOT NULL,
    [Bio] nvarchar(1000) NULL,
    CONSTRAINT [PK_Authors] PRIMARY KEY ([Id])
);

CREATE TABLE [Genres] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(80) NOT NULL,
    CONSTRAINT [PK_Genres] PRIMARY KEY ([Id])
);

CREATE TABLE [Books] (
    [Id] int NOT NULL IDENTITY,
    [Title] nvarchar(200) NOT NULL,
    [Isbn] nvarchar(20) NULL,
    [PublishedYear] int NOT NULL,
    [AuthorId] int NOT NULL,
    CONSTRAINT [PK_Books] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Books_Authors_AuthorId] FOREIGN KEY ([AuthorId]) REFERENCES [Authors] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [BookGenres] (
    [BookId] int NOT NULL,
    [GenreId] int NOT NULL,
    CONSTRAINT [PK_BookGenres] PRIMARY KEY ([BookId], [GenreId]),
    CONSTRAINT [FK_BookGenres_Books_BookId] FOREIGN KEY ([BookId]) REFERENCES [Books] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_BookGenres_Genres_GenreId] FOREIGN KEY ([GenreId]) REFERENCES [Genres] ([Id]) ON DELETE CASCADE
);

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Bio', N'Name') AND [object_id] = OBJECT_ID(N'[Authors]'))
    SET IDENTITY_INSERT [Authors] ON;
INSERT INTO [Authors] ([Id], [Bio], [Name])
VALUES (1, N'English novelist and essayist.', N'George Orwell'),
(2, N'British author.', N'J. K. Rowling');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Bio', N'Name') AND [object_id] = OBJECT_ID(N'[Authors]'))
    SET IDENTITY_INSERT [Authors] OFF;

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Genres]'))
    SET IDENTITY_INSERT [Genres] ON;
INSERT INTO [Genres] ([Id], [Name])
VALUES (1, N'Dystopian'),
(2, N'Fantasy'),
(3, N'Classic');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Genres]'))
    SET IDENTITY_INSERT [Genres] OFF;

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AuthorId', N'Isbn', N'PublishedYear', N'Title') AND [object_id] = OBJECT_ID(N'[Books]'))
    SET IDENTITY_INSERT [Books] ON;
INSERT INTO [Books] ([Id], [AuthorId], [Isbn], [PublishedYear], [Title])
VALUES (1, 1, N'9780451524935', 1949, N'1984'),
(2, 2, N'9780747532699', 1997, N'Harry Potter and the Philosopher''s Stone');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AuthorId', N'Isbn', N'PublishedYear', N'Title') AND [object_id] = OBJECT_ID(N'[Books]'))
    SET IDENTITY_INSERT [Books] OFF;

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'BookId', N'GenreId') AND [object_id] = OBJECT_ID(N'[BookGenres]'))
    SET IDENTITY_INSERT [BookGenres] ON;
INSERT INTO [BookGenres] ([BookId], [GenreId])
VALUES (1, 1),
(1, 3),
(2, 2);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'BookId', N'GenreId') AND [object_id] = OBJECT_ID(N'[BookGenres]'))
    SET IDENTITY_INSERT [BookGenres] OFF;

CREATE UNIQUE INDEX [IX_Authors_Name] ON [Authors] ([Name]);

CREATE INDEX [IX_BookGenres_GenreId] ON [BookGenres] ([GenreId]);

CREATE INDEX [IX_Books_AuthorId] ON [Books] ([AuthorId]);

CREATE INDEX [IX_Books_Title] ON [Books] ([Title]);

CREATE UNIQUE INDEX [IX_Genres_Name] ON [Genres] ([Name]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260513093927_InitialCreate', N'10.0.8');

COMMIT;
GO

