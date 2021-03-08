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
    public class VehicleService:IVehicleService
    {
        readonly private IRepoWrapper _repoWrapper;
        readonly private AppSettings _appSettings;
        public VehicleService(IOptions<AppSettings> appSettings,IRepoWrapper repoWrapper)
        {
            _appSettings = appSettings.Value;
            _repoWrapper = repoWrapper;
        }
        public async Task<IEnumerable<Vehicle>> GetAllVehicleAsync()
        {
            return await _repoWrapper.VehicleRepo.GetAllAsync();
        }
        public async Task<Vehicle> GetByIdAsync(int vehicleId)
        {
            return await _repoWrapper.VehicleRepo.GetByIdAsync(vehicleId);
        }
        public async Task<Vehicle> GetByRegnumAsync(string reg)
        {
            return await _repoWrapper.VehicleRepo.GetByRegNumAsync(reg);
        }
        public async Task<IEnumerable<Vehicle>> GetAllByModelAsync(string model)
        {
            return await _repoWrapper.VehicleRepo.GetAllByModelAsync(model);
        }
        public async Task RegisterVehicle(Vehicle vehicle)
        {
            _repoWrapper.VehicleRepo.Create(vehicle);
            await _repoWrapper.SaveAsync();
        }
        public async Task<IEnumerable<Vehicle>> GetAllByPageAsync(int page)
        {
            return await _repoWrapper.VehicleRepo.GetAllByPageAsync(page);
        }
        public async Task<Vehicle> Authenticate(string reg, string password)
        {
            var vehicle = await _repoWrapper.VehicleRepo.Authenticate(reg, password);
            // return null if user not found
            if (vehicle == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, vehicle.RegNum.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var vehicleLogin = new VehicleLogin();
            vehicleLogin.VehicleId = vehicle.Id;
            vehicleLogin.Token = tokenHandler.WriteToken(token);
            vehicleLogin.CreationDT = DateTime.Now;
            _repoWrapper.VehicleLoginRepo.Create(vehicleLogin);
            await _repoWrapper.SaveAsync();

            // remove password before returning
            vehicle.Password = null;

            return vehicle;
        }
    }
}
