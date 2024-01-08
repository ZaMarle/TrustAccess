using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Infrastructure.Tables;

namespace Api.Infrastructure.Sql
{
    public class GET_ALL_USERS
    {
        public static readonly string value = $@"
            SELECT 
                {UsersTableDefinition.Id},
                {UsersTableDefinition.Email}
            FROM users
        ";
        
    }
}
