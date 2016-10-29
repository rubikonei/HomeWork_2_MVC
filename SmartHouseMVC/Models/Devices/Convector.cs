using SmartHouseMVC.Models.AbstractDevices;

namespace SmartHouseMVC.Models.Devices
{
    public class Convector : ClimateDevice
    {
        private int temperature;

        public Convector(string name, bool state)
        {
            Name = name;
            State = state;
            if (state == true)
            {
                Temperature = 20;
                Power = 3.5;
            }
        }

        public override int Temperature
        {
            get
            {
                return temperature;
            }
            set
            {
                if (value >= 20 && value <= 30 && State == true)
                {
                    temperature = value;
                }
                if (State == false)
                {
                    temperature = 0;
                }
            }
        }

        public override void On()
        {
            State = true;
            Power = 3.5;
            Temperature = 20;
        }

        public override void Off()
        {
            State = false;
            Power = 0;
            Temperature = 0;
        }

        public override void Increase()
        {
            Temperature++;
        }

        public override void Decrease()
        {
            Temperature--;
        }

        public override void SetAutoTemperature()
        {
            if (TemperatureEnvironment <= 10 && TemperatureEnvironment >= -30)
            {
                On();
                Temperature = 20;
                Power += (Temperature - TemperatureEnvironment) * 0.05;
            }
            else
            {
                Off();
            }
        }

        public override string ToString()
        {
            return base.ToString() + ", температура: " + temperature;
        }
    }
}