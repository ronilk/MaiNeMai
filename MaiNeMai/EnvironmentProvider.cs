using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaiNeMai
{
    public class EnvironmentProvider
    {
        public static List<Player> players;

        public static void CreatePlayers(int numberOfPlayers)
        {
            players = new List<Player>();
            players.Capacity = numberOfPlayers;

            for (int i = 0; i < numberOfPlayers; i++)
            {
                players.Add(new Player(i));
            }
            Logger.LogMessage(numberOfPlayers.ToString() + " Players created");
        }

        public static void AssignPillow()
        {
            int totalPlayers = players.Capacity;
            Random rdm = new Random();
            int originatorIndex = rdm.Next(0, totalPlayers);
            Player originator = (from player in players.AsEnumerable()
                                 where player.Id == originatorIndex
                                 select player).First();
            originator.hasPillow = true;
            Logger.LogMessage("Pillow assigned to Player " + originatorIndex.ToString());            
        }

        public static void WireEvents()
        {
            Player previous = null;
            Player current = null;
            int previousIndex;
            for (int i = 0; i < players.Count; i++)
            {
                //every player subscribes to previous players passPillowEvent and endGameEvent
                previousIndex = i - 1 >= 0 ? i - 1 : players.Count - 1;
                previous = players[previousIndex];
                current = players[i];
                previous.passPillowEvent += current.TakePillow;
                previous.endGameEvent += current.StartNewRound;

                MusicPlayer.eventMusicStart += current.ActOnMusicStart;
                MusicPlayer.eventMusicStop += current.ActOnMusicStop;

                current.endGameEvent += EnvironmentProvider.RemovePlayer;

            }            
        }

        public static void RemovePlayer(object source, EndGameEventArgs arg)
        {
            int outPlayerId = (source as Player).Id;
            Player outPlayer = (from p in players
                                where p.Id == outPlayerId
                                select p).First();            
            Logger.LogMessage("EP removing Player " + outPlayerId.ToString());
            ReWireEvents(outPlayer);
            players.Remove(outPlayer);
            Logger.LogMessage("EP Player " + outPlayerId.ToString() + " removed");
            
        }

        private static void ReWireEvents(Player outPlayer)
        {
            int currentIndex = players.IndexOf(outPlayer);
            int nextIndex = currentIndex + 1 > players.Count - 1 ? 0 : currentIndex + 1;
            int previousIndex = currentIndex - 1 < 0 ? players.Count - 1 : currentIndex - 1;

            Player next = players[nextIndex];
            Player previous = players[previousIndex];

            //unsubscribe events
            previous.passPillowEvent -= outPlayer.TakePillow;
            previous.endGameEvent -= outPlayer.StartNewRound;

            MusicPlayer.eventMusicStart -= outPlayer.ActOnMusicStart;
            MusicPlayer.eventMusicStop -= outPlayer.ActOnMusicStop;

            outPlayer.endGameEvent -= EnvironmentProvider.RemovePlayer;

            //subscribe new events
            previous.passPillowEvent += next.TakePillow;
            previous.endGameEvent += next.StartNewRound;

        }

    }
}
