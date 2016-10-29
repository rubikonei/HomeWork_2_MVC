namespace SmartHouseMVC.Models.Interfaces
{
    public interface IFan
    {
        bool Fan { get; set; }
        void FanOn();
        void FanOff();
    }
}