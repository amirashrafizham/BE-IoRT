using System.Threading.Tasks;
using BE_IoRT.Models;
using Microsoft.AspNetCore.Mvc;
using UnitsNet;

namespace BE_IoRT.Interfaces
{
    public interface IRobotUltrasonic
    {
        public Task<RobotWheel> Sense();
    }
}