using System.Threading.Tasks;
using BE_IoRT.Interfaces;
using BE_IoRT.Models;
using Microsoft.AspNetCore.Mvc;
using UnitsNet;

namespace BE_IoRT.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class RobotWheelController : ControllerBase
    {
        private readonly IRobotWheel _robotWheel;

        public RobotWheelController(IRobotWheel robotWheel)
        {
            _robotWheel = robotWheel;
        }

        [HttpGet("Forward")]
        public async Task<ActionResult<RobotWheel>> Forward(int speedInt, int time)
        {
            Speed speed = Speed.FromCentimetersPerSecond(speedInt);
            var result = await _robotWheel.Forward(speed, time);
            if (result == null)
            {
                return NotFound("Try again");
            }
            else
            {
                return Ok(result.Value);
            }

        }

        [HttpGet("Reverse")]
        public async Task<ActionResult<RobotWheel>> Reverse(int speedInt, int time)
        {
            Speed speed = Speed.FromCentimetersPerSecond(speedInt);
            var result = await _robotWheel.Forward(speed, time);
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