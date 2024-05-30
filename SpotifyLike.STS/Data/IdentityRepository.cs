using Dapper;
using Microsoft.Extensions.Options;
using SpotifyLike.STS.Model;
using System.Data.SqlClient;

namespace SpotifyLike.STS.Data
{
    public class IdentityRepository : IIdentityRepository
    {
        private readonly String connectionString;

        public IdentityRepository(IOptions<DatabaseOption> options)
        {
            this.connectionString = options.Value.StreamingConnection;
        }

        public async Task<Usuario> FindByIdAsync(Guid id)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var user = await connection.QueryFirstOrDefaultAsync<Usuario>(IdentityQuery.FindById(),
                    new
                    {
                        id = id
                    });

                return user;
            }
        }

        public async Task<Usuario> FindByEmailAndPasswordAsync(String email, String password)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var user = await connection.QueryFirstOrDefaultAsync<Usuario>(IdentityQuery.FindByEMailAndPassword(),
                    new
                    {
                        email = email,
                        senha = password
                    });

                return user;
            }
        }
    }

    public static class IdentityQuery
    {
        public static String FindById() =>
            @"SELECT Id, Nome, EMail FROM USUARIO WHERE Id = @id;";

        public static String FindByEMailAndPassword() =>
            @"SELECT Id, Nome, EMail FROM USUARIO WHERE EMail = @email AND Senha = @senha;";
    }
}
