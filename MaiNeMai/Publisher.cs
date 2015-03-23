using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaiNeMai
{
    //EVENTS TEST
    public class Publisher
    {
        public delegate void MyHandler(object source, MyEventArgs arg);

        public event MyHandler myEvent;

        public void OnEventOccurence(int ip)
        {
            MyEventArgs arg = new MyEventArgs();

            if (myEvent != null)
            {
                arg.parm = ip;
                myEvent(this, arg);
            }
        }
    }


    public class MyEventArgs: EventArgs
    {
        public int parm;
    }
}
