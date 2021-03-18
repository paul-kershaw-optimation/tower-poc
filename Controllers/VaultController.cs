using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Azure.Security.KeyVault.Secrets;
using System;
using Azure.Identity;
using System.Threading.Tasks;

namespace tower.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VaultController : ControllerBase
    {
        private readonly ILogger<VaultController> _logger;

        public VaultController(ILogger<VaultController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var client = new SecretClient(new Uri("https://tower-poc-kv.vault.azure.net/"), new DefaultAzureCredential());

            var secret = await client.GetSecretAsync("TestSecret");

            return Ok(secret);
        }
    }
}
