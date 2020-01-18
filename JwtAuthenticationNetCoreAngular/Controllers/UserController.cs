using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JwtAuthenticationNetCoreAngular.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthenticationNetCoreAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private AuthenticationContext _authenticationContext;
        private UserManager<ApplicationUser> _userManger;
        private SignInManager<ApplicationUser> _signInManager;
        public UserController(AuthenticationContext authenticatoncontext, UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _authenticationContext = authenticatoncontext;
            _signInManager = signInManager;
            _userManger = userManager;
        }
        // GET: api/Log
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Log/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Log
        [HttpPost("register")]
        public async Task<IActionResult> Post([FromBody] UserModel user)
        {
            var appUser = new ApplicationUser()
            {
                UserName = user.UserName,
                Email = user.Email,
                FullName = user.FullName
            };
          
            try
            {
                var result = await _userManger.CreateAsync(appUser, user.Password);
                return Ok(result);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        // PUT: api/Log/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
