using System;
using System.Collections.Generic;
using System.Text;

namespace Steve
{
    namespace Graphics
    {
        public struct Vector2
        {
            public double X;
            public double Y;

            public Vector2(int inx, int iny)
            {
                X = inx;
                Y = iny;
            }
        }

        public struct Quad
        {
            public double X;
            public double Y;
            public double W;
            public double H;

            public Quad(int inx, int iny, int inh, int inw)
            {
                X = inx;
                Y = iny;
                W = inw;
                H = inh;
            }
        }

        namespace Console
        {
            public struct ConsoleCharacter //The character type of each character on the screen
            {
                public bool Update; //Should the character be drawn
                public char Character; //What is the actual character
                public ConsoleColor Background; //Background colour
                public ConsoleColor Forground; //Foreground colour
            }

            public class Sprite
            {
                public string Graphic; //The characters making up the string
                public ConsoleColor BackGround; //Background colour
                public ConsoleColor ForeGround; //Foreground colour
                public Vector2 Position; //Position on the screen
                public Vector2 OldPosition; //The previous position on the screen
                public Vector2 Size; //The size of the sprite
                public bool Update; //If the sprite should be updated

                //Changes position by a certain vector2
                public void ChangePosition(Vector2 Difference)
                {
                    Update = true; //redraw the sprite
                    OldPosition = Position;
                    Position.X += Difference.X;
                    Position.Y += Difference.Y;
                }

                //Sets position to a certain vertor2
                public void SetPosition(Vector2 NewPosition)
                {
                    Update = true; //redraw the sprite
                    OldPosition = Position;
                    Position = NewPosition;
                }

                public Sprite(string InitialGraphic, Vector2 InitialPosition, ConsoleColor Back = ConsoleColor.Black, ConsoleColor Fore = ConsoleColor.White)
                {
                    Position = InitialPosition;
                    Graphic = InitialGraphic;
                    BackGround = Back;
                    ForeGround = Fore;
                    bool Update = true;
                }
            }

            //The class responsible for drawing to the screen
            public class ConsoleWriter
            {
                //The grid of characters that make up the console
                public ConsoleCharacter[,] Screen;
                //A list of sprites
                public List<Sprite> Sprites = new List<Sprite>();
                //Size of the terminal
                Vector2 ScreenSize;

                //Should the entire screen be redrawn
                public bool RedrawScreen = true;

                public void DrawArea(Quad Area)
                {

                    //for each character in the screen
                    for (int y = (int)Area.Y; y < ((int)Area.Y + (int)Area.H) - 1; y++)
                    {
                        for (int x = (int)Area.X; x < ((int)Area.X + (int)Area.W) - 1; x++)
                        {
                            //clear colours to default
                            System.Console.BackgroundColor = ConsoleColor.Black;
                            System.Console.ForegroundColor = ConsoleColor.White;
                            try
                            {
                                //Set cursor to position
                                System.Console.SetCursorPosition(x, y);

                                //set colour to character colour
                                System.Console.BackgroundColor = Screen[x, y].Background;
                                System.Console.ForegroundColor = Screen[x, y].Forground;

                                //write character
                                System.Console.Write(Screen[x, y].Character);

                                //doesnt need to be redrawn next frame until a change is made
                                Screen[x, y].Update = false;
                            }
                            catch
                            {
                                break;
                            }
                        }
                    }

                }

                //called every frame to draw the screen
                public void Draw()
                {

                    if (RedrawScreen == true)
                    {
                        DrawArea(new Quad(0, 0, (int)ScreenSize.Y, (int)ScreenSize.X));
                    }

                    //go through each sprite
                    foreach (Sprite S in Sprites)
                    {
                        if (S.Update == true)
                        {
                            DrawArea(new Quad((int)S.OldPosition.X, (int)S.OldPosition.Y, (int)S.Size.Y, (int)S.Size.X));
                        }
                        //and draw the ones that need updating
                        if (true)
                        {
                            //Would break if written outside the bounds, hence the try catch block. 
                            //TODO: remove this in the future
                            try
                            {
                                //set position to the sprite
                                System.Console.SetCursorPosition((int)S.Position.X, (int)S.Position.Y);

                                //set colour
                                System.Console.BackgroundColor = S.BackGround;
                                System.Console.ForegroundColor = S.ForeGround;

                                //split sprite into lines
                                String[] Lines = S.Graphic.Split('\n');

                                //Draw each line of the sprite
                                for (int i = 0; i < Lines.Length; i++)
                                {
                                    System.Console.SetCursorPosition((int)S.Position.X, (int)S.Position.Y + i);
                                    if (Lines[i].Length + S.Position.X >= ScreenSize.X - 1 || Lines.Length + S.Position.Y >= ScreenSize.Y - 1)
                                    {

                                    }
                                    else
                                    {
                                        System.Console.Write(Lines[i]);
                                    }
                                }
                            }
                            catch
                            {
                                break;
                            }
                            //dont need to update anymore
                            S.Update = true;
                        }
                    }
                    //reset cursor
                    System.Console.SetCursorPosition(0, 0);
                    //dont need to redraw screen
                    RedrawScreen = false;
                }

                public ConsoleWriter(Vector2 Size)
                {

                    System.Console.CursorVisible = false;
                    System.Console.SetWindowSize((int)Size.X, (int)Size.Y);
                    System.Console.SetBufferSize((int)Size.X, (int)Size.Y);
                    ScreenSize = Size;

                    Screen = new ConsoleCharacter[(int)Size.X, (int)Size.Y];

                    for (int y = 0; y < Size.Y; y++)
                    {
                        for (int x = 0; x < Size.X; x++)
                        {
                            Screen[x, y].Character = ' ';
                            Screen[x, y].Background = ConsoleColor.Black;
                            Screen[x, y].Forground = ConsoleColor.White;
                            Screen[x, y].Update = true;
                        }
                    }
                }
            }
        }
    }

}
