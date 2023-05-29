drop table ProductTbl;

CREATE TABLE [dbo].[ProductTbl] (
    [PrId]      INT           IDENTITY (100, 1) NOT NULL,
    [PrName]    VARCHAR (100) NOT NULL,
    [PrPrice]   INT           NOT NULL,
    [PrQty]     INT           NOT NULL,
    [PrExpDate] DATE          NOT NULL,
    [FarmId]    INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([PrId] ASC),
    FOREIGN KEY ([FarmId]) REFERENCES [dbo].[FarmerTbl]([FarmId])
);

CREATE TABLE [dbo].[FarmerTbl] (
    [FarmId]             INT           IDENTITY (100, 1) NOT NULL,
    [FarmName]           VARCHAR (100) NOT NULL,
    [FarmSurname]        VARCHAR (100) NOT NULL,
    [FarmEmail]          VARCHAR (100) NOT NULL,
    [FarmPassword]       VARCHAR (100) NOT NULL,
    [ContactInformation] VARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([FarmId] ASC)
);