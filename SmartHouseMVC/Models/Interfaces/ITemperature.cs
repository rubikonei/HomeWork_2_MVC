namespace SmartHouseMVC.Models.Interfaces
{
    public interface ITemperature
    {
        int Temperature { get; set; }
        void Increase();
        void Decrease();
    }
}