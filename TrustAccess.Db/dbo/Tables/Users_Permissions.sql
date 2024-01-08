CREATE TABLE [dbo].[Users_Permissions]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [UserId] INT NOT NULL, 
    [PermissionId] INT NOT NULL,
    CONSTRAINT [FK_Users_Permissions_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users]([Id]),
    CONSTRAINT [FK_Users_Permissions_PermissionsId] FOREIGN KEY ([PermissionId]) REFERENCES [Permissions]([Id])
)
