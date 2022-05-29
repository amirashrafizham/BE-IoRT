using System.Threading.Tasks;
using BE_IoRT.Models;
using UnitsNet;

namespace BE_IoRT.Interfaces
{
    public interface IRobot
    {
        public Task<RobotBattery> GetBattery();
        public Task<RobotHead> MoveServoMotor(RobotHead client);
        public Task<RobotUltraSonic> Sense();
        public Task<RobotWheel> Forward(Speed speed, int time);
        public Task<RobotWheel> TurnRight(Speed speed, int time);
        public Task<RobotWheel> TurnLeft(Speed speed, int time);
        public Task<RobotWheel> Reverse(Speed speed, int time);
        public Task<RobotWheel> ReverseRight(Speed speed, int time);
        public Task<RobotWheel> ReverseLeft(Speed speed, int time);
    }
}