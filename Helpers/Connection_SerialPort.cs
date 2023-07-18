using DotNetty.Common;
using DotNetty.Common.Concurrency;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace SmartHome_MVC
{
    public class MyScheduledTask : IScheduledTask
    {
        public string Schedule => "*/1 * * * *"; // uruchomienie co minutę

        public PreciseTimeSpan Deadline => throw new NotImplementedException();

        public Task Completion => throw new NotImplementedException();

        public bool Cancel()
        {
            throw new NotImplementedException();
        }

        public async Task ExecuteAsync()
        {
            // wykonaj swoją logikę tutaj
            PrintMessage();
        }

        public TaskAwaiter GetAwaiter()
        {
            throw new NotImplementedException();
        }

        private void PrintMessage()
        {
            Console.WriteLine("Hello, world!");
        }
    }



    public class Connection_SerialPort : Controller
    {


        public IActionResult Index()
        {
            return View();
        }
    }
}
