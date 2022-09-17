using Application.Common.Interfaces;
using Application.Common.Models;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly string key;
        private readonly IClaimService _claimService;
        public TokenService(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, IConfiguration configuration, IClaimService claimService)
        {
            _userManager = userManager;
            key = configuration.GetSection("JwtKey").Value;
            _roleManager = roleManager;
            _claimService = claimService;
        }


        public async Task<TokenObJ> DoAuthenticate(ApplicationUser user)
        {


            List<Claim>? claims = await _claimService.GetValidClaims(user);
            string token = GenerateAccessToken(claims, 1 * 60 * 24);
            string? newRefreshToken = await _userManager.GenerateUserTokenAsync(user, "Default", "RefreshToken");


            return new TokenObJ
            {
                Token = token,
                RefreshTokenKey = newRefreshToken,
                Id = user.Id,

                TokenExpirationTime = ((DateTimeOffset)DateTime.Now.ToUniversalTime().AddMinutes(1 * 60 * 24)).ToUnixTimeSeconds(),
            };
        }
        public string GenerateAccessToken(List<Claim> claims, int mins)
        {
            SymmetricSecurityKey? secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            SigningCredentials? signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            DateTime expires = DateTime.Now.ToUniversalTime().AddMinutes(mins);
            claims.Add(new Claim(ClaimTypes.Expired, expires.ToString()));
            JwtSecurityToken? tokeOptions = new JwtSecurityToken(

                claims: claims,
                expires: expires,
                signingCredentials: signinCredentials
            );

            string? tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return tokenString;
        }


    }
}
