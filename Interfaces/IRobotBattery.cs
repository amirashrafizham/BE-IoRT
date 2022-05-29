using System.Threading.Tasks;
using BE_IoRT.Models;

namespace BE_IoRT.Interfaces
{
    public interface IRobotBattery
    {
        public Task<RobotBattery> GetBattery();
    }
}