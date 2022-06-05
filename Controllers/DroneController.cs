using BE_IoRT.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BE_IoRT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DroneController : ControllerBase
    {

        private readonly IDrone _drone;
        public DroneController(IDrone drone)
        {
            this._drone = drone;
        }

        [HttpGet("Connect")]
        public async Task<ActionResult<string>> Connect()
        {
            var result = await _drone.Connect();
            return Ok(result);
        }

        [HttpGet("TakeOff")]
        public async Task<ActionResult<string>> TakeOff()
        {
            var result = await _drone.TakeOff();
            return Ok(result);
        }

        [HttpGet("Land")]
        public async Task<ActionResult<string>> Land()
        {
            var result = await _drone.Land();
            return Ok(result);
        }

        [HttpGet("Battery")]
        public async Task<ActionResult<string>> GetBattery()
        {
            var result = await _drone.GetBattery();
            return Ok(result);
        }

        [HttpGet("Forward")]
        public async Task<ActionResult<string>> Forward()
        {
            var result = await _drone.Forward();
            return Ok(result);
        }

        [HttpGet("Reverse")]
        public async Task<ActionResult<string>> Reverse()
        {
            var result = await _drone.Reverse();
            return Ok(result);
        }

        [HttpGet("MoveUp")]
        public async Task<ActionResult<string>> MoveUp()
        {
            var result = await _drone.MoveUp();
            return Ok(result);
        }

        [HttpGet("MoveDown")]
        public async Task<ActionResult<string>> MoveDown()
        {
            var result = await _drone.MoveDown();
            return Ok(result);
        }

        [HttpGet("MoveLeft")]
        public async Task<ActionResult<string>> MoveLeft()
        {
            var result = await _drone.MoveLeft();
            return Ok(result);
        }

        [HttpGet("MoveRight")]
        public async Task<ActionResult<string>> MoveRight()
        {
            var result = await _drone.MoveRight();
            return Ok(result);
        }

        [HttpGet("TurnClockWise")]
        public async Task<ActionResult<string>> TurnCW()
        {
            var result = await _drone.TurnClockwise();
            return Ok(result);
        }

        [HttpGet("TurnCounterClockwise")]
        public async Task<ActionResult<string>> TurnCCW()
        {
            var result = await _drone.TurnCounterClockWise();
            return Ok(result);
        }
    }
}
