CREATE TABLE [dbo].[UserGroups_Permissions]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [UserGroupId] INT NOT NULL, 
    [PermissionId] INT NOT NULL,
    CONSTRAINT [FK_UserGroups_Permissions_UserGroupId] FOREIGN KEY ([UserGroupId]) REFERENCES [UserGroups]([Id]),
    CONSTRAINT [FK_UserGroups_Permissions_PermissionId] FOREIGN KEY ([PermissionId]) REFERENCES [Permissions]([Id])
)
