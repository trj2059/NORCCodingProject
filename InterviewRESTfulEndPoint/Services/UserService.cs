using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace InterviewRESTfulEndPoint.Services
{
    public interface IUserService
    {
        bool IsValidBasicAuthUser(string userName, string password);
    }

    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        // inject database for user validation
        public UserService(ILogger<UserService> logger)
        {
            _logger = logger;
        }

        public bool IsValidBasicAuthUser(string userName, string password)
        {
            _logger.LogInformation("Validating user {userName}", userName);
            if (string.IsNullOrWhiteSpace(userName))
            {
                _logger.LogInformation("Username is null or whitespace");
                return false;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                _logger.LogInformation("Password is null or whitespace");
                return false;
            }

            if (userName == "admin" && password == "1D6D06878ECEA9FC4FD2CECEFDA646A54A56682AF95E8C5F2E964A235DA0E2E7")
            {
                _logger.LogInformation("Username and password are correct");
                return true;
            }
            else
            {
                _logger.LogWarning("Username and password failed username:{userName}, password:{password}", userName, password);
                return false;
            }
        }
    }
}
