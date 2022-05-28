using System.Threading.Tasks;
using BE_IoRT.Interfaces;
using BE_IoRT.Models;
using Microsoft.AspNetCore.Mvc;
using UnitsNet;

namespace BE_IoRT.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class RobotHeadController : ControllerBase
    {
        private readonly IRobotHead _robotHead;

        public RobotHeadController(IRobotHead robotHead)
        {
            _robotHead = robotHead;
        }

        [HttpPost("Head")]
        public async Task<ActionResult> Forward(RobotHead client)
        {
            var result = await _robotHead.MoveServoMotor(client);
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