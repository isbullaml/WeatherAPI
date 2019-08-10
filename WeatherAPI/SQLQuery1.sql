

CREATE TABLE [dbo].[Device] (
    [Id]          INT IdENTITY (1, 1) NOT NULL,
    [Location_Id] INT NOT NULL,
    [Type]        INT NOT NULL,
    CONSTRAINT [PK_Device] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Device_Location] FOREIGN KEY ([Location_Id]) REFERENCES [dbo].[Location] ([Id])
);

CREATE TABLE [dbo].[Location] (
    [Id]      INT           IdENTITY (1, 1) NOT NULL,
    [City]    VARCHAR (100) NOT NULL,
    [Area]    VARCHAR (100) NOT NULL,
    [Country] VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Weather_Data] (
    [Id]         INT           IdENTITY (1, 1) NOT NULL,
    [Device_Id]  INT           NOT NULL,
	[Time_Stamp] TimeStamp    NOT NULL,
    [Data]       VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_WEATHER_DATA] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_WEATHER_DATA_Device] FOREIGN KEY ([Device_Id]) REFERENCES [dbo].[Device] ([Id])
);

