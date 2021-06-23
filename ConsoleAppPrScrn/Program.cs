using System;
using System.IO;
using System.Runtime.InteropServices;

namespace ConsoleAppPrScrn
{
    class Program
    {
        [DllImport("PrScrn.dll")]
        private static extern int PrScrn();

        static void Main(string[] args)
        {
            try
            {
                int i = PrScrn();
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ScreenCaptrue.txt");
                File.WriteAllText(path, i.ToString());
            }
            catch
            {
            }
        }
    }
}
