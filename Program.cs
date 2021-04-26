using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.CSharp;

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
                public bool Update; //If the sprite should be updated
                
                //Changes position by a certain vector2
                public void ChangePosition(Vector2 Difference) 
                {
                    Update = true; //redraw the sprite
                    Position.X += Difference.X;
                    Position.Y += Difference.Y;
                }

                //Sets position to a certain vertor2
                public void SetPosition(Vector2 NewPosition)
                {
                    Update = true; //redraw the sprite
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
                public bool RedrawScreen = false;

                //called every frame to draw the screen
                public void Draw()
                {
                    //clear console
                    System.Console.Clear();

                    //clear colours to default
                    System.Console.BackgroundColor = ConsoleColor.Black;
                    System.Console.ForegroundColor = ConsoleColor.White;

                    //for each character in the screen
                    for (int y = 0; y < ScreenSize.Y - 1; y++)
                    {
                        for (int x = 0; x < ScreenSize.X - 1; x++)
                        {
                            //clear colours to default
                            System.Console.BackgroundColor = ConsoleColor.Black;
                            System.Console.ForegroundColor = ConsoleColor.White;

                            //draw every character that needs to be redrawn
                            if (Screen[x, y].Update == true || RedrawScreen == true)
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
                        }

                        //go through each sprite
                        foreach (Sprite S in Sprites)
                        {
                            //and draw the ones that need updating
                            if (S.Update == false || RedrawScreen == true)
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
                                        System.Console.Write(Lines[i]);
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
                    
                    

                }

                public ConsoleWriter(Vector2 Size)
                {

                    System.Console.CursorVisible = false;
                    System.Console.SetWindowSize((int)Size.X, (int)Size.Y);
                    System.Console.SetBufferSize((int)Size.X, (int)Size.Y);
                    ScreenSize = Size;

                    Screen = new ConsoleCharacter[(int)Size.X, (int)Size.Y];

                    for(int y = 0; y < Size.Y; y++)
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

    class program
    {
        static void Main(string[] args)
        {
            Graphics.Vector2 Size;
            Size.X = 60;
            Size.Y = 30;


            var ConsoleOutput = new Graphics.Console.ConsoleWriter(Size);

            for(int i = 0; i < 10; i++)
            {
                ConsoleOutput.Screen[12, i].Character = (char)(i + 97);
            }

            Graphics.Console.Sprite h = new Graphics.Console.Sprite("This\nIs\nA\nMulti-Line\nSprite", new Graphics.Vector2(10, 20),ConsoleColor.Black, ConsoleColor.Cyan);

            ConsoleOutput.Sprites.Add(h);//
            ConsoleOutput.Screen[0, 10].Character = 'O';
            ConsoleOutput.Screen[0, 10].Background = ConsoleColor.Red;
            ConsoleOutput.Screen[0, 10].Forground = ConsoleColor.Yellow;
            while (true)
            {
                ConsoleOutput.Draw();
                h.Update = false;
                ConsoleOutput.Screen[0, 10].Update = true;
                ConsoleOutput.RedrawScreen = true;
                for (int i = 0; i < 10; i++)
                {
                    ConsoleOutput.Screen[12, i].Update = true;
                }
            }
        }
    }
}