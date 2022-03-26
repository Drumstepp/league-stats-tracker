using System;
using System.Security.Cryptography;
using System.Text;

namespace Drumstepp.Common 
{
    public static class RgbExtension 
    {
        public static string ToRgbString(this string str) 
        {
            // var strHash = str.GetHashCode();
            // int r = (strHash & 0xFF0000) >> 16;
            // int g = (strHash & 0x00FF00) >> 8;
            // int b = (strHash & 0x0000FF);

            MD5 md5Hasher = MD5.Create();
            var hashed = md5Hasher.ComputeHash(Encoding.UTF8.GetBytes(str));
            var hashedInt = BitConverter.ToInt32(hashed, 0);

            var random = new Random(hashedInt);
            int r = random.Next(0,255);
            int g = random.Next(0,255);
            int b = random.Next(0,255);

            return $"rgb({r}, {g}, {b})";

        }
    }
}