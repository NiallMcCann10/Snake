using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowHeight = 24;
            Console.WindowWidth = 48;
            int screenwidth = Console.WindowWidth;
            int screenheight = Console.WindowHeight;
            Random randomnummer = new Random();
            int score = 5;
            int gameover = 0;
            pixel pix = new pixel();
            pix.possx = screenwidth / 2;
            pix.possy = screenheight / 2;
            pix.leader = ConsoleColor.Yellow;
            string movement = "UP";
            List<int> possxlijf = new List<int>();
            List<int> possylijf = new List<int>();
            int capturex = randomnummer.Next(0, screenwidth);
            int capturey = randomnummer.Next(0, screenheight);
            DateTime time = DateTime.Now;
            DateTime time2 = DateTime.Now;
            string buttonpressed = "no";
            while (true)
            {
                Console.Clear();
                if (pix.possx == screenwidth - 1 || pix.possx == 0 || pix.possy == screenheight - 1 || pix.possy == 0)
                {
                    gameover = 1;
                }
                for (int i = 0; i < screenwidth; i++)
                {
                    Console.SetCursorPosition(i, 0);
                    Console.Write("■");
                }
                for (int i = 0; i < screenwidth; i++)
                {
                    Console.SetCursorPosition(i, screenheight - 1);
                    Console.Write("■");
                }
                for (int i = 0; i < screenheight; i++)
                {
                    Console.SetCursorPosition(0, i);
                    Console.Write("■");
                }
                for (int i = 0; i < screenheight; i++)
                {
                    Console.SetCursorPosition(screenwidth - 1, i);
                    Console.Write("■");
                }
                Console.ForegroundColor = ConsoleColor.Green;
                if (capturex == pix.possx && capturey == pix.possy)
                {
                    score++;
                    capturex = randomnummer.Next(1, screenwidth - 2);
                    capturey = randomnummer.Next(1, screenheight - 2);
                }
                for (int i = 0; i < possxlijf.Count(); i++)
                {
                    Console.SetCursorPosition(possxlijf[i], possylijf[i]);
                    Console.Write("■");
                    if (possxlijf[i] == pix.possx && possylijf[i] == pix.possy)
                    {
                        gameover = 1;
                    }
                }
                if (gameover == 1)
                {
                    break;
                }
                Console.SetCursorPosition(pix.possx, pix.possy);
                Console.ForegroundColor = pix.leader;
                Console.Write("■");
                Console.SetCursorPosition(capturex, capturey);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("■");
                time = DateTime.Now;
                buttonpressed = "no";
                while (true)
                {
                    time2 = DateTime.Now;
                    if (time2.Subtract(time).TotalMilliseconds > 500) { break; }
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo toets = Console.ReadKey(true);
                        //Console.WriteLine(toets.Key.ToString());
                        if (toets.Key.Equals(ConsoleKey.UpArrow) && movement != "DOWN" && buttonpressed == "no")
                        {
                            movement = "UP";
                            buttonpressed = "yes";
                        }
                        if (toets.Key.Equals(ConsoleKey.DownArrow) && movement != "UP" && buttonpressed == "no")
                        {
                            movement = "DOWN";
                            buttonpressed = "yes";
                        }
                        if (toets.Key.Equals(ConsoleKey.LeftArrow) && movement != "RIGHT" && buttonpressed == "no")
                        {
                            movement = "LEFT";
                            buttonpressed = "yes";
                        }
                        if (toets.Key.Equals(ConsoleKey.RightArrow) && movement != "LEFT" && buttonpressed == "no")
                        {
                            movement = "RIGHT";
                            buttonpressed = "yes";
                        }
                    }
                }
                possxlijf.Add(pix.possx);
                possylijf.Add(pix.possy);
                switch (movement)
                {
                    case "UP":
                        pix.possy--;
                        break;
                    case "DOWN":
                        pix.possy++;
                        break;
                    case "LEFT":
                        pix.possx--;
                        break;
                    case "RIGHT":
                        pix.possx++;
                        break;
                }
                if (possxlijf.Count() > score)
                {
                    possxlijf.RemoveAt(0);
                    possylijf.RemoveAt(0);
                }
            }
            Console.SetCursorPosition(screenwidth / 5, screenheight / 2);
            Console.WriteLine("Game over, Score: " + score);
            Console.SetCursorPosition(screenwidth / 5, screenheight / 2 + 1);
        }
        class pixel
        {
            public int possx { get; set; }
            public int possy { get; set; }
            public ConsoleColor leader { get; set; }
        }
    }
}