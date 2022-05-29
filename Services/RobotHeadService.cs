using System;
using System.Threading.Tasks;
using BE_IoRT.Interfaces;
using BE_IoRT.Models;
using Microsoft.AspNetCore.Mvc;
using PiTop;
using PiTop.MakerArchitecture.Expansion;
using UnitsNet;


namespace BE_IoRT.Services
{
    public class RobotHeadService : IRobotHead
    {
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
    }
}