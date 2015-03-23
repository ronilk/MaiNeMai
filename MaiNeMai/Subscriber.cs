using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaiNeMai
{
    //EVENTS TEST
    public class Subscriber
    {
        public void CallMe(object source, MyEventArgs arg)
        {
            Console.WriteLine("I had registered and I have been called " + arg.parm);
        }
    }
}
