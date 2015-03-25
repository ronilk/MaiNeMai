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
                this.hasPillow = false;
                Logger.LogMessage("Player " + this.Id.ToString() + " passing pillow");
                passPillowEvent(this, arg);
            }
        }

        public delegate void EndGameHandler(object source, EndGameEventArgs arg);
        public event EndGameHandler endGameEvent;

        public void OnEndGame()
        {
            EndGameEventArgs arg = new EndGameEventArgs();

            if (endGameEvent != null)
            {
                Logger.LogMessage("Player " + this.Id.ToString() + " game ends");
                endGameEvent(this, arg);
            }
        }

        public void TakePillow(object source, PassPillowEventArgs arg)
        {   
            this.hasPillow = true;
            Logger.LogMessage("Player " + this.Id.ToString() + " has pillow");
            Thread.Sleep(2000);
            this.OnPillowPass();
        }

        public void StartNewRound(object source, EndGameEventArgs arg)
        {
            this.hasPillow = true;
            Logger.LogMessage("Player " + this.Id.ToString() + " new round started");
        }

        public void ActOnMusicStart(object source, MusicStartEventArgs arg)
        {
            if (hasPillow)
            {
                Logger.LogMessage("Player " + this.Id.ToString() + " passing pillow on music start");
                Thread.Sleep(2000);
                this.OnPillowPass();
            }
        }

        public void ActOnMusicStop(object source, MusicStopEventArgs arg)
        {
            if (hasPillow == true)
            {
                this.OnEndGame();
            }
        }
    }

    public class PassPillowEventArgs : EventArgs
    { 
    }

    public class EndGameEventArgs : EventArgs
    {
        //public int Id;
    }
}
