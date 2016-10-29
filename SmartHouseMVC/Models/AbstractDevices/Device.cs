namespace SmartHouseMVC.Models.AbstractDevices
{
    public abstract class Device
    {
        private double power;

        public abstract void On();
        public abstract void Off();

        public string Name { get; protected set; }
        public bool State { get; protected set; }
        public double Power
        {
            get
            {
                return power;
            }
            set
            {
                if (value >= 0)
                {
                    power = value;
                }
            }
        }

        public override string ToString()
        {
            string state;
            if (State == true)
            {
                state = "включен";
            }
            else
            {
                state = "выключен";
            }
            return Name + ": " + state + ", мощность: " + Power;
        }
    }
}