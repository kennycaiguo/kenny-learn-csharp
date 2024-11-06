using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace custom_event_demo
{
    public class CustomEventArgs : EventArgs
    {
        public CustomEventArgs(string s)
        {
            message = s;
        }
        private string message;
        public string Message
        {
            get { return message; }
            set { message = value; }
        }

    }
    public class Publisher
    {
        public event EventHandler<CustomEventArgs> RaiseCustomEvent;
        public void DoSomething()
        {
            OnRaiseCustomEvent(new CustomEventArgs("Did Something"));
        }

        protected virtual void OnRaiseCustomEvent(CustomEventArgs e)
        {
            EventHandler<CustomEventArgs> handler = RaiseCustomEvent;
            if (handler != null)
            {
                e.Message += string.Format(" at {0}", DateTime.Now.ToString());
                handler(this, e);
            }
        }
    }

    public class Subscriber
    {
        private string id;
        public Subscriber(string ID,Publisher pub)
        {
            id = ID;
            pub.RaiseCustomEvent += HandleCustomEvent;
        }

        private void HandleCustomEvent(object sender, CustomEventArgs e)
        {
            Console.WriteLine(id+" recevied this message:{0}",e.Message);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Publisher publisher = new Publisher();
            Subscriber subscriber1 = new Subscriber("sub1",publisher);
            Subscriber subscriber2 = new Subscriber("sub2",publisher);
            publisher.DoSomething();
            Console.WriteLine();

        }
    }
}
