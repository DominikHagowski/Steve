using System;
using System.Collections.Generic;
using System.Text;

namespace Steve
{
    class App_menu : Application
    {
        Graphics.Console.ConsoleWriter ConsoleOutput;
        Graphics.Vector2 ScreenSize;

        List<Application> Applications;
        List<Graphics.Console.Sprite> Sprites = new List<Graphics.Console.Sprite>();

        Graphics.Vector2 Position;
        uint index = 0;

        public int Start()
        {
            ScreenSize = new Graphics.Vector2(90, 30);
            ConsoleOutput = new Graphics.Console.ConsoleWriter(ScreenSize);

            int y = 0;

            foreach (Application App in Applications){
                y++;
                Graphics.Console.Sprite TempSprite = new Graphics.Console.Sprite(App.GetType().Name, new Graphics.Vector2((int)Position.X, (int)Position.Y + y));
                ConsoleOutput.Sprites.Add(TempSprite);
                Sprites.Add(TempSprite);
            }
            return 0;
        }

        public status Update()
        {

         

            Sprites[(int)(index % Sprites.Count)].BackGround = ConsoleColor.Black;

                ConsoleKeyInfo input = Console.ReadKey(false);
                switch (input.Key)
                {
                    case ConsoleKey.UpArrow:
                        index--;
                        break;
                    case ConsoleKey.DownArrow:
                        index++;
                        break;
                    case ConsoleKey.Enter:
                        Application.RunApplication(Applications[(int)(index % Sprites.Count)]);
                    ConsoleOutput.DrawArea(new Graphics.Quad(0, 0, (int)ScreenSize.Y, (int)ScreenSize.X));
                        break;

                }
            

            Sprites[(int)(index % Sprites.Count)].BackGround = ConsoleColor.Red;

            ConsoleOutput.Draw();
            return status.keeprunning;
        }

        public int Close()
        {
            return 0;
        }

        public App_menu(List<Application> Appsin, Graphics.Vector2 Posin)
        {
            Applications = Appsin;
            Position = Posin;
        }
    }
}
