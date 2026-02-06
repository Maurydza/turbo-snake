namespace rocket_propelled_grenade
{
    class ScreenBuffer
    {
        private string[,] buffer;
        private int sizeX;
        private int sizeY;
        private int lastX;
        private int lastY;

        public ScreenBuffer(int sizeX_, int sizeY_)
        {
            sizeX = sizeX_;
            sizeY = sizeY_;
            buffer = new string[sizeX, sizeY];
            lastX = 0;
            lastY = 0;
        }

        private void NewLine()
        {
            lastY++;
            lastX = 0;

            if (lastY >= sizeY)
            {
                lastY = 0;
            }
        }

        public void Clear()
        {
            for (int i = 0; i < sizeY; i++)
            {
                for (int j = 0; j < sizeX; j++)
                {
                    buffer[j, i] = " ";
                }
            }

            lastX = 0;
            lastY = 0;
        }

        public void Push(string str)
        {
            foreach (char c in str)
            {
                if (c == '\n')
                {
                    NewLine();
                }
                else
                {
                    if (lastX >= sizeX)
                    {
                        NewLine();
                    }
                    buffer[lastX, lastY] = c.ToString();
                    lastX++;
                }
            }
        }

        public void Show()
        {
            for (int i = 0; i < sizeY; i++)
            {
                for (int j = 0; j < sizeX; j++)
                {
                    Console.SetCursorPosition(j, i);
                    Console.Write(buffer[j, i]);
                }
            }
        }
    }
}
