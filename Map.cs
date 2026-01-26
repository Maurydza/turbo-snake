namespace rocket_propelled_grenade
{
    class Map
    {
        public int SizeX { get; set; }
        public int SizeY { get; set; }
        public string? EmptyField { get; set; }
        protected Drawable[,] MapFields;

        public Map(int sizeX, int sizeY, string? emptyField)
        {
            SizeX = sizeX;
            SizeY = sizeY;
            EmptyField = emptyField;
            MapFields = new Drawable[SizeX, SizeY];
        }

        public void CreateEmpty()
        {
            for (int i = 0; i < SizeY; i++)
            {    
                for (int j = 0; j < SizeX; j++)
                {
                    MapFields[j,i] = new Drawable(i, j, EmptyField);
                }
            }
        }
        
        public void Draw()
        {
            for (int i = 0; i < SizeY; i++)
            {
                for (int j = 0; j < SizeX; j++)
                {
                    Console.Write(MapFields[j, i].Image);
                }
                Console.WriteLine();
            }
        }

        public void ClearPlayer(Player player)
        {
            foreach (Drawable block in player.Blocks)
            {
                MapFields[block.X, block.Y].Image = EmptyField;
            }
        }

        public void RenderPlayer(Player player)
        {
            foreach (Drawable block in player.Blocks)
            {
                MapFields[block.X, block.Y].Image = block.Image;
            }
        }

        public void RenderFruit(Fruit fruit)
        {
            MapFields[fruit.Drawable.X, fruit.Drawable.Y].Image = fruit.Image;
        }
    }
}
