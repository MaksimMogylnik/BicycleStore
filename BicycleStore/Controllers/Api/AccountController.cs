using BicycleStore.Config;
using BicycleStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BicycleStore.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AccountController : Controller
    {
        private Person person = new Person { Email = "mail@mail.com", Password = "admin"};
        private readonly SignInManager<User> signInManager;

        public AccountController(SignInManager<User> signInManager)
        {
            this.signInManager = signInManager;
        }

        [HttpPost]
        public IActionResult Token([FromBody] Person p)
        {
            var identity = GetIdentity(p.Email, p.Password);
            if (identity == null)
            {
                return BadRequest(new { error = "Invalid login or password" });
            }

            var now = DateTime.Now;
            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                notBefore: now,
                claims: identity.Result.Claims,
                expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)
            );

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = identity.Result.Name
            };

            return Json(response);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        private async Task<ClaimsIdentity> GetIdentity(string email, string password)
        {

            var result = await signInManager.PasswordSignInAsync(email, password, false, false);

            if (result.Succeeded)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.Email),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, person.Password)
                };

                ClaimsIdentity claimsIdentity =
                    new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

                return claimsIdentity;
            }

            return null;
        }
    }
}
