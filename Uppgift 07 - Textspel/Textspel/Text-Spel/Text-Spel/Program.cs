using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Text_Spel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int playerHP = 1;
            int playerBaseDMG = 0;
            int playerDMG = 0;
            int playerMaxHP = 1;
            bool choice = true;

            int enemyHP = 0;
            int enemyDMG = 0;
            int enemyMaxDMG = 0;
            int enemyMaxHP = 1;
            WriteLine("Lets play a game");
            while (choice)
            {
                WriteLine("Press 1 to play \n" +
                    "Press 2 to read the rules \n" +
                    "Press 3 to quit");
                Console.ReadLine();
                string startChoice = Console.ReadLine();
                switch (startChoice)
                {
                    case "1":
                    WriteLine("Choose your weapon");
                    Console.ReadLine();
                    string weapon = Console.ReadLine();
                    choice = false;
                    break;
                    case "2":
                    WriteLine("You will fight a bandit to the death \n" +
                    "You will choose a weapon to fight with a weapon of your choice");
                    break;
                    case "3":
                        break;

                }
            }

        }
        static void WriteLine(string text, int sleepMs = 35)
        {
            bool skip = false;
            const int chunk = 10; // poll interval in ms for key press
            for (int i = 0; i < text.Length; i++)
            {
                Console.Write(text[i]);

                if (skip)
                {
                    // If skipping, write remainder immediately and break.
                    if (i < text.Length - 1)
                        Console.Write(text.Substring(i + 1));
                    break;
                }

                int waited = 0;
                while (waited < sleepMs)
                {
                    if (Console.KeyAvailable)
                    {
                        var key = Console.ReadKey(true);
                        if (key.Key == ConsoleKey.Enter)
                        {
                            skip = true;
                            // write the rest of the text instantly
                            if (i < text.Length - 1)
                                Console.Write(text.Substring(i + 1));
                            break;
                        }
                        // If other keys were pressed, ignore them and continue polling.
                    }

                    int toSleep = Math.Min(chunk, sleepMs - waited);
                    Thread.Sleep(toSleep);
                    waited += toSleep;

                    if (skip) break;
                }

                if (skip) break;
            }

            Console.Write("\n");
        }
    }
}
