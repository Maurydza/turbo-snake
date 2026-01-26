namespace rocket_propelled_grenade
{
    class Drawable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string? Image { get; set; }

        public Drawable(int x, int y, string? image)
        {
            X = x;
            Y = y;
            Image = image;
        }
    }
}
