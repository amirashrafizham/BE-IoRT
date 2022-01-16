using System.Threading.Tasks;
using BE_IoRT.Models;
using Microsoft.AspNetCore.Mvc;
using UnitsNet;

namespace BE_IoRT.Interfaces
{
    public interface IRobotWheel
    {
        public Task<ActionResult<RobotWheel>> Forward(Speed speed, int time);
        public Task<ActionResult<RobotWheel>> TurnRight(Speed speed, int time);
        public Task<ActionResult<RobotWheel>> TurnLeft(Speed speed, int time);
        public Task<ActionResult<RobotWheel>> Reverse(Speed speed, int time);
        public Task<ActionResult<RobotWheel>> ReverseRight(Speed speed, int time);
        public Task<ActionResult<RobotWheel>> ReverseLeft(Speed speed, int time);
    }
}