CREATE TABLE [dbo].[TeamMembers] (
    [TeamMemberId] INT           IDENTITY (1, 1) NOT NULL,
    [CompanyId]    INT           NOT NULL,
    [FirstName]    NVARCHAR (50) NOT NULL,
    [LastName]     NVARCHAR (50) NOT NULL,
    [Role]         INT           NOT NULL,
    CONSTRAINT [TeamMember_Id] PRIMARY KEY CLUSTERED ([TeamMemberId] ASC),
    FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[Companies] ([CompanyId]),
    FOREIGN KEY ([Role]) REFERENCES [dbo].[Roles] ([RoleId])
);

