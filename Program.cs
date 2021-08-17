using System;
using Microsoft.Win32.TaskScheduler;
using System.Threading;

namespace threading_learning
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskService.Instance.AddTask("Test", QuickTriggerType.Daily, "myprogram.exe", "-a arg");//создание задачи напрямую через библиотеку
            TaskManage task = new TaskManage("InformationSecurity", "SSS.exe", QuickTriggerType.Hourly);//создание задачи классовым методом
            task.TaskCreate();
            TaskCrate("InformationSecurity", "SSS.exe", QuickTriggerType.Hourly);//создание задачи через функцию
            
            //
            Thread thr2 = new Thread(new ThreadStart(task.Create));//внесении функции с параметрами в поток классвым методом
            Thread thr = Thread.CurrentThread;//получение текущего потока
        }
        public static void TaskCrate(string NAME_TASK, string PATH_TO_MY_PROGRAMM, QuickTriggerType triggerType)
        {
            TaskService.Instance.AddTask(NAME_TASK, triggerType, PATH_TO_MY_PROGRAMM);
        }
    }
    class TaskManage
    {
        string PATH_TO_MY_PROGRAMM;
        string NAME_TASK;
        QuickTriggerType triggerType;
        public TaskManage(string NAME_TASK, string PATH_TO_MY_PROGRAMM, QuickTriggerType triggerType)
        {
            this.NAME_TASK = NAME_TASK;
            this.PATH_TO_MY_PROGRAMM = PATH_TO_MY_PROGRAMM;
            this.triggerType = triggerType;
        }
        public void TaskCreate()
        {
            TaskService.Instance.AddTask(NAME_TASK, triggerType, PATH_TO_MY_PROGRAMM);
        }
    }
}
