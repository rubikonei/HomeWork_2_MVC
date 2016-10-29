using SmartHouseMVC.Models.AbstractDevices;
using SmartHouseMVC.Models.Interfaces;
using System.Collections.Generic;

namespace SmartHouseMVC.Models.Devices
{
    public class EnergyMeter : Device, ICountEnergy
    {
        public double AllPower { get; protected set; }

        public EnergyMeter(string name, bool state)
        {
            Name = name;
            State = state;
        }

        public override void On()
        {
            State = true;
            Power = 0.05;
        }

        public override void Off()
        {
            State = false;
            Power = 0;
        }

        public void CountEnergy(IDictionary<int, Device> devices)
        {
            if (State == true)
            {
                AllPower = 0;
                foreach (KeyValuePair<int, Device> device in devices)
                {
                    AllPower += device.Value.Power;
                }
            }
        }

        public override string ToString()
        {
            return base.ToString() + ", потребляемая эл-гия: " + AllPower;
        }
    }
}