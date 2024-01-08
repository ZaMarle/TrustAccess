using System.Data;
using Api.Helper;
using Dapper;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;

namespace Api.Infrastructure.Shared
{
    public interface ITrustAccessDb
    {
        Task<IEnumerable<TResult>> LoadData<TInput, TResult>(
            string SqlExpression, 
            TInput parameters);
        
        Task<Result<Unit>> SaveData<T>(
            string SqlExpression, 
            T parameters);
    }

    public class TrustAccessDb : ITrustAccessDb
    {
        private readonly IConfiguration _config;
        private readonly ILogger<TrustAccessDb> _logger;

        public TrustAccessDb(
            IConfiguration config,
            ILogger<TrustAccessDb> logger)
        {
            _config = config;
            _logger = logger;
        }

        public async Task<IEnumerable<TResult>> LoadData<TInput, TResult>(
            string SqlExpression, 
            TInput parameters)
        {
            using IDbConnection connection = new SqlConnection(AppSettings.ConnectionStrings.DefaultConnection);

            try
            {
                return await connection.QueryAsync<TResult>(
                    SqlExpression,
                    parameters,
                    commandType: CommandType.Text);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<Result<Unit>> SaveData<T>(
            string SqlExpression, 
            T parameters)
        {
            _logger.LogInformation("TrustAccessDb - SaveData");
            using IDbConnection connection = new SqlConnection(AppSettings.ConnectionStrings.DefaultConnection);

            try
            {
                var res = await connection.ExecuteAsync(
                    SqlExpression,
                    parameters,
                    commandType: CommandType.Text);

                _logger.LogInformation("SaveData - success");
                return Result<Unit>.Ok(Unit.New);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                _logger.LogInformation(ex.StackTrace);
                _logger.LogInformation(ex.Source);
                return Result<Unit>.Err(ex.Message);
            }
        }
    }
}