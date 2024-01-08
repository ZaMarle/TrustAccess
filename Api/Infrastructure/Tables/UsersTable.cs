namespace Api.Infrastructure.Tables
{
    public enum UsersTableDefinition
    {
        Id,
        Email,
        PasswordHash
    }

    public class UsersTableEntity
    {
        public int Id { get; set; }
        public string Email { get; set; } = "";
        public string PasswordHash { get; set; } = "";
    }
}