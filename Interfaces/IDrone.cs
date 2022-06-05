using System.Threading.Tasks;

namespace BE_IoRT.Interfaces
{
    public interface IDrone
    {
        public Task<string> DroneCommand(string command);
        public Task<string> Connect();
        public Task<string> GetBattery();
        public Task<string> TakeOff();
        public Task<string> Land();
        public Task<string> MoveUp();
        public Task<string> MoveDown();
        public Task<string> MoveLeft();
        public Task<string> MoveRight();
        public Task<string> Forward();
        public Task<string> Reverse();
        public Task<string> TurnClockwise();
        public Task<string> TurnCounterClockWise();

    }
}