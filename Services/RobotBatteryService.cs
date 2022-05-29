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
    public class RobotBatteryService : IRobotBattery
    {
        public async Task<RobotBattery> GetBattery()
        {
            RobotBattery robotBattery = new RobotBattery();
            var batteryState = PiTop4Board.Instance.BatteryState.TimeRemaining.Minutes;
            robotBattery.Minutes = batteryState;
            await Task.Delay(200);
            return robotBattery;
        }
    }
}