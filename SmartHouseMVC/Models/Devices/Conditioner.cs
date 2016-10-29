using SmartHouseMVC.Models.AbstractDevices;
using SmartHouseMVC.Models.Interfaces;

namespace SmartHouseMVC.Models.Devices
{
    public class Conditioner : ClimateDevice, IFan
    {
        private int temperature;
        private bool fan;

        public Conditioner(string name, bool state, bool fan)
        {
            Name = name;
            State = state;
            if (state == true)
            {
                Temperature = 22;
                Power = 4;
            }
            Fan = fan;
        }

        public override int Temperature
        {
            get
            {
                return temperature;
            }
            set
            {
                if (value >= 15 && value <= 25 && State == true)
                {
                    temperature = value;
                }
                if (State == false)
                {
                    temperature = 0;
                }
            }
        }

        public bool Fan
        {
            get
            {
                return fan;
            }
            set
            {
                if (value == true && Fan == false && State == true)
                {
                    fan = value;
                    Power += 0.2;
                }
                if (value == false && Fan == true && State == true)
                {
                    fan = value;
                    Power -= 0.2;
                }
                if (value == false && State == false)
                {
                    fan = value;
                }
            }
        }

        public override void On()
        {
            State = true;
            Power = 4;
            Temperature = 22;
        }

        public override void Off()
        {
            State = false;
            Power = 0;
            Temperature = 0;
            Fan = false;
        }

        public override void Increase()
        {
            Temperature++;
        }

        public override void Decrease()
        {
            Temperature--;
        }

        public void FanOn()
        {
            Fan = true;
        }

        public void FanOff()
        {
            Fan = false;
        }

        public override void SetAutoTemperature()
        {
            if (TemperatureEnvironment >= 25 && TemperatureEnvironment <= 40)
            {
                On();
                Temperature = 22;
                Power += (TemperatureEnvironment - Temperature) * 0.05;
            }
            else
            {
                Off();
            }
        }

        public override string ToString()
        {
            string fanState;
            if (fan)
            {
                fanState = "включен";
            }
            else
            {
                fanState = "выключен";
            }
            return base.ToString() + ", температура: " + temperature + ", венитялтор: " + fanState;
        }
    }
}