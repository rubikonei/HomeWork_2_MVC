using SmartHouseMVC.Models.Interfaces;

namespace SmartHouseMVC.Models.AbstractDevices
{
    public abstract class ClimateDevice : Device, ITemperature
    {
        public int TemperatureEnvironment { get; set; }
        public abstract int Temperature { get; set; }

        public abstract void Increase();
        public abstract void Decrease();
        public abstract void SetAutoTemperature();
        public override string ToString()
        {
            return base.ToString();
        }
    }
}