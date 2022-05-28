using System.Threading.Tasks;
using BE_IoRT.Interfaces;
using BE_IoRT.Models;
using Microsoft.AspNetCore.Mvc;
using PiTop;
using PiTop.MakerArchitecture.Expansion;
using UnitsNet;

namespace BE_IoRT.Services
{
    public class RobotUltrasonicService : IRobotWheel
    {
        public async Task<RobotWheel> ReverseLeft(Speed speed, int time)
        {
            EncoderMotor motorLeft;
            EncoderMotor motorRight;
            var expansionPlate = PiTop4Board.Instance.GetOrCreateExpansionPlate();
            motorLeft = expansionPlate.GetOrCreateEncoderMotor(EncoderMotorPort.M2);
            motorRight = expansionPlate.GetOrCreateEncoderMotor(EncoderMotorPort.M3);
            motorLeft.ForwardDirection = ForwardDirection.CounterClockwise;

            var RobotWheel = new RobotWheel()
            {
                MotorLeftDirection = motorLeft.ForwardDirection,
                MotorRightDirection = motorRight.ForwardDirection
            };

            using (motorLeft)
            {
                motorLeft.SetSpeed(speed);
                await Task.Delay(time);
                motorLeft.Stop();
            }

            return RobotWheel;
        }
    }
}