namespace rocket_propelled_grenade
{
    class Fruit
    {
        public string Image { get; set; }
        public Drawable Drawable { get; set; }

        public Fruit(string image)
        {
            Image = image;
        }

        public void Create(int x, int y)
        {
            Drawable = new Drawable(x, y, Image);
        }

        public void Move(int x, int y)
        {
            Drawable.X = x;
            Drawable.Y = y;
        }
    }
}
