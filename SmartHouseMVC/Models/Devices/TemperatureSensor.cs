using SmartHouseMVC.Models.AbstractDevices;
using SmartHouseMVC.Models.Interfaces;
using System;

namespace SmartHouseMVC.Models.Devices
{
    public class TemperatureSensor : Device, ITemperatureSensor
    {
        public TemperatureSensor(string name, bool state)
        {
            Name = name;
            State = state;
        }

        public int TemperatureEnvironment { get; set; }

        public override void On()
        {
            State = true;
            Power = 0.05;
            GetTemperature();
        }

        public override void Off()
        {
            State = false;
            Power = 0;
            TemperatureEnvironment = 0;
        }

        private void GetTemperature()
        {
            Random r = new Random();
            TemperatureEnvironment = r.Next(-30, 41);
        }

        public override string ToString()
        {
            return base.ToString() + ", наружная температура: " + TemperatureEnvironment;
        }
    }
}