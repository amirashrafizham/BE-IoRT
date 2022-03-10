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

        [HttpPost("Forward")]
        public async Task<ActionResult<RobotWheel>> Forward(DistanceModel client)
        {
            Speed speed = Speed.FromCentimetersPerSecond(client.Speed);
            var time = client.Time * 1000;
            var result = await _robotWheel.Forward(speed, time);
            if (result == null)
            {
                return NotFound("Try again");
            }
            else
            {
                return Ok(result);
            }

        }
        [HttpPost("TurnRight")]
        public async Task<ActionResult<RobotWheel>> TurnRight(DistanceModel client)
        {
            Speed speed = Speed.FromCentimetersPerSecond(client.Speed);
            var time = client.Time * 1000;
            var result = await _robotWheel.TurnRight(speed, time);
            if (result == null)
            {
                return NotFound("Try again");
            }
            else
            {
                return Ok(result);
            }

        }
        [HttpPost("TurnLeft")]
        public async Task<ActionResult<RobotWheel>> TurnLeft(DistanceModel client)
        {
            Speed speed = Speed.FromCentimetersPerSecond(client.Speed);
            var time = client.Time * 1000;
            var result = await _robotWheel.TurnLeft(speed, time);
            if (result == null)
            {
                return NotFound("Try again");
            }
            else
            {
                return Ok(result);
            }

        }

        [HttpPost("Reverse")]
        public async Task<ActionResult<RobotWheel>> Reverse(DistanceModel client)
        {
            Speed speed = Speed.FromCentimetersPerSecond(client.Speed);
            var time = client.Time * 1000;
            var result = await _robotWheel.Reverse(speed, time);
            if (result == null)
            {
                return NotFound("Try again");
            }
            else
            {
                return Ok(result);
            }

        }

        [HttpPost("ReverseRight")]
        public async Task<ActionResult<RobotWheel>> ReverseRight(DistanceModel client)
        {
            Speed speed = Speed.FromCentimetersPerSecond(client.Speed);
            var time = client.Time * 1000;
            var result = await _robotWheel.ReverseRight(speed, time);
            if (result == null)
            {
                return NotFound("Try again");
            }
            else
            {
                return Ok(result);
            }

        }

        [HttpPost("ReverseLeft")]
        public async Task<ActionResult<RobotWheel>> ReverseLeft(DistanceModel client)
        {
            Speed speed = Speed.FromCentimetersPerSecond(client.Speed);
            var time = client.Time * 1000;
            var result = await _robotWheel.ReverseLeft(speed, time);
            if (result == null)
            {
                return NotFound("Try again");
            }
            else
            {
                return Ok(result);
            }

        }
    }
}