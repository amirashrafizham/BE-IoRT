using System;
using System.Threading.Tasks;
using BE_IoRT.Models;
using BE_IoRT.Services;
using Iot.Device.SenseHat;
using Microsoft.AspNetCore.Mvc;

namespace BE_IoRT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PiSenseHatController : ControllerBase
    {
        private readonly IPiSenseHat _piSenseHat;

        public PiSenseHatController(IPiSenseHat piSenseHat)
        {
            _piSenseHat = piSenseHat;
        }
        [HttpGet("GetWeather")]
        public async Task<ActionResult<Weather>> GetWeather()
        {
            var result = await _piSenseHat.GetWeather();
            if (result == null)
            {
                return NotFound("Try again");
            }
            else
            {
                return Ok(result.Value);
            }

        }

        [HttpGet("GetAcceleration")]
        public async Task<ActionResult<Acceleration>> GetAcceleration()
        {

            var result = await _piSenseHat.GetAcceleration();
            if (result == null)
            {
                return NotFound("Try again");
            }
            else
            {
                return Ok(result.Value);
            }
        }

        [HttpGet("GetAngularRate")]
        public async Task<ActionResult<AngularRate>> GetAngularRate()
        {

            var result = await _piSenseHat.GetAngularRate();
            if (result == null)
            {
                return NotFound("Try again");
            }
            else
            {
                return Ok(result.Value);
            }
        }

        [HttpGet("GetMagneticInduction")]
        public async Task<ActionResult<MagneticInduction>> GetMagneticInduction()
        {

            var result = await _piSenseHat.GetMagneticInduction();
            if (result == null)
            {
                return NotFound("Try again");
            }
            else
            {
                return Ok(result.Value);
            }
        }


    }
}