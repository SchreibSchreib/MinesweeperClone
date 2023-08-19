using Minesweeper.data.classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Minesweeper.data.Scores
{
    internal static class LeaderboardReader
    {
        public static List<Player> GetPlayerList()
        {
            if (!File.Exists(LeaderBoardWriter.GetLeaderBoardPath()))
            {
                return new List<Player>
                {
                    new Player("Rainer Zufall",new Points(),new Difficulty(),new TimeMeasure()),
                    new Player("Ernst Haft",new Points(),new Difficulty(),new TimeMeasure()),
                    new Player("Sergej Fährlich",new Points(),new Difficulty(), new TimeMeasure()),
                    new Player("Wilma Ruhe",new Points(),new Difficulty(), new TimeMeasure()),
                    new Player("Dennis Schläger",new Points(),new Difficulty(), new TimeMeasure()),
                    new Player("Rosa Blume",new Points(),new Difficulty(), new TimeMeasure()),
                    new Player("Lee Monade",new Points(),new Difficulty(), new TimeMeasure()),
                    new Player("Roman Ticker",new Points(),new Difficulty(), new TimeMeasure()),
                    new Player("Yum Meefood",new Points(),new Difficulty(), new TimeMeasure()),
                    new Player("Ann Trieb",new Points(),new Difficulty(), new TimeMeasure())
                };


            }
            string jsonContent = File.ReadAllText(LeaderBoardWriter.GetLeaderBoardPath());
            List<Player> playerList = JsonSerializer.Deserialize<List<Player>>(jsonContent)!;

            return playerList;
        }
    }
}
