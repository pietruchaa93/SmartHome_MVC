using Microsoft.AspNetCore.Mvc;

namespace SmartHome_MVC
{
    public class PortCOMS
    {
        public List<string> AvailablePorts { get; set; } = new List<string> { "COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", "COM9", "COM10" };
        public string portCOM { get; set; }

    }
}
