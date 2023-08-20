using Minesweeper.data.classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;

namespace Minesweeper.data.Scores
{
    internal static class LeaderBoardWriter
    {
        private static string _projectFolder = AppDomain.CurrentDomain.BaseDirectory;
        private static string _fileName = "Leaderboard.json";

        public static string GetLeaderBoardPath() => Path.Combine(_projectFolder, _fileName);

        public static void WritePlayerList(Player currentPlayer)
        {
            List<Player> allPlayerDatas = LeaderboardReader.GetPlayerList();
            allPlayerDatas.Add(currentPlayer);

            string jsonString = JsonSerializer.Serialize(allPlayerDatas);
            if (!File.Exists(GetLeaderBoardPath()))
            {
                File.Create(GetLeaderBoardPath()).Close();
            }
            File.WriteAllText(GetLeaderBoardPath(), jsonString);

            Debug.WriteLine("Dateien wurden geschrieben.");
        }
    }
}
