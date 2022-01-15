using System;
using System.Threading.Tasks;
using BE_IoRT.Models;
using Iot.Device.SenseHat;
using Microsoft.AspNetCore.Mvc;

namespace BE_IoRT.Services
{
    public class PiSenseHatService : IPiSenseHat
    {
        public async Task<ActionResult<Acceleration>> GetAcceleration()
        {
            var sh = new SenseHat();
            using (sh)
            {
                try
                {
                    Acceleration acceleration = new Acceleration()
                    {
                        X = Math.Round(sh.Acceleration.X, 2),
                        Y = Math.Round(sh.Acceleration.Y, 2),
                        Z = Math.Round(sh.Acceleration.Z, 2)
                    };
                    await Task.Delay(200);
                    return acceleration;
                }
                catch (System.Exception)
                {
                    return null;
                }
            }
        }

        public async Task<ActionResult<AngularRate>> GetAngularRate()
        {
            var sh = new SenseHat();
            using (sh)
            {
                try
                {
                    AngularRate angularRate = new AngularRate()
                    {
                        X = Math.Round(sh.AngularRate.X, 2),
                        Y = Math.Round(sh.AngularRate.Y, 2),
                        Z = Math.Round(sh.AngularRate.Z, 2)
                    };
                    await Task.Delay(200);
                    return angularRate;
                }
                catch (System.Exception)
                {
                    return null;
                }
            }
        }

        public async Task<ActionResult<MagneticInduction>> GetMagneticInduction()
        {
            var sh = new SenseHat();
            using (sh)
            {
                try
                {
                    MagneticInduction magneticInduction = new MagneticInduction()
                    {
                        X = Math.Round(sh.AngularRate.X, 2),
                        Y = Math.Round(sh.AngularRate.Y, 2),
                        Z = Math.Round(sh.AngularRate.Z, 2)
                    };

                    await Task.Delay(200);
                    return magneticInduction;
                }
                catch (System.Exception)
                {
                    return null;
                }
            }
        }

        public async Task<ActionResult<Weather>> GetWeather()
        {
            var sh = new SenseHat();
            using (sh)
            {
                try
                {
                    Weather weather = new Weather()
                    {
                        Temperature1 = Math.Round(sh.Temperature.DegreesCelsius, 2),
                        Temperature2 = Math.Round(sh.Temperature2.DegreesCelsius, 2),
                        Humidity = Math.Round(sh.Humidity.Percent, 2),
                        Pressure = Math.Round(sh.Pressure.Bars, 2)
                    };
                    await Task.Delay(200);
                    return weather;
                }
                catch (System.Exception)
                {
                    return null;
                }
            }
        }
    }
}