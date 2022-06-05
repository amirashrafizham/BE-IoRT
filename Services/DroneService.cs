using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using BE_IoRT.Interfaces;

namespace BE_IoRT.Services
{
    public class DroneService : IDrone
    {
        public async Task<string> DroneCommand(string command)
        {
            UdpClient udpClient = new UdpClient(8889);
            try
            {
                udpClient.Connect("192.168.10.1", 8889);

                // Sends a message to the host to which you have conected.
                Byte[] sendBytes = Encoding.ASCII.GetBytes(command);

                udpClient.Send(sendBytes, sendBytes.Length);

                //IPEndPoint object will allow us to read datagrams sent from any source.
                IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);

                // Blocks until a message returns on this socket from a remote host.
                Byte[] receiveBytes = udpClient.Receive(ref RemoteIpEndPoint);
                string returnData = Encoding.ASCII.GetString(receiveBytes);

                // Uses the IPEndPoint object to determine which of these two hosts responded.
                Console.WriteLine("This is the message you received " +
                                             returnData.ToString());
                Console.WriteLine("This message was sent from " +
                                            RemoteIpEndPoint.Address.ToString() +
                                            " on their port number " +
                                            RemoteIpEndPoint.Port.ToString());
                udpClient.Close();
                await Task.CompletedTask;
                return returnData.ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return e.ToString();
            }
        }

        public async Task<string> Connect()
        {
            var result = await DroneCommand("command");
            return result;
        }
        public async Task<string> Forward()
        {
            var result = await DroneCommand("forward 50");
            return result;
        }

        public async Task<string> GetBattery()
        {
            var result = await DroneCommand("battery?");
            return result;
        }

        public async Task<string> Land()
        {
            var result = await DroneCommand("land");
            return result;
        }

        public async Task<string> MoveDown()
        {
            var result = await DroneCommand("down 40");
            return result;
        }

        public async Task<string> MoveLeft()
        {
            var result = await DroneCommand("left 40");
            return result;
        }

        public async Task<string> MoveRight()
        {
            var result = await DroneCommand("right 40");
            return result;
        }

        public async Task<string> MoveUp()
        {
            var result = await DroneCommand("up 40");
            return result;
        }

        public async Task<string> Reverse()
        {
            var result = await DroneCommand("back 50");
            return result;
        }

        public async Task<string> TakeOff()
        {
            var result = await DroneCommand("takeoff");
            return result;
        }

        public async Task<string> TurnClockwise()
        {
            var result = await DroneCommand("cw 45");
            return result;
        }

        public async Task<string> TurnCounterClockWise()
        {
            var result = await DroneCommand("ccw 45");
            return result;
        }
    }
}