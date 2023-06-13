using SmartHome_Database.Enities;

namespace SmartHome_MVC
{
    public class DevicesViewModel
    {
        public PortCOMS viewPortCOMS { get; set; } 
        public ReadValues viewReadValues { get; set; }
        public ReadValuesFromArduino viewReadValuesFromArduino { get; set; }

        public double currentTemperature { get; set; }
        public int currentButton1 { get; set; }
        public int currentButton2 { get; set; }
        public double currentAnalog { get; set; }


        public DevicesViewModel()
        {
            viewPortCOMS = new PortCOMS();
            viewReadValues = new ReadValues();  

        }

    }
}
