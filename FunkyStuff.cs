using System.Drawing;

namespace rocket_propelled_grenade
{
    class FunkyStuff
    {
        public static void FlashColors(int duration, int speed, string text, bool doBeep = false)
        {
            List<ConsoleColor> colors = [ConsoleColor.Black, ConsoleColor.Blue, ConsoleColor.Cyan, ConsoleColor.DarkBlue, ConsoleColor.DarkCyan, ConsoleColor.DarkGray, ConsoleColor.DarkGreen, ConsoleColor.DarkMagenta, ConsoleColor.DarkRed, ConsoleColor.DarkYellow, ConsoleColor.Gray, ConsoleColor.Green, ConsoleColor.Magenta, ConsoleColor.Red, ConsoleColor.White, ConsoleColor.Yellow];
            Random random = new();

            Console.Clear();

            if (doBeep)
            {
                for (int i = 0; i < duration; i++)
                {
                    Console.BackgroundColor = colors[random.Next(0, colors.Count)];
                    Console.ForegroundColor = colors[random.Next(0, colors.Count)];
                    Console.Clear();
                    Console.Write(text);
                    Console.Beep(random.Next(200, 2000), speed);
                }
            }
            else
            {
                for (int i = 0; i < duration; i++)
                {
                    Console.BackgroundColor = colors[random.Next(0, colors.Count)];
                    Console.ForegroundColor = colors[random.Next(0, colors.Count)];
                    Console.Clear();
                    Console.WriteLine(text);
                    Thread.Sleep(speed);
                }
            }

            Console.ResetColor();
            Console.Clear();
        }

        public static void BasicLoad(int duration, int speed, string text)
        {
            for (int i = 0; i < duration; i++)
            {
                Console.Write($"/ {text}");
                Thread.Sleep(speed);
                Console.Clear();
                Console.Write($"- {text}");
                Thread.Sleep(speed);
                Console.Clear();
                Console.Write($"\\ {text}");
                Thread.Sleep(speed);
                Console.Clear();
                Console.Write($"| {text}");
                Thread.Sleep(speed);
                Console.Clear();
            }
        }

        public static void RandomBeep(int duration, int speed, int minFrequency = 200, int maxFrequency = 2000)
        {
            Random random = new();
            for (int i = 0; i < duration; i++)
            {
                Console.Beep(random.Next(minFrequency, maxFrequency), speed);
            }
        }
    }
}
