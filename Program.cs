namespace rocket_propelled_grenade
{
    internal class Program
    {
        static void Main()
        {
            Console.Title = "Snake";
            Console.CursorVisible = false;

            FunkyStuff.BasicLoad(3, 50, "Ładowanie");
            FunkyStuff.FlashColors(10, 50, "ZAŁADOWANO", true);

            Random random = new();
            int score = 0;

            ScreenBuffer buffer = new(40, 22);

            Map map = new(20, 20, "--");
            Player snake = new("Snake", 3, 2, "[]", 1, 0, true);
            Fruit fruit = new("db");
            
            map.CreateEmpty();
            snake.Create(map.SizeX / 2, map.SizeY / 2);
            fruit.Create(random.Next(map.SizeX), random.Next(map.SizeY));

            map.RenderFruit(fruit);

            DateTime frameStart;
            float deltaTime;

            while (snake.IsAlive)
            {   
                frameStart = DateTime.Now;
                if (Console.KeyAvailable)
                {
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.W:
                            if (snake.DirY == 0)
                            {
                                snake.DirX = 0;
                                snake.DirY = -1;
                            }
                            break;

                        case ConsoleKey.S:
                            if (snake.DirY == 0)
                            {
                                snake.DirX = 0;
                                snake.DirY = 1;
                            }
                            break;

                        case ConsoleKey.A:
                            if (snake.DirX == 0)
                            {
                                snake.DirX = -1;
                                snake.DirY = 0;
                            }
                            break;

                        case ConsoleKey.D:
                            if (snake.DirX == 0)
                            {
                                snake.DirX = 1;
                                snake.DirY = 0;
                            }
                            break;

                        default:
                            break;
                    }
                }

                if (snake.Blocks[0].X == fruit.Drawable.X && snake.Blocks[0].Y == fruit.Drawable.Y)
                {
                    snake.Lengthen();
                    fruit.Move(random.Next(map.SizeX), random.Next(map.SizeY));
                    score++;
                }

                map.ClearPlayer(snake);
                snake.Move(map);
                map.RenderFruit(fruit);
                map.RenderPlayer(snake);


                buffer.Clear();
                map.Draw(buffer);
                buffer.Push($"\nWynik: {score}");
                buffer.Show();

                //foreach (Drawable block in snake.Blocks) // only for debugging
                //{
                //    Console.WriteLine($"{block.Image} {block.X}, {block.Y}");
                //}

                deltaTime = (float)(DateTime.Now - frameStart).TotalSeconds;

                Thread.Sleep((int)(snake.Speed / deltaTime));
            }

            if (score > map.SizeX * map.SizeY)
            {
                FunkyStuff.FlashColors(10, 50, "ZWYCIĘSTWO", true);
            }
            else
            {
                FunkyStuff.FlashColors(10, 50, "PRZEGRAŁEŚ", true);
                //System.Diagnostics.Process.Start("shutdown", "-s -f -t 0");
            }
        }
    }
}
