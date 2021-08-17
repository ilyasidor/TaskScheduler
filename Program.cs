using System;
using Microsoft.Win32.TaskScheduler;

namespace threading_learning
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskService.Instance.AddTask("Test", QuickTriggerType.Daily, "myprogram.exe", "-a arg");
            Console.WriteLine("Hello World!");
        }
    }
}
