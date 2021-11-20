CREATE TABLE [dbo].[Teams] (
    [Id]           INT IDENTITY (1, 1) NOT NULL,
    [TeamNumber]   INT NOT NULL,
    [TeamMember]   INT NOT NULL,
    [WeeklyReport] INT NOT NULL,
    CONSTRAINT [Id] PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([TeamMember]) REFERENCES [dbo].[TeamMembers] ([TeamMemberId]),
    FOREIGN KEY ([WeeklyReport]) REFERENCES [dbo].[WeeklyReports] ([WeeklyReportId])
);

