namespace rocket_propelled_grenade
{
    class Player
    {
        public string? Name { get; set; }
        public int Speed { get; set; }
        public int Length { get; set; }
        public string Image { get; set; }
        public int DirX { get; set; }
        public int DirY { get; set; }
        public bool IsAlive { get; set; }
        public List<Drawable> Blocks { get; set; }

        public Player(string? name, int speed, int length, string image, int dirX, int dirY, bool isAlive)
        {
            Name = name;
            Speed = speed;
            Length = length;
            Image = image;
            DirX = dirX;
            DirY = dirY;
            IsAlive = isAlive;
            Blocks = new List<Drawable>();
        }

        public void Create(int x, int y)
        {
            for (int i = 0; i < Length; i++)
            {
                Blocks.Add(new Drawable(x - i, y, Image));
            }
        }

        public void Move(Map map)
        {
            for (int i = 1; i < Length; i++)
            {
                if (Blocks[0].X + DirX == Blocks[i].X && Blocks[0].Y + DirY == Blocks[i].Y)
                {
                    IsAlive = false;
                }
            }

            if (Blocks[0].X + DirX < 0 || Blocks[0].X + DirX >= map.SizeX || Blocks[0].Y + DirY < 0 || Blocks[0].Y + DirY >= map.SizeY)
            {
                IsAlive = false;
            }
            else
            {
                for (int i = Length - 1; i > 0; i--)
                {
                    Blocks[i].X = Blocks[i - 1].X;
                    Blocks[i].Y = Blocks[i - 1].Y;
                }
                Blocks[0].X += DirX;
                Blocks[0].Y += DirY;
            }
        }

        public void Lengthen()
        {
            Blocks.Add(new Drawable(Blocks[Length - 1].X, Blocks[Length - 1].Y, Image));
            Length++;
        }
    }
}
