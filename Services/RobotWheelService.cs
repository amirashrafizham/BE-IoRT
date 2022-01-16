using System.Threading.Tasks;
using BE_IoRT.Interfaces;
using BE_IoRT.Models;
using Microsoft.AspNetCore.Mvc;
using PiTop;
using PiTop.MakerArchitecture.Expansion;
using UnitsNet;

namespace BE_IoRT.Services
{
    public class RobotWheelService : IRobotWheel
    {
        public async Task<ActionResult<RobotWheel>> Forward(Speed speed, int time)
        {
            var expansionPlate = PiTop4Board.Instance.GetOrCreateExpansionPlate();
            using EncoderMotor motorLeft = expansionPlate.GetOrCreateEncoderMotor(EncoderMotorPort.M2);
            using EncoderMotor motorRight = expansionPlate.GetOrCreateEncoderMotor(EncoderMotorPort.M3);

            motorRight.ForwardDirection = ForwardDirection.CounterClockwise;

            var RobotWheel = new RobotWheel()
            {
                MotorLeftDirection = motorLeft.ForwardDirection,
                MotorRightDirection = motorRight.ForwardDirection
            };

            motorLeft.SetSpeed(speed);
            motorRight.SetSpeed(speed);
            await Task.Delay(time);

            using (motorLeft)
            {
                motorLeft.Stop();
            }
            using (motorRight)
            {
                motorRight.Stop();
            }

            return RobotWheel;
        }

        public Task<ActionResult<RobotWheel>> TurnRight(Speed speed, int time)
        {
            throw new System.NotImplementedException();
        }

        public Task<ActionResult<RobotWheel>> TurnLeft(Speed speed, int time)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ActionResult<RobotWheel>> Reverse(Speed speed, int time)
        {
            var expansionPlate = PiTop4Board.Instance.GetOrCreateExpansionPlate();
            using EncoderMotor motorLeft = expansionPlate.GetOrCreateEncoderMotor(EncoderMotorPort.M2);
            using EncoderMotor motorRight = expansionPlate.GetOrCreateEncoderMotor(EncoderMotorPort.M3);

            motorLeft.ForwardDirection = ForwardDirection.CounterClockwise;

            var RobotWheel = new RobotWheel()
            {
                MotorLeftDirection = motorLeft.ForwardDirection,
                MotorRightDirection = motorRight.ForwardDirection
            };

            motorLeft.SetSpeed(speed);
            motorRight.SetSpeed(speed);
            await Task.Delay(time);

            using (motorLeft)
            {
                motorLeft.Stop();
            }
            using (motorRight)
            {
                motorRight.Stop();
            }

            return RobotWheel;
        }

        public Task<ActionResult<RobotWheel>> ReverseRight(Speed speed, int time)
        {
            throw new System.NotImplementedException();
        }

        public Task<ActionResult<RobotWheel>> ReverseLeft(Speed speed, int time)
        {
            throw new System.NotImplementedException();
        }
    }
}