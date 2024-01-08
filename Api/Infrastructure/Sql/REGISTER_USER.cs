using Api.Infrastructure.Tables;

namespace Api.Application.Sql
{
    public class REGISTER_USER
    {
        public static readonly string value = $@"
            INSERT INTO Users ({UsersTableDefinition.Email}, {UsersTableDefinition.PasswordHash})
            VALUES (@Email, @PasswordHash);
        ";
    }
}
