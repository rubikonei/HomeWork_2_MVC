using SmartHouseMVC.Models.Devices;

namespace SmartHouseMVC.Models.Factory
{
    public class Factory
    {
        public Conditioner GetConditioner()
        {
            return new Conditioner("Кондиционер", false, false);
        }

        public Convector GetConvector()
        {
            return new Convector("Конвектор", false);
        }

        public EnergyMeter GetEnergyMeter()
        {
            return new EnergyMeter("Счетчик электроэнергии", false);
        }

        public TemperatureSensor GetTemperatureSensor()
        {
            return new TemperatureSensor("Датчик температуры", false);
        }
    }
}