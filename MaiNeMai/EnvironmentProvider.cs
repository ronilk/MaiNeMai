using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaiNeMai
{
    public class EnvironmentProvider
    {
        public static List<Player> CreatePlayers(int numberOfPlayers)
        {
            List<Player> players = new List<Player>();
            players.Capacity = numberOfPlayers;

            for (int i = 0; i < numberOfPlayers; i++)
            {
                players.Add(new Player(i));
            }

            return players;
        }

        public static void AssignPillow(ref List<Player> players)
        {
            int totalPlayers = players.Capacity;
            Random rdm = new Random();
            int originatorIndex = rdm.Next(0, totalPlayers);
            Player originator = (from player in players.AsEnumerable()
                                 where player.Id == originatorIndex
                                 select player).First();
            originator.hasPillow = true;
        }

        public static void WireEvents(ref List<Player> existingPlayers)
        {
            Player previous = null;
            Player current = null;
            int previousIndex;
            for (int i = 0; i < existingPlayers.Count; i++)
            {
                //every player subscribes to previous players passPillowEvent and endGameEvent
                previousIndex = i - 1 >= 0 ? i - 1 : existingPlayers.Count - 1;
                previous = existingPlayers[previousIndex];
                current = existingPlayers[i];
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
        }
    }
}
