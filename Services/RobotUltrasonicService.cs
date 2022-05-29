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
    public class RobotUltrasonicService : IRobotUltrasonic
    {
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
    }
}