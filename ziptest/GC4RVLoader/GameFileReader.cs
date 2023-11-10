using System;
using System.IO;
using System.Linq;

namespace GC4RVLoader
{
    public class GameFileReader
    {
        public static string GetGameId(string filePath)
        {
            string bytes = HexReader.ReadBytes(filePath, 6);
            return HexReader.DecodeHex(bytes);
        }

        public static string[] GetGameIdsFromDirectory(string directoryPath, bool writeToConsole = false)
        {
            string[] files = GetValidGamesFromDirectory(directoryPath);
            if (writeToConsole)
            {
                Console.WriteLine("Games found:");
                foreach (string file in files)
                {
                    Console.WriteLine($"{file}: {GetGameId(file)}");
                }
            }

            return files.Select(GetGameId).ToArray();
        }

        public static string[] GetValidGamesFromDirectory(string directoryPath)
        {
            string[] files = Directory.GetFiles(directoryPath, "*.iso");
            return files.Where(file => !file.Contains(".nkit")).ToArray();
        }
    }
}