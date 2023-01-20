CREATE TABLE [dbo].[Remont] (
    [Id]     INT          NOT NULL,
    [n_avto] INT          NULL,
    [n_usl]  INT          NULL,
    [n_mast] INT          NULL,
    [data]   DATE         NULL,
    [kol]    INT          NULL,
    [n_z_n]  INT          NULL,
    [sum]    NUMERIC (10, 2) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Remont_To_Master] FOREIGN KEY ([n_mast]) REFERENCES [dbo].[Master] ([n_mast]),
    CONSTRAINT [FK_Remont_To_Avto] FOREIGN KEY ([n_avto]) REFERENCES [dbo].[Avto] ([n_avto]),
    CONSTRAINT [FK_Remont_To_Uslugi] FOREIGN KEY ([n_usl]) REFERENCES [dbo].[Uslugi] ([n_usl])
);

