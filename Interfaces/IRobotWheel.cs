using System.Threading.Tasks;
using BE_IoRT.Models;
using Microsoft.AspNetCore.Mvc;
using UnitsNet;

namespace BE_IoRT.Interfaces
{
    public interface IRobotWheel
    {
        public Task<RobotWheel> Forward(Speed speed, int time);
        public Task<RobotWheel> TurnRight(Speed speed, int time);
        public Task<RobotWheel> TurnLeft(Speed speed, int time);
        public Task<RobotWheel> Reverse(Speed speed, int time);
        public Task<RobotWheel> ReverseRight(Speed speed, int time);
        public Task<RobotWheel> ReverseLeft(Speed speed, int time);
    }
}