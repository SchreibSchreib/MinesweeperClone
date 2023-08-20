using Minesweeper.data.classes;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

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
                    new Player("Rainer Zufall",new Points(),new Difficulty("Hard"),new TimeMeasure()),
                    new Player("Ernst Haft",new Points(),new Difficulty("Hard"),new TimeMeasure()),
                    new Player("Sergej Fährlich",new Points(),new Difficulty("Hard"), new TimeMeasure()),
                    new Player("Wilma Ruhe",new Points(),new Difficulty("Medium"), new TimeMeasure()),
                    new Player("Dennis Schläger",new Points(),new Difficulty("Medium"), new TimeMeasure()),
                    new Player("Rosa Blume",new Points(),new Difficulty("Medium"), new TimeMeasure()),
                    new Player("Lee Monade",new Points(),new Difficulty("Medium"), new TimeMeasure()),
                    new Player("Roman Ticker",new Points(),new Difficulty("Easy"), new TimeMeasure()),
                    new Player("Yum Meefood",new Points(),new Difficulty("Easy"), new TimeMeasure()),
                    new Player("Ann Trieb",new Points(),new Difficulty("Easy"), new TimeMeasure()),
                };


            }

            string jsonContent = File.ReadAllText(LeaderBoardWriter.GetLeaderBoardPath());
            List<Player> playerList = JsonSerializer.Deserialize<List<Player>>(jsonContent)!;

            return playerList;
        }
    }
}
