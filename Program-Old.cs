using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steve
{
    namespace Applications
    {
        public class applications
        {
            struct Element
            {
                public string Name;
                public string Symbol;
                public decimal AtomicWeight;
                public string Group;
            }


            public static int Add(Stream Input)
            {
                Graphics.ConsoleWriter ConsoleOut = new Graphics.ConsoleWriter("Add");

                long Current = 0;
                long Temp = 0;
                string InputNumber = "";

                ConsoleOut.WriteLine("Type numbers to add together.", 9);
                ConsoleOut.WriteLine("Type End in order to go back.", 10);

                do
                {
                    Int64.TryParse(InputNumber, out Temp);
                    Current += Temp;
                    ConsoleOut.WriteLine(Current.ToString(), 7);
                    ConsoleOut.Draw();
                    InputNumber = Console.ReadLine();
                } while (InputNumber.ToLower() != "end");


                    return 0;
            }

            public static int Average(Stream Input)
            {
                Graphics.ConsoleWriter ConsoleOut = new Graphics.ConsoleWriter("Average");

                ConsoleOut.WriteLine("Type numbers to find their average.", 9);
                ConsoleOut.WriteLine("Type end in order to go back.", 10);

                double Total = 0;
                int Amount = 0;
                double temp = 0;
                string InputScore = "";
                do
                {
                    double.TryParse(InputScore, out temp);
                    Total += temp;
                    ConsoleOut.WriteLine((Total / Amount).ToString(), 8);
                    ConsoleOut.Draw();
                    InputScore = Console.ReadLine();
                    Amount += 1;
                } while (InputScore.ToLower() != "end");

                return 0;
            }

            public static int ConvertTemp(Stream Input)
            {
                Graphics.ConsoleWriter ConsoleOut = new Graphics.ConsoleWriter("Converter");

                string InputTemp = "32";
                double temp = 0;

                ConsoleOut.WriteLine("Type a temperiture in Fahrenheit to see it in Centigrade", 9);
                ConsoleOut.WriteLine("Type end in order to go back.", 10);

                do
                {
                    double.TryParse(InputTemp, out temp);
                    ConsoleOut.WriteLine((((temp - 32) * 5) / 9).ToString() + " Centigrade", 8);
                    ConsoleOut.Draw();
                    InputTemp = Console.ReadLine();
                } while (InputTemp.ToLower() != "end");

                return 0;
            }

            public static int Queue(Stream input)
            {
                return 0;
            }

            public static int HeightAndWeight(Stream Input)
            {
                Graphics.ConsoleWriter ConsoleOut = new Graphics.ConsoleWriter("Convert Height and Weight");

                string TextInput = "";

                Graphics.Menu InputMenu = new Graphics.Menu();

                double Height = 0;
                double Weight = 0;
                double Temp = 0;

                ConsoleOut.MakeMenu(InputMenu);

                Graphics.UIObject HeightInput = new Graphics.UIObject("Input Height", ConsoleOut.XOffset("Input Height".Length),  9, null);
                Graphics.UIObject WeightInput = new Graphics.UIObject("Input Weight", ConsoleOut.XOffset("Input Weight".Length), 10, null);
                Graphics.UIObject QuitButton = new Graphics.UIObject("Go Back", ConsoleOut.XOffset("Go Back".Length), 11, null);

                InputMenu.AddItem(HeightInput);
                InputMenu.AddItem(WeightInput);
                InputMenu.AddItem(QuitButton);

                bool Quit = false;

                ConsoleKeyInfo InputKey;

                do
                {
                    ConsoleOut.WriteLine("Weight: " + (Weight * 6.364).ToString() + "Kg Height: " + (Height * 2.54).ToString() + "cm ", 7);

                    ConsoleOut.Draw();
                    InputKey = Console.ReadKey();
                    switch (InputKey.Key)
                    {
                        case ConsoleKey.UpArrow:
                            InputMenu.ChangeSelected(-1);
                            break;
                        case ConsoleKey.DownArrow:
                            InputMenu.ChangeSelected(1);
                            break;
                        case ConsoleKey.Enter:
                            {
                                if (InputMenu.GetSelected().Content == "Go Back")
                                {
                                    Quit = true;
                                }
                                else if(InputMenu.GetSelected().Content == "Input Height")
                                {
                                    TextInput = Console.ReadLine();
                                    double.TryParse(TextInput, out Temp);
                                    Height = Temp;
                                }
                                else
                                {
                                    TextInput = Console.ReadLine();
                                    double.TryParse(TextInput, out Temp);
                                    Weight = Temp;
                                }
                            }
                            break;
                    }
                } while (!Quit);

                return 0;
            }

            public static int WorkerPay(Stream Input)
            {
                Graphics.ConsoleWriter ConsoleOut = new Graphics.ConsoleWriter("Calculate Pay");

                string TextInput = "";

                Graphics.Menu InputMenu = new Graphics.Menu();

                double Cars = 0;
                double Hours = 0;
                double Temp = 0;

                ConsoleOut.MakeMenu(InputMenu);

                Graphics.UIObject HeightInput = new Graphics.UIObject("Input Hours", ConsoleOut.XOffset("Input Hours".Length), 9, null);
                Graphics.UIObject WeightInput = new Graphics.UIObject("Input Cars", ConsoleOut.XOffset("Input Cars".Length), 10, null);
                Graphics.UIObject QuitButton = new Graphics.UIObject("Go Back", ConsoleOut.XOffset("Go Back".Length), 11, null);

                InputMenu.AddItem(HeightInput);
                InputMenu.AddItem(WeightInput);
                InputMenu.AddItem(QuitButton);

                bool Quit = false;

                ConsoleKeyInfo InputKey;

                do
                {
                    ConsoleOut.WriteLine("Pay: " + (12 * Hours + 0.6 * Cars).ToString(),7);

                    ConsoleOut.Draw();
                    InputKey = Console.ReadKey();
                    switch (InputKey.Key)
                    {
                        case ConsoleKey.UpArrow:
                            InputMenu.ChangeSelected(-1);
                            break;
                        case ConsoleKey.DownArrow:
                            InputMenu.ChangeSelected(1);
                            break;
                        case ConsoleKey.Enter:
                            {
                                if (InputMenu.GetSelected().Content == "Go Back")
                                {
                                    Quit = true;
                                }
                                else if (InputMenu.GetSelected().Content == "Input Hours")
                                {
                                    TextInput = Console.ReadLine();
                                    double.TryParse(TextInput, out Temp);
                                    Hours = Temp;
                                }
                                else
                                {
                                    TextInput = Console.ReadLine();
                                    double.TryParse(TextInput, out Temp);
                                    Cars = Temp;
                                }
                            }
                            break;
                    }
                } while (!Quit);

                return 0;
            }

            public static int ElementLookup(Stream Input)
            {
                Graphics.ConsoleWriter ConsoleOut = new Graphics.ConsoleWriter("Elements");


                string path = @"C:\Users\hag19002983\OneDrive - Wakefield College\Steve\Steve_Resources\Elements.txt";

                List<Element> Elements = new List<Element>();

                FileStream ElementsFile = File.OpenRead(path);

                byte[] FileBuffer = new byte[ElementsFile.Length];

                ElementsFile.Read(FileBuffer, 0, (int)ElementsFile.Length);

                string FileLine = System.Text.Encoding.Default.GetString(FileBuffer);
                string[] FileLines = FileLine.Split('\n');

                //System.Windows.Forms.MessageBox.Show(FileLines[1].ToString());

                string InputText = "";

                for (int i = 0; i < 19; i+= 4)
                {
                    Element TempElement = new Element();
                    TempElement.Name = FileLines[i].ToString();
                    TempElement.Symbol = FileLines[i + 1].ToString();
                    TempElement.AtomicWeight = Convert.ToDecimal(FileLines[i + 2].ToString());
                    TempElement.Group = FileLines[i + 3].ToString();
                    Elements.Add(TempElement);
                }
                
                do
                {
                    ConsoleOut.Draw();
                    
                    InputText = Console.ReadLine();
                } while (InputText.ToLower() != "end");
                
                //0 4 8 12 16 20

                return 0;
            }

            public static int RogueLike(Stream SInput)
            {
                Graphics.ConsoleWriter ConsoleOut = new Graphics.ConsoleWriter("Roguelike");

                string path = @"C:\Users\hag19002983\OneDrive - Wakefield College\Steve\Steve_Resources\TEST.txt";

                FileStream MPFile = File.OpenRead(path);

                byte[] FileBuffer = new byte[MPFile.Length];

                MPFile.Read(FileBuffer, 0, (int)MPFile.Length);

                string Temp = System.Text.Encoding.Default.GetString(FileBuffer);

                string[] MPFileArray = new string[30];

                MPFileArray[0] = "";

                bool Quit = false;

                int J = 1;
                foreach(string Str in Temp.Split('\n'))
                {
                    MPFileArray[J] = Str;
                    J++;
                }

                //System.Windows.Forms.MessageBox.Show(MPFileArray[0]);

                for (int i = 1; i < 30; i++)
                {
                    
                    ConsoleOut.WriteLine(MPFileArray[i], i);
                    ConsoleOut.SetForeground(i, ConsoleColor.Green);
                }

                Graphics.UIObject Character = new Graphics.UIObject("AB\nCD", 30, 15);

                ///Character.Background = ConsoleColor.Green;
                //Character.Foreground = ConsoleColor.;

                ConsoleOut.MakeObject(Character);

                ConsoleKeyInfo Input;

                while (!Quit)
                {
                    ConsoleOut.Draw();
                    Input = Console.ReadKey();
                    switch (Input.Key)
                    {
                        case (ConsoleKey.UpArrow): Character.ChangeY(-1);
                            break;
                        case (ConsoleKey.DownArrow): Character.ChangeY(1);
                            break;
                        case (ConsoleKey.RightArrow): Character.ChangeX(1);
                            break;
                        case (ConsoleKey.LeftArrow): Character.ChangeX(-1);
                            break;
                        case (ConsoleKey.Escape): Quit = true;
                            break;
                    }
                }
                return 0;
            }

            public static int DirActivity01(Stream Input)
            {


            Graphics.ConsoleWriter ConsoleOut = new Graphics.ConsoleWriter("Program");

            ConsoleKeyInfo input;

            Graphics.Menu MainMenu = new Graphics.Menu();

            ConsoleOut.MakeMenu(MainMenu);


            string Text = "";

            Text = "Add";
            MainMenu.AddItem(new Graphics.UIObject(Text, ConsoleOut.XOffset(Text.Length), 7, Applications.applications.Add));
            Text = "Average";
            MainMenu.AddItem(new Graphics.UIObject(Text, ConsoleOut.XOffset(Text.Length), 8, Applications.applications.Average));
            Text = "Convert Temperature";
            MainMenu.AddItem(new Graphics.UIObject(Text, ConsoleOut.XOffset(Text.Length), 9, Applications.applications.ConvertTemp));
            Text = "Convert Height and Weight";
            MainMenu.AddItem(new Graphics.UIObject(Text, ConsoleOut.XOffset(Text.Length), 10, Applications.applications.HeightAndWeight));
            Text = "Calculate Pay";
            MainMenu.AddItem(new Graphics.UIObject(Text, ConsoleOut.XOffset(Text.Length), 11, Applications.applications.WorkerPay));
            Text = "Queue";
            MainMenu.AddItem(new Graphics.UIObject(Text, ConsoleOut.XOffset(Text.Length), 12, Applications.applications.Queue));
            Text = "Go Back";
            MainMenu.AddItem(new Graphics.UIObject(Text, ConsoleOut.XOffset(Text.Length), 13, null));

                bool quit = false;
            while (!quit)
            {
                ConsoleOut.Draw();
                
                input = Console.ReadKey(false);
                switch (input.Key)
                {
                    case ConsoleKey.UpArrow: MainMenu.ChangeSelected(-1);
                        break;
                    case ConsoleKey.DownArrow: MainMenu.ChangeSelected(1);
                        break;
                    case ConsoleKey.Enter: if (MainMenu.GetSelected().Content == "Go Back")
                            {
                                quit = true;
                            }
                            else
                            {
                                MainMenu.Activate(null);
                            }
                            break;
                }
            }

                return 0;

        }

            public static int DirActivity02(Stream Input)
            {


                Graphics.ConsoleWriter ConsoleOut = new Graphics.ConsoleWriter("Program");

                ConsoleKeyInfo input;

                Graphics.Menu MainMenu = new Graphics.Menu();

                ConsoleOut.MakeMenu(MainMenu);


                string Text = "";

                Text = "Element lookup";
                MainMenu.AddItem(new Graphics.UIObject(Text, ConsoleOut.XOffset(Text.Length), 7, ElementLookup));
                Text = "Go Back";
                MainMenu.AddItem(new Graphics.UIObject(Text, ConsoleOut.XOffset(Text.Length), 8, null));

                bool quit = false;
                while (!quit)
                {
                    ConsoleOut.Draw();

                    input = Console.ReadKey(false);
                    switch (input.Key)
                    {
                        case ConsoleKey.UpArrow:
                            MainMenu.ChangeSelected(-1);
                            break;
                        case ConsoleKey.DownArrow:
                            MainMenu.ChangeSelected(1);
                            break;
                        case ConsoleKey.Enter:
                            if (MainMenu.GetSelected().Content == "Go Back")
                            {
                                quit = true;
                            }
                            else
                            {
                                MainMenu.Activate(null);
                            }
                            break;
                    }
                }

                return 0;

            }

            public static int DirPersonal(Stream Input)
            {


                Graphics.ConsoleWriter ConsoleOut = new Graphics.ConsoleWriter("Program");

                ConsoleKeyInfo input;

                Graphics.Menu MainMenu = new Graphics.Menu();

                ConsoleOut.MakeMenu(MainMenu);


                string Text = "";

                Text = "RogueLike";
                MainMenu.AddItem(new Graphics.UIObject(Text, ConsoleOut.XOffset(Text.Length), 7, RogueLike));
                Text = "Go Back";
                MainMenu.AddItem(new Graphics.UIObject(Text, ConsoleOut.XOffset(Text.Length), 8, null));

                bool quit = false;
                while (!quit)
                {
                    ConsoleOut.Draw();

                    input = Console.ReadKey(false);
                    switch (input.Key)
                    {
                        case ConsoleKey.UpArrow:
                            MainMenu.ChangeSelected(-1);
                            break;
                        case ConsoleKey.DownArrow:
                            MainMenu.ChangeSelected(1);
                            break;
                        case ConsoleKey.Enter:
                            if (MainMenu.GetSelected().Content == "Go Back")
                            {
                                quit = true;
                            }
                            else
                            {
                                MainMenu.Activate(null);
                            }
                            break;
                    }
                }

                return 0;

            }


        }
    }

    namespace Graphics
    {


        public class UIObject
        {
            public string Content;
            public int X;
            public int Y;
            public ConsoleColor Background;
            public ConsoleColor Foreground;

            public bool IsSelectable = false;

            public void ChangeX(int Change)
            {
                X += Change;
            }
            public void ChangeY(int Change)
            {
                Y += Change;
            }

            public void SetX(int NewX)
            {
                X = NewX;
            }
            public void SetY(int NewY)
            {
                Y = NewY;
            }

            public delegate int ObjectAction(Stream Input);//, ConsoleWriter Console);
            public ObjectAction ObjectActivate;

            public void SetColor(ConsoleColor NewBackground, ConsoleColor NewForeground)
            {
                Background = NewBackground;
                Foreground = NewForeground;
            }

            int stub(Stream Input) { return 0; }

            public UIObject(string Text, int InitialX, int InitialY, ObjectAction Action = null)
            {
                if(Action == null)
                {
                    ObjectActivate = stub;
                }
                else
                {
                    ObjectActivate = Action;
                }

                X = InitialX;
                Y = InitialY;
                Content = Text;
                Background = ConsoleColor.Black;
                Foreground = ConsoleColor.White;
            }
        }

        public class Menu
        {
            public List<UIObject> Items;
            int Position;

            public void AddItem(UIObject NewItem)
            {
                Items.Add(NewItem);
            }
            public void RemoveItem(UIObject OldItem)
            {
                if (Items.Contains(OldItem))
                {
                    Items.Remove(OldItem);

                }
            }

            public void ChangeSelected(int change)
            {
                MakeInactive(Position);

                Position += change;
                if (Position > Items.Count - 1) { Position = Items.Count - 1; }
                else if (Position < 0) { Position = 0; }

                MakeActive(Position);
            }

            public UIObject GetSelected()
            {
                return Items[Position];
            }

            public void Activate(Stream Input)
            {
                Items[Position].ObjectActivate(Input);
            }

            void MakeInactive(int Index)
            {
                Items[Index].SetColor(ConsoleColor.Black, ConsoleColor.White);
            }

            void MakeActive(int Index)
            {
                Items[Index].SetColor(ConsoleColor.DarkGreen, ConsoleColor.White);
            }

            public Menu()
            {
                Items = new List<UIObject>();
                Position = 0;
            }
        }

        //The class responsible for all output
        public class ConsoleWriter
        {
            struct Line //A line is a row of characters (represented by a string)
            {
                public ConsoleColor Background;
                public ConsoleColor Foreground;
                public string Content;
            }

            //The Icon Drawn at the top of the screen
            readonly string[] Icon = { "  ___ _                ", " / __| |_ _____ _____  ", " \\__ |  _/ -_\\ V / -_) ", " |___/\\__\\___|\\_/\\___| ", "The omnipotent program!" };

            //Makes a List of the objects and an array of lines
            List<UIObject> UIObjects = new List<UIObject>();
            List<Menu> Menus = new List<Menu>(); // Sets a list of menus so that there can be more then one.
            Line[] ConsoleOutput = new Line[30];

            public int XOffset(int length)
            {
                return (60 - length) / 2;
            }

            public void SetBackground(int Y, ConsoleColor Colour)
            {
                ConsoleOutput[Y].Background = Colour;
            } //sets the background colour of a line

            public void SetForeground(int Y, ConsoleColor Colour)
            {
                ConsoleOutput[Y].Foreground = Colour;
            }//sets the foreground colour of a line

            public void Draw() //Draws the screen
            {

                Console.Clear();

                Console.SetWindowSize(60, 30);
                Console.SetBufferSize(60, 30);

                int heightOffset = 0;
                int length = 0;
                int widthOffset = 0;

                foreach (Line Row in ConsoleOutput) //This centers the text and draws it to the screen
                {
                    length = Row.Content.Length;
                    widthOffset = (Console.BufferWidth - length) / 2;
                    Console.SetCursorPosition(widthOffset, heightOffset);
                    Console.BackgroundColor = Row.Background;
                    Console.ForegroundColor = Row.Foreground;
                    Console.Write(Row.Content);
                    heightOffset += 1;
                }

                foreach (UIObject Object in UIObjects) //This draws the objects to the screen
                {
                    try
                    {
                        Console.SetCursorPosition(Object.X, Object.Y);
                        Console.BackgroundColor = Object.Background;
                        Console.ForegroundColor = Object.Foreground;
                        Console.Write(Object.Content);
                    }
                    catch
                    {
                        break;
                    }
                }
                foreach (Menu MenuObject in Menus) //This draws the objects to the screen
                {
                    foreach (UIObject Object in MenuObject.Items)
                    {
                        try
                        {
                            Console.SetCursorPosition(Object.X, Object.Y);
                            Console.BackgroundColor = Object.Background;
                            Console.ForegroundColor = Object.Foreground;
                            Console.Write(Object.Content);
                        }
                        catch
                        {
                            break;
                        }
                    }
                }
                Console.ResetColor(); //resets the coloursas as to not intefere with the next draw
            }

            public void MakeObject(UIObject Object)
            {
                UIObjects.Add(Object);
            } //Adds a new object to the list
            public void DeleteObjects(UIObject Object)
            {
                if (UIObjects.Contains(Object))
                {
                    UIObjects.Remove(Object);
                }
            }//Removes an object from the list

            public void MakeMenu(Menu NewMenu)
            {
                Menus.Add(NewMenu);
            } //Adds a new object to the list

            public void WriteLine(string NewLine, int y)
            {
                ConsoleOutput[y].Content = NewLine;
            }

            public ConsoleWriter(string Title)
            {
                Console.CursorVisible = false;

                Console.Title = Title;

                Console.SetWindowSize(60, 30);
                Console.SetBufferSize(60, 30);

                for (int i = 0; i < 30; i++)
                {
                    ConsoleOutput[i].Content = " ";
                    ConsoleOutput[i].Background = ConsoleColor.Black;
                    ConsoleOutput[i].Foreground = ConsoleColor.White;
                }
                for (int i = 1; i < 6; i++)
                {
                    ConsoleOutput[i].Content = Icon[i - 1];
                    ConsoleOutput[i].Foreground = ConsoleColor.DarkCyan;
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Graphics.ConsoleWriter ConsoleOut = new Graphics.ConsoleWriter("Program");

            ConsoleKeyInfo input;

            Graphics.Menu MainMenu = new Graphics.Menu();

            ConsoleOut.MakeMenu(MainMenu);


            string Text = "";

            Text = "Activity 01";
            MainMenu.AddItem(new Graphics.UIObject(Text, ConsoleOut.XOffset(Text.Length), 7, Applications.applications.DirActivity01));
            Text = "Activity 02";
            MainMenu.AddItem(new Graphics.UIObject(Text, ConsoleOut.XOffset(Text.Length), 8, Applications.applications.DirActivity02));
            Text = "Personal";
            MainMenu.AddItem(new Graphics.UIObject(Text, ConsoleOut.XOffset(Text.Length), 9, Applications.applications.DirPersonal));

            bool quit = false;
            while (!quit)
            {
                ConsoleOut.Draw();
                //if (Console.KeyAvailable) {
                input = Console.ReadKey(false);
                switch (input.Key)
                {
                    case ConsoleKey.UpArrow: MainMenu.ChangeSelected(-1);
                        break;
                    case ConsoleKey.DownArrow: MainMenu.ChangeSelected(1);
                        break;
                    case ConsoleKey.Enter: MainMenu.Activate(null);
                        break;
                }
                //}
            }
        }
    }
}

/*
TODO:
-Try to replace calls to the console with i/o streams
-Try to revert the title change when stepping back throuch menus
-Get error handling
-Make an easy way to make Menu Directories
-Put input handling into its own thing

*/