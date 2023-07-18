using System.IO.Ports;
using Newtonsoft.Json;
using SmartHome_Database;
using SmartHome_Database.Enities;




namespace SmartHome_MVC
{
    public class SerialPortService : IHostedService
    {
        private SerialPort _port;
        private string currentPortCOM;

        public Task StartAsync(CancellationToken cancellationToken)
        {

            var dbContext = new SmartHomeDbContext(); // My DbContext

            var lastSave = dbContext.selectportCOM // My table Name
                .OrderByDescending(x => x.Id)
                .FirstOrDefault();

            // If the last Write is null, the database is empty

            if (lastSave != null)
            {
                // Use last save as needed
                int id = lastSave.Id;
                currentPortCOM = lastSave.portCOM;

            }
            string selectedPortName = currentPortCOM; // Selected port

            string[] availablePortNames = SerialPort.GetPortNames();
            if (Array.IndexOf(availablePortNames, selectedPortName) == -1)
            {
                // The selected port is not available
                // Appropriate actions can be taken here, e.g. log an error, return information to the user, etc.
                return Task.CompletedTask;
            }
            else
            {

                _port = new SerialPort();
                _port.PortName = currentPortCOM;
                _port.BaudRate = 9600;
                _port.Parity = Parity.None;
                _port.DataBits = 8;
                _port.StopBits = StopBits.One;
                _port.Handshake = Handshake.None;
                _port.RtsEnable = true;

                _port.DataReceived += new SerialDataReceivedEventHandler(DataReceiver);
                try
                {
                    _port.Open();
                }
                catch
                {
                    _port.Close();
                }

            }


            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _port.Close();

            return Task.CompletedTask;
        }

        private void DataReceiver(object sender, SerialDataReceivedEventArgs e)
        {
            // Handling of acquired data

            try
            {
                SerialPort myport = (SerialPort)sender;
                String data = myport.ReadExisting();

                if (data.Contains(" "))
                {
                    int x;
                    string correct;
                    x = data.IndexOf(" ");
                    correct = data.Remove(x);

                    Adder(correct);

                }
                else
                {
                    Adder(data);
                }


            }
            catch (Exception ex)  //To remove at finish 
            {
                Console.WriteLine("No data!!!");
                Console.WriteLine(ex.Message);
                Console.WriteLine();
            }



        }


        public static void Adder(string jsonString)
        {
            ReadValuesFromArduino? globalBase = JsonConvert.DeserializeObject<ReadValuesFromArduino>(jsonString);  //Deserialize correctly string 


            DatabaseLocator.Database.ReadValuesArduino.Add(globalBase);  //Save to Data Base
            DatabaseLocator.Database.SaveChanges();
        }



    }

}
