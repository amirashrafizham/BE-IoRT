using System.Threading.Tasks;
using BE_IoRT.Interfaces;
using BE_IoRT.Models;
using Microsoft.AspNetCore.Mvc;
using UnitsNet;

namespace BE_IoRT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RobotBatteryController : ControllerBase
    {
        private readonly IRobotBattery _robotBattery;
        public RobotBatteryController(IRobotBattery robotBattery)
        {
            this._robotBattery = robotBattery;

        }
        [HttpGet]
        public async Task<ActionResult> GetBattery()
        {
            var result = await _robotBattery.GetBattery();
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