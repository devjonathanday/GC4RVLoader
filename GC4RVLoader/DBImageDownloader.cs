using System;
using System.IO;
using System.Net;

namespace GC4RVLoader
{
    public class DBImageDownloader
    {
        private const string baseUrl = "https://art.gametdb.com";
        private const string platform = "wii";
        private const string coverType = "cover";
        private const string region = "US";
        private const string imageFormat = "png";

        public static void DownloadCover(string gameId)
        {
            using (WebClient client = new WebClient())
            {
                string sep = $"{Path.DirectorySeparatorChar}";
                string destinationDirectory = $"{Directory.GetCurrentDirectory()}{sep}rvloader{sep}covers";
                Directory.CreateDirectory(destinationDirectory);
                string fileName = $"{destinationDirectory}{sep}{gameId}.{imageFormat}";
                Console.Write($"Downloaded cover for {gameId}...");
                try
                {
                    client.DownloadFile(new Uri(BuildDownloadUrl(gameId)), fileName);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error! {e.Message}");
                    return;
                }
                Console.WriteLine("Done");
            }
        }

        public static void DownloadCovers(string[] gameIds)
        {
            foreach (string id in gameIds)
            {
                DownloadCover(id);
            }
        }

        private static string BuildDownloadUrl(string gameId)
        {
            return $"{baseUrl}/{platform}/{coverType}/{region}/{gameId}.{imageFormat}";
        }
    }
}