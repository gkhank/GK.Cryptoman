using Binance.Net.Objects.Models.Spot;
using GK.Cryptoman.Utilities.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GK.Cryptoman.Hub.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AccountRepository : BaseController
    {
        private readonly ILogger<AccountRepository> _logger;
        private readonly IAccountRepository _accountRepository;

        public AccountRepository(
            ILogger<AccountRepository> logger,
            IAccountRepository spotRepository)
        {
            _logger = logger;
            _accountRepository = spotRepository;
        }

        [HttpGet]
        public async Task<BinanceAccountInfo> GetAccountInfo(CancellationToken token)
        {
            _logger.LogInformation($"Logger works in Get");
            return await _accountRepository.GetAccountInfo(token);
        }
    }
}