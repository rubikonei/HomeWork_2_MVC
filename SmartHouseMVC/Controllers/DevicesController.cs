using SmartHouseMVC.Models.AbstractDevices;
using SmartHouseMVC.Models.Factory;
using SmartHouseMVC.Models.Interfaces;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SmartHouseMVC.Controllers
{
    public class DevicesController : Controller
    {
        // GET: Devices
        public ActionResult Index()
        {
            IDictionary<int, Device> devicesDictionary;
            Factory factory;

            if (Session["Devices"] == null)
            {
                factory = new Factory();
                devicesDictionary = new Dictionary<int, Device>();
                devicesDictionary.Add(1, factory.GetConditioner());
                devicesDictionary.Add(2, factory.GetConvector());
                devicesDictionary.Add(3, factory.GetEnergyMeter());
                devicesDictionary.Add(4, factory.GetTemperatureSensor());

                Session["Devices"] = devicesDictionary;
                Session["NextId"] = 5;
            }
            else
            {
                devicesDictionary = (Dictionary<int, Device>)Session["Devices"];
            }

            SelectListItem[] devicesList = new SelectListItem[4];
            devicesList[0] = new SelectListItem { Text = "Кондиционер", Value = "conditioner", Selected = true };
            devicesList[1] = new SelectListItem { Text = "Конвектор", Value = "convector" };
            devicesList[2] = new SelectListItem { Text = "Счетчик электроэнергии", Value = "energyMeter" };
            devicesList[3] = new SelectListItem { Text = "Датчик температуры", Value = "temperatureSensor" };
            ViewBag.DevicesList = devicesList;

            return View(devicesDictionary);
        }

        public ActionResult Add(string deviceType)
        {
            Device newDevice;
            Factory factory = new Factory();

            switch (deviceType)
            {
                default:
                    newDevice = factory.GetConditioner();
                    break;
                case "convector":
                    newDevice = factory.GetConvector();
                    break;
                case "energyMeter":
                    newDevice = factory.GetEnergyMeter();
                    break;
                case "temperatureSensor":
                    newDevice = factory.GetTemperatureSensor();
                    break;
            }

            int id = (int)Session["NextId"];
            IDictionary<int, Device> devicesDictionary = (Dictionary<int, Device>)Session["Devices"];
            devicesDictionary.Add(id, newDevice);
            id++;
            Session["NextId"] = id;

            return RedirectToAction("Index");
        }

        public ActionResult Off(int id)
        {
            IDictionary<int, Device> devicesDictionary = (Dictionary<int, Device>)Session["Devices"];
            if (devicesDictionary[id].State == true)
            {
                devicesDictionary[id].Off();
            }
            else
            {
                devicesDictionary[id].On();
            }
            return RedirectToAction("Index");
        }

        public ActionResult DecreaseTemperature(int id)
        {
            IDictionary<int, Device> devicesDictionary = (Dictionary<int, Device>)Session["Devices"];
            ((ClimateDevice)devicesDictionary[id]).Decrease();
            return RedirectToAction("Index");
        }

        public ActionResult IncreaseTemperature(int id)
        {
            IDictionary<int, Device> devicesDictionary = (Dictionary<int, Device>)Session["Devices"];
            ((ClimateDevice)devicesDictionary[id]).Increase();
            return RedirectToAction("Index");
        }

        public ActionResult SetAutoTemperature(int id)
        {
            IDictionary<int, Device> devicesDictionary = (Dictionary<int, Device>)Session["Devices"];
            foreach (Device device in devicesDictionary.Values)
            {
                if (device is ITemperatureSensor && device.State == true)
                {
                    ((ClimateDevice)devicesDictionary[id]).TemperatureEnvironment = ((ITemperatureSensor)device).TemperatureEnvironment;
                }
            }
            ((ClimateDevice)devicesDictionary[id]).SetAutoTemperature();
            return RedirectToAction("Index");
        }

        public ActionResult CountEnergy(int id)
        {
            IDictionary<int, Device> devicesDictionary = (Dictionary<int, Device>)Session["Devices"];
            ((ICountEnergy)devicesDictionary[id]).CountEnergy(devicesDictionary);
            return RedirectToAction("Index");
        }

        public ActionResult OffFan(int id)
        {
            IDictionary<int, Device> devicesDictionary = (Dictionary<int, Device>)Session["Devices"];
            if (((IFan)devicesDictionary[id]).Fan == true)
            {
                ((IFan)devicesDictionary[id]).FanOff();
            }
            else
            {
                ((IFan)devicesDictionary[id]).FanOn();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            IDictionary<int, Device> devicesDictionary = (Dictionary<int, Device>)Session["Devices"];
            devicesDictionary.Remove(id);
            return RedirectToAction("Index");
        }
    }
}