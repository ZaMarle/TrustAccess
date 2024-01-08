CREATE TABLE [dbo].[Users_UserGroups]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [UserId] INT NOT NULL, 
    [UserGroupId] INT NOT NULL, 
    CONSTRAINT [FK_Users_UserGroups_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users]([Id]),
    CONSTRAINT [FK_Users_UserGroups_UserGroupId] FOREIGN KEY ([UserGroupId]) REFERENCES [UserGroups]([Id])
)
