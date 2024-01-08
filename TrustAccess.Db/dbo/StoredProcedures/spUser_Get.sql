CREATE PROCEDURE [dbo].[spUser_Get]
    @Id int
As
begin
    select * 
    from dbo.[Users]
    where Id = @Id; 
end