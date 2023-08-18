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
            List<Player> playerList = new List<Player>();
            string jsonContent = File.ReadAllText(LeaderBoardWriter.GetLeaderBoardPath());

            if (!File.Exists(LeaderBoardWriter.GetLeaderBoardPath()) || jsonContent == null)
            {
                return new List<Player>
                {
                    new Player("Rainer Zufall",new Points(),new Difficulty()),
                    new Player("Ernst Haft",new Points(),new Difficulty()),
                    new Player("Sergej Fährlich",new Points(),new Difficulty()),
                    new Player("Wilma Ruhe",new Points(),new Difficulty()),
                    new Player("Die Maschine",new Points(),new Difficulty()),
                    new Player("Rosa Blume",new Points(),new Difficulty()),
                    new Player("Lee Monade",new Points(),new Difficulty()),
                    new Player("Roman Ticker",new Points(),new Difficulty()),
                    new Player("Yum Meefood",new Points(),new Difficulty()),
                    new Player("Mike Litoris",new Points(),new Difficulty()),
                    new Player("Klaus Schnell",new Points(),new Difficulty())
                };
            }
            if (JsonSerializer.Deserialize<Player>(jsonContent) != null)
            {
                playerList = JsonSerializer.Deserialize<List<Player>>(jsonContent)!;
            }
            return playerList;
        }
    }
}
