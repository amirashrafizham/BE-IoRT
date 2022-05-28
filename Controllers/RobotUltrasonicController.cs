using System.Threading.Tasks;
using BE_IoRT.Interfaces;
using BE_IoRT.Models;
using Microsoft.AspNetCore.Mvc;
using UnitsNet;

namespace BE_IoRT.Controllers
{
    public class RobotUltrasonicController : ControllerBase
    {
        private readonly IRobotUltrasonic _robotUltrasonic;

        public RobotUltrasonicController(IRobotUltrasonic robotUltrasonic)
        {
            this._robotUltrasonic = robotUltrasonic;
        }
        [HttpGet("Ultrasonic")]
        public async Task<ActionResult<RobotUltraSonic>> GetSensor()
        {
            var result = await _robotUltrasonic.Sense();
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