CREATE PROCEDURE [dbo].[spUser_GetAll]
As
begin
    select * 
    from dbo.[Users]; 
end