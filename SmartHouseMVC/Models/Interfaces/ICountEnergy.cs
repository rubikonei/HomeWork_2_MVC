using SmartHouseMVC.Models.AbstractDevices;
using System.Collections.Generic;

namespace SmartHouseMVC.Models.Interfaces
{
    public interface ICountEnergy
    {
        double AllPower { get; }
        void CountEnergy(IDictionary<int, Device> devices);
    }
}