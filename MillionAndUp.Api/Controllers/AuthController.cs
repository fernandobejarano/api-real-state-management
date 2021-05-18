using Microsoft.AspNetCore.Mvc;
using MillionAndUp.Cross_Cutting.Auth;
using System;

namespace MillionAndUp.Api.Controllers
{
    [ApiController]
    public class AuthController : Controller
    {
        private readonly ITokenService _auth;

        public AuthController(ITokenService auth) => this._auth = auth;

        [Route("api/[controller]")]
        [HttpGet]
        public IActionResult Autorization()
        {
            try
            {
                return Ok(_auth.CreateToken());
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
