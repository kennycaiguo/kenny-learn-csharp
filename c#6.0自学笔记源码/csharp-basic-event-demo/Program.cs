using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_basic_event_demo
{
    internal class Program
    {
        /// <summary>
        /// 用命令行模拟事件处理,需要一个发送者和一个订阅者,前者是触发事件,后者处理事件
        /// </summary>
        /// <param name="args"></param>

        //定义一个委托,后面定义事件需要这个委托
        public delegate void EventNotifyHandler(object sender, EventArgs e);
        // 发布者类,在这个类里面定义事件
        public class ProcessBusinessLogic
        {
            //声明事件
            public event EventNotifyHandler ProcessCompleted;
            //触发事件的方法
            public virtual void OnProcessCompleted(EventArgs e)
            {
                ProcessCompleted?.Invoke(this, e);
            }
            //模拟触发事件
            public void StartProcess()
            {
                Console.WriteLine("Process Started...");
                OnProcessCompleted(EventArgs.Empty);
            }
        }
        //订阅者类,需要处理事件
        public class EventSubscriber
        {
            public void Subscrib(ProcessBusinessLogic process)
            {
                process.ProcessCompleted +=Proc_Complete;
            }

            private void Proc_Complete(object sender, EventArgs e)
            {
                 Console.WriteLine("Process Completed...");
            }
        }
        static void Main(string[] args)
        {
            ProcessBusinessLogic process = new ProcessBusinessLogic();
            EventSubscriber subscriber = new EventSubscriber();
            subscriber.Subscrib(process);
            process.StartProcess();
            Console.ReadLine();
        }
    }
}
