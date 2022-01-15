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
                    await Task.WhenAny();
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
            AngularRate angularRate = new AngularRate();
            using (sh)
            {
                try
                {
                    angularRate.X = Math.Round(sh.AngularRate.X, 2);
                    angularRate.Y = Math.Round(sh.AngularRate.Y, 2);
                    angularRate.Z = Math.Round(sh.AngularRate.Z, 2);

                    await Task.WhenAny();
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
            MagneticInduction magneticInduction = new MagneticInduction();
            using (sh)
            {
                try
                {
                    magneticInduction.X = Math.Round(sh.AngularRate.X, 2);
                    magneticInduction.Y = Math.Round(sh.AngularRate.Y, 2);
                    magneticInduction.Z = Math.Round(sh.AngularRate.Z, 2);

                    await Task.WhenAny();
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
            Weather weather = new Weather();
            using (sh)
            {
                try
                {
                    weather.Temperature1 = Math.Round(sh.Temperature.DegreesCelsius, 2);
                    weather.Temperature2 = Math.Round(sh.Temperature2.DegreesCelsius, 2);
                    weather.Humidity = Math.Round(sh.Humidity.Percent, 2);
                    weather.Pressure = Math.Round(sh.Pressure.Bars, 2);
                    await Task.WhenAny();
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