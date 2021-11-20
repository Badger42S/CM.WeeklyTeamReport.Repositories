CREATE TABLE [dbo].[WeeklyReports] (
    [WeeklyReportId] INT           IDENTITY (1, 1) NOT NULL,
    [DateStart]      INT           NOT NULL,
    [Duration]       FLOAT (53)    NOT NULL,
    [Task]           NVARCHAR (50) NOT NULL,
    CONSTRAINT [WeeklyReport_Id] PRIMARY KEY CLUSTERED ([WeeklyReportId] ASC)
);

