using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
using System.IO;

namespace Game1
{

    public class Program
    {
        static readonly int x = 80;
        static readonly int y = 25;

        static Walls? walls;
        static FoodFactory? foodFactory;
        static Snake? snake;
        static Timer time;
        static Score score;

        static void Main()
        {
            Console.SetWindowSize(x + 1, y + 1);
            Console.SetBufferSize(x + 1, y + 1);
            Console.CursorVisible = false;

            ScreenSaver();

            walls = new Walls(x, y, '#');
            foodFactory = new FoodFactory(x, y, '@');
            foodFactory.CreateFood();
            snake = new Snake(x / 2, y / 2, 3);
            time = new Timer(Loop, null, 0, 200);

            //score = new Score();
            if (File.Exists("score2.json"))
            {
                string scoreJson = File.ReadAllText("score2.json");

                score = JsonSerializer.Deserialize<Score>(scoreJson);
            }
            else
            {
                score = new Score();
            }

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.Rotation(key.Key);
                }
            }
        }
        static void ScreenSaver()
        {
            string[] ss = new string[8];
            ss[0] = "  sss   s    s   sss s   s   ssssss";
            ss[1] = " s   s  s    s  s  s s  s    s     ";
            ss[2] = "  s     ss   s s   s s s     s     ";
            ss[3] = "   s    s s  s sssss ss      ssssss";
            ss[4] = "    s   s  s s s   s s s     s     ";
            ss[5] = "     s  s   ss s   s s  s    s     ";
            ss[6] = "s    s  s    s s   s s   s   s     ";
            ss[7] = "  sss   s    s s   s s    s  ssssss";

            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < ss.Length; i++)
            {
                for (int j = 0; j < ss[i].Length; j++)
                {
                    Console.SetCursorPosition(j + 25, i + 10);
                    Console.Write(ss[i][j]);
                }
            }

            Console.SetCursorPosition(30, 25);
            Console.Write("Press any key to start");
            Console.ResetColor();

            Console.ReadKey(true);
            Console.Clear();
        }

        static void Loop(object obj)
        {
            if (walls.IsHit(snake.GetHead()) || snake.IsHit(snake.GetHead()))
            {
                time.Change(0, Timeout.Infinite);

                Console.Clear();
                Console.SetCursorPosition(35, 12);
                Console.Write("**Game over**");

                score.DisplayScore();
                Console.ReadKey();
                Console.Clear();

            }
            else if (snake.Eat(foodFactory.food))
            {
                foodFactory.CreateFood();

                score.IncreaseScore(10);

                string scoreJson = JsonSerializer.Serialize(score);
               
                File.WriteAllText("score2.json", scoreJson);
            }
            else
            {
                snake.Move();
            }
        }
    }
}
