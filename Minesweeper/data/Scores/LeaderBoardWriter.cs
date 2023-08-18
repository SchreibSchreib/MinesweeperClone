using Minesweeper.data.classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.data.Scores
{
    internal static class LeaderBoardWriter
    {
        private static string _projectFolder = AppDomain.CurrentDomain.BaseDirectory;
        private static string _fileName = "Leaderboard.json";
        
        public static string GetLeaderBoardPath() => Path.Combine(_projectFolder, _fileName);

        public static void WritePlayerList()
        {
            List<Player> allPlayerDatas = LeaderboardReader.GetPlayerList();

        }
    }
}
