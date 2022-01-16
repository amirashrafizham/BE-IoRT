using System.Threading.Tasks;
using BE_IoRT.Models;
using Microsoft.AspNetCore.Mvc;

namespace BE_IoRT.Interfaces
{
    public interface IPiSenseHat
    {
        public Task<ActionResult<Weather>> GetWeather();
        public Task<ActionResult<Acceleration>> GetAcceleration();
        public Task<ActionResult<AngularRate>> GetAngularRate();
        public Task<ActionResult<MagneticInduction>> GetMagneticInduction();
    }
}