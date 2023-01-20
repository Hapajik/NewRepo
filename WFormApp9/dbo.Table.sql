CREATE TABLE [dbo].[Table]
(
	[n_mast] INT NOT NULL PRIMARY KEY, 
    [fio] NVARCHAR(50) NULL, 
    [dolg] NVARCHAR(50) NULL 
	CONSTRAINT [<Без имени>] PRIMARY KEY CLUSTERED ([n_mast] ASC)
);
