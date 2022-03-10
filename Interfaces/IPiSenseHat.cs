using System.Threading.Tasks;
using BE_IoRT.Models;
using Microsoft.AspNetCore.Mvc;

namespace BE_IoRT.Interfaces
{
    public interface IPiSenseHat
    {
        public Task<Weather> GetWeather();
        public Task<Acceleration> GetAcceleration();
        public Task<AngularRate> GetAngularRate();
        public Task<MagneticInduction> GetMagneticInduction();
    }
}