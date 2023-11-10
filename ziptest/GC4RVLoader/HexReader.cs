using System;
using System.IO;
using System.Text;

namespace GC4RVLoader
{
    public class HexReader
    {
        public static string ReadBytes(string filePath, int bytesToRead)
        {
            FileStream fileStream = new FileStream(filePath, FileMode.Open);
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < bytesToRead; i++)
            {
                stringBuilder.Append($"{fileStream.ReadByte():X2}");
            }
            fileStream.Close();
            return stringBuilder.ToString();
        }
        
        public static byte[] FromHex(string hex)
        {
            byte[] raw = new byte[hex.Length / 2];
            for (int i = 0; i < raw.Length; i++)
            {
                raw[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }
            return raw;
        }

        public static string DecodeHex(string hex)
        {
            byte[] data = FromHex(hex);
            string decoded = Encoding.ASCII.GetString(data);
            return decoded;
        }
    }
}