using System;
using System.IO;

namespace GC4RVLoader
{
    public class GameDirectoryFormatter
    {
        public static void MoveGameToNestedFolder(string filePath)
        {
            string fileName = Path.GetFileNameWithoutExtension(filePath);
            string destinationPath = $"{GetBaseGameDirectory()}{Path.DirectorySeparatorChar}{fileName}";
            
            Directory.CreateDirectory(destinationPath);
            string destinationFile = $"{destinationPath}{Path.DirectorySeparatorChar}game.iso";
            File.Move(filePath, destinationFile);
            Console.WriteLine($"Game moved to destination: {destinationFile}");
        }

        public static void MoveGamesToNestedFolder(string[] filePaths)
        {
            foreach (string path in filePaths)
            {
                MoveGameToNestedFolder(path);
            }
        }

        public static string GetBaseGameDirectory()
        {
            return $"{Directory.GetCurrentDirectory()}{Path.DirectorySeparatorChar}games";
        }
    }
}