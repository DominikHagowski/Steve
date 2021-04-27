using System;
using System.Collections.Generic;
using System.Text;

namespace Steve
{
    class TestApplication : Application
    {
        Graphics.Console.ConsoleWriter ConsoleOutput;
        Graphics.Vector2 ScreenSize;
        Graphics.Console.Sprite h;
        Graphics.Vector2 Velocity = new Graphics.Vector2(1, 1);
        public int Start()
        {
            ScreenSize = new Graphics.Vector2(90, 30);
            ConsoleOutput = new Graphics.Console.ConsoleWriter(ScreenSize);

            for (int i = 0; i < 10; i++)
            {
                ConsoleOutput.Screen[12, i].Character = (char)(i + 97);
            }

            for (int i = 0; i < 90; i++)
            {
                ConsoleOutput.Screen[i, 15].Character = (char)((i % 20) + 97);
            }

            h = new Graphics.Console.Sprite("This\nIs\nA\nMulti-Line\n        Sprite", new Graphics.Vector2(10, 20), ConsoleColor.Black, ConsoleColor.Cyan);
            h.Size = new Graphics.Vector2(15, 10);

            ConsoleOutput.Sprites.Add(h);
            ConsoleOutput.Screen[0, 10].Character = 'O';
            ConsoleOutput.Screen[0, 10].Background = ConsoleColor.Red;
            ConsoleOutput.Screen[0, 10].Forground = ConsoleColor.Yellow;

            return 0;
        }

        public status Update()
        {
            ConsoleOutput.Draw();
            h.Update = false;
            ConsoleOutput.Screen[0, 10].Update = true;
            h.ChangePosition(Velocity);

            if (h.Position.X < 0 || h.Position.X >= ScreenSize.X - 14)
            {
                Velocity.X *= -1;
            }

            if (h.Position.Y < 0 || h.Position.Y >= ScreenSize.Y - 4)
            {
                Velocity.Y *= -1;
            }
           System.Threading.Thread.Sleep(10);
           return status.keeprunning;
        }

        public int Close()
        {
            return 0;
        }
    }
}
