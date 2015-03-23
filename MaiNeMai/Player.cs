using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MaiNeMai
{
    public class Player
    {
        public bool hasPillow;
        public int Id;

        public Player(int id)
        {
            this.Id = id;
            this.hasPillow = false;
        }

        public delegate void PassPillowHandler(object source, PassPillowEventArgs arg);

        public event PassPillowHandler passPillowEvent;

        public void OnPillowPass()
        {
            PassPillowEventArgs arg = new PassPillowEventArgs();

            if (passPillowEvent != null)
            {
                hasPillow = false;
                passPillowEvent(this, arg);
            }
        }

        public void TakePillow(object source, PassPillowEventArgs arg)
        {
            hasPillow = true;
            Thread.Sleep(2000);
            this.OnPillowPass();
        }
    }

    public class PassPillowEventArgs : EventArgs
    { 
    }

    public class EndGameEventArgs : EventArgs
    {
    }
}
