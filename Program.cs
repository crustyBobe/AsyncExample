using System;
using System.IO;
using System.Threading.Tasks;

namespace AsyncExample
{
    class Program
    {
        static void Main(string[] args)
        {
            SlowCounter();
            DewIt();
            AlsoSlower();

        }

        public static async void DewIt()
        {
            Task<int> readTask = ReadFile();
            int characters = await ReadFile();
            Console.WriteLine("Number of characters is: " + characters);
        }

        public static async Task SlowCounter()
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < 1000; i++)
                {
                    Console.WriteLine("Still counting");
                    Task.Delay(1000).Wait();
                }
            }
            );
        }

        public static void AlsoSlower()
        {
            for(int i = 0; i < 1000; i++)
            {
                Console.WriteLine("Keep going along");
                Task.Delay(100).Wait();
            }
        }

        public static async Task<int> ReadFile()
        {
            int numChar = 0;

            Console.WriteLine("Reading band names");
            using(StreamReader reader = new StreamReader("metal_bands_2017.csv"))
            {
                string s = await reader.ReadToEndAsync();
                numChar = s.Length;
            }

            return numChar;
        }
    }
}
