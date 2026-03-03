using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace switch_ph
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int money;
            int choice = 0;

            while(money >= 10)
            {
                WriteLine("You have " + money + " kr left what ice cream do you want to buy?\n" +
                    "If you want Piggelin type 1\n" +
                    "If you want a Bull rush type 2\n" +
                    "If you want a Daim strut type 3");
                Console.ReadLine();
                if (choice == 1)
                {
                    money -= 10;
                }
                if (choice == 2)
                {
                    money -= 20;
                }
                if (choice == 3)
                {
                    money -= 30;
                }
                if (money == 0)
                {
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
