using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using VehicleData.Models;
using VehicleData.Repositories.Wrapper;
using VehicleServices.Helpers;
using VehicleServices.Interfaces;

namespace VehicleServices.Implementation
{
    public class UserService:IUserService
    {
        readonly private AppSettings _appSettings;
        readonly private IRepoWrapper _repoWrapper;
        public UserService(IOptions<AppSettings> appSettings, IRepoWrapper repoWrapper)
        {
            _appSettings = appSettings.Value;
            _repoWrapper = repoWrapper;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _repoWrapper.UserRepo.GetAllAsync();
        }

        public async Task<User> Authenticate(string email, string password)
        {
            var user = await _repoWrapper.UserRepo.Authenticate(email, password);
            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Email.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var userLogin = new UserLogin();
            userLogin.UserId = user.Id;
            userLogin.Token = tokenHandler.WriteToken(token);
            userLogin.CreationDT = DateTime.Now;
            _repoWrapper.UserLoginRepo.Create(userLogin);
            await _repoWrapper.SaveAsync();
            //user.Token = tokenHandler.WriteToken(token);

            // remove password before returning
            user.Password = null;

            return user;
        }
    }
}
