using System.Threading.Tasks;
using BE_IoRT.Models;

namespace BE_IoRT.Interfaces
{
    public interface IRobotHead
    {
        public Task<RobotHead> MoveServoMotor(RobotHead client);
    }
}