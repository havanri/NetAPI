using EFCoreExam.DTOs.Account;
using EFCoreExam.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreExam.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository accountRepo;
        public AccountController(IAccountRepository accountRepository)
        {
            this.accountRepo = accountRepository;
        }
        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp([FromBody] SignUpModel model)
        {
            var result = await accountRepo.SignUpSync(model);
            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }
            return Unauthorized();
        }
        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromBody] SignInModel model)
        {
            var result = await accountRepo.SignInAsync(model);
            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized();
            }
            return Ok(result);
        }
    }
}
