CREATE TABLE [dbo].[Companies] (
    [CompanyId]   INT            IDENTITY (1, 1) NOT NULL,
    [CompanyName] NVARCHAR (100) NOT NULL,
    [Country]     NVARCHAR (50)  NOT NULL,
    [City]        NVARCHAR (50)  NOT NULL,
    [President]   NVARCHAR (100) NULL,
    CONSTRAINT [Company_Id] PRIMARY KEY CLUSTERED ([CompanyId] ASC)
);

