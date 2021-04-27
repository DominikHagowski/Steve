using System;
using System.Collections.Generic;
using System.Text;

namespace Steve
{
    interface Application
    {
        public int Start();
        public status Update();
        public int Close();
        static void RunApplication(Application Target)
        {
            while (true)
            {
                Target.Start();
                bool close = false;
                while (!close)
                {
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo input = Console.ReadKey(false);
                        if (input.Key == ConsoleKey.Escape)
                        {
                            return;
                        }
                    }

                    switch (Target.Update())
                    {
                        case (status.error): return;
                        case (status.keeprunning): continue;
                        case (status.close): close = true;
                            break;
                    }
                }
                Target.Close();
            }
        }
    }

    public enum status
    {
        close, 
        keeprunning,
        error
    }


}
