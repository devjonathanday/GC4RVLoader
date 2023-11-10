using System;
using System.IO;

namespace GC4RVLoader
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Ready to migrate files. Press any key to begin.");
            Console.ReadKey();
            
            //Download cover images for games in the current directory
            string[] gameIds = GameFileReader.GetGameIdsFromDirectory(Directory.GetCurrentDirectory(), true);
            DBImageDownloader.DownloadCovers(gameIds);
            //Move games into nested directories (folder names are game names)
            string[] gameFiles = GameFileReader.GetValidGamesFromDirectory(Directory.GetCurrentDirectory());
            GameDirectoryFormatter.MoveGamesToNestedFolder(gameFiles);
            
            Console.WriteLine("Migration finished, press any key to close this window.");
            Console.ReadKey();
        }
    }
}