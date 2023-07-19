using SmartHome_Database.Enities;

namespace SmartHome_MVC
{
    public class DevicesViewModel
    {
        public List<string> listPortCOMS = new List<string> { "COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", "COM9", "COM10" };


        public ReadValues viewReadValues { get; set; }
        public ReadValuesFromArduino viewReadValuesFromArduino { get; set; }


        public double currentTemperature { get; set; }
        public int currentButton1 { get; set; }
        public int currentButton2 { get; set; }
        public double currentAnalog { get; set; }


        public DevicesViewModel()
        {
            viewReadValues = new ReadValues();  
        }

    }
}
