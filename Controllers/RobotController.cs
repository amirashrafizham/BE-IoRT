using System.Threading.Tasks;
using BE_IoRT.Interfaces;
using BE_IoRT.Models;
using Microsoft.AspNetCore.Mvc;
using UnitsNet;

namespace BE_IoRT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RobotController : ControllerBase
    {
        private readonly IRobot _robot;

        public RobotController(IRobot robot)
        {
            this._robot = robot;
        }

        [HttpGet("Battery")]
        public async Task<ActionResult> GetBattery()
        {
            var result = await _robot.GetBattery();
            if (result == null)
            {
                return NotFound("Try again");
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpPost("Head")]
        public async Task<ActionResult> MoveHead(RobotHead client)
        {
            var result = await _robot.MoveServoMotor(client);
            if (result == null)
            {
                return NotFound("Try again");
            }
            else
            {
                return Ok(result);
            }

        }

        [HttpGet("Ultrasonic")]
        public async Task<ActionResult<RobotUltraSonic>> GetSensor()
        {
            var result = await _robot.Sense();
            if (result == null)
            {
                return NotFound("Try again");
            }
            else
            {
                return Ok(result);
            }

        }

        [HttpPost("Forward")]
        public async Task<ActionResult<RobotWheel>> Forward(DistanceModel client)
        {
            Speed speed = Speed.FromCentimetersPerSecond(client.Speed);
            var time = client.Time * 1000;
            var result = await _robot.Forward(speed, time);
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
            var result = await _robot.TurnRight(speed, time);
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
            var result = await _robot.TurnLeft(speed, time);
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
            var result = await _robot.Reverse(speed, time);
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
            var result = await _robot.ReverseRight(speed, time);
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
            var result = await _robot.ReverseLeft(speed, time);
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