using System;
using System.Threading.Tasks;
using BE_IoRT.Interfaces;
using BE_IoRT.Models;
using Microsoft.AspNetCore.Mvc;
using PiTop;
using PiTop.MakerArchitecture.Expansion;
using PiTop.MakerArchitecture.Foundation;
using PiTop.MakerArchitecture.Foundation.Sensors;
using UnitsNet;

namespace BE_IoRT.Services
{
    public class RobotService : IRobot
    {
        public async Task<RobotWheel> Forward(Speed speed, int time)
        {
            var expansionPlate = PiTop4Board.Instance.GetOrCreateExpansionPlate();
            EncoderMotor motorLeft = expansionPlate.GetOrCreateEncoderMotor(EncoderMotorPort.M2);
            EncoderMotor motorRight = expansionPlate.GetOrCreateEncoderMotor(EncoderMotorPort.M3);

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

        public async Task<RobotBattery> GetBattery()
        {
            RobotBattery robotBattery = new RobotBattery();
            var batteryState = PiTop4Board.Instance.BatteryState.TimeRemaining.Minutes;
            robotBattery.Minutes = batteryState;
            await Task.Delay(200);
            return robotBattery;
        }

        public async Task<RobotHead> MoveServoMotor(RobotHead client)
        {
            RobotHead robotHead = new RobotHead()
            {
                AngleHorizontal = client.AngleHorizontal,
                AngleVertical = client.AngleVertical
            };

            ServoMotor mtrHorizontal;
            ServoMotor mtrVertical;

            Angle setAngleHorizontal = Angle.FromDegrees(client.AngleHorizontal);
            Angle setAngleVertical = Angle.FromDegrees(client.AngleVertical);

            var expansionPlate = PiTop4Board.Instance.GetOrCreateExpansionPlate();
            mtrHorizontal = expansionPlate.GetOrCreateServoMotor(ServoMotorPort.S1); //Port M1 Default Forward
            mtrVertical = expansionPlate.GetOrCreateServoMotor(ServoMotorPort.S4);

            using (mtrHorizontal)
            {
                mtrHorizontal.GoToAngle(setAngleHorizontal);
            }

            using (mtrVertical)
            {
                mtrVertical.GoToAngle(setAngleVertical);
            }

            await Task.Delay(200);
            return robotHead;
        }

        public async Task<RobotWheel> Reverse(Speed speed, int time)
        {
            var expansionPlate = PiTop4Board.Instance.GetOrCreateExpansionPlate();
            EncoderMotor motorLeft = expansionPlate.GetOrCreateEncoderMotor(EncoderMotorPort.M2);
            EncoderMotor motorRight = expansionPlate.GetOrCreateEncoderMotor(EncoderMotorPort.M3);

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

        public async Task<RobotWheel> ReverseRight(Speed speed, int time)
        {
            EncoderMotor motorLeft;
            EncoderMotor motorRight;
            var expansionPlate = PiTop4Board.Instance.GetOrCreateExpansionPlate();
            motorLeft = expansionPlate.GetOrCreateEncoderMotor(EncoderMotorPort.M2);
            motorRight = expansionPlate.GetOrCreateEncoderMotor(EncoderMotorPort.M3);

            var RobotWheel = new RobotWheel()
            {
                MotorLeftDirection = motorLeft.ForwardDirection,
                MotorRightDirection = motorRight.ForwardDirection
            };

            using (motorRight)
            {
                motorRight.SetSpeed(speed);
                await Task.Delay(time);
                motorRight.Stop();
            }

            return RobotWheel;
        }

        public async Task<RobotUltraSonic> Sense()
        {
            UltrasonicSensor frontUltraSound;
            RobotUltraSonic robotUltraSonic = new RobotUltraSonic();
            var expansionPlate = PiTop4Board.Instance.GetOrCreateExpansionPlate();
            frontUltraSound = expansionPlate.GetOrCreateUltrasonicSensor(DigitalPort.D3);
            robotUltraSonic.Length = frontUltraSound.Distance.Centimeters;

            await Task.Delay(200);
            return robotUltraSonic;
        }

        public async Task<RobotWheel> TurnRight(Speed speed, int time)
        {
            EncoderMotor motorLeft;
            EncoderMotor motorRight;
            var expansionPlate = PiTop4Board.Instance.GetOrCreateExpansionPlate();
            motorLeft = expansionPlate.GetOrCreateEncoderMotor(EncoderMotorPort.M2);
            motorRight = expansionPlate.GetOrCreateEncoderMotor(EncoderMotorPort.M3);

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

        public async Task<RobotWheel> TurnLeft(Speed speed, int time)
        {
            EncoderMotor motorLeft;
            EncoderMotor motorRight;
            var expansionPlate = PiTop4Board.Instance.GetOrCreateExpansionPlate();
            motorLeft = expansionPlate.GetOrCreateEncoderMotor(EncoderMotorPort.M2);
            motorRight = expansionPlate.GetOrCreateEncoderMotor(EncoderMotorPort.M3);
            motorRight.ForwardDirection = ForwardDirection.CounterClockwise;

            var RobotWheel = new RobotWheel()
            {
                MotorLeftDirection = motorLeft.ForwardDirection,
                MotorRightDirection = motorRight.ForwardDirection
            };

            using (motorRight)
            {
                motorRight.SetSpeed(speed);
                await Task.Delay(time);
                motorRight.Stop();
            }

            return RobotWheel;
        }

    }
}