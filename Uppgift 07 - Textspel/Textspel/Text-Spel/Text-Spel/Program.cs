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
            int damageDone;

            int enemyHP = 0;
            int enemyDMG = 0;
            int enemyMaxDMG = 0;
            int enemyMaxHP = 1;
            WriteLine("Lets play a game");
            while (choice)
            {           
                
                WriteLine("\nPress 1 to play \n" +
                    "Press 2 to read the rules \n" +
                    "Press 3 to quit\n");
                string startChoice = Console.ReadLine();
                bool repeat = true;
                while (repeat)
                {
                    
                    switch (startChoice)
                    {
                        case "1":
                            repeat = false;
                            WriteLine("Choose your weapon\n");
                            WriteLine("1) Mace (3-20 DMG)\n" +
                            "2) Sword (5-15 DMG)\n" +
                            "3) Spear (7-10 DMG)\n");                        
                            string weapon = Console.ReadLine();
                            if (weapon == "Mace")
                            {
                                damageDone = rnd.Next(3, 21);
                            }
                            else if (weapon == "Sword")
                            {
                                damageDone = rnd.Next(5, 16);
                            }
                            else if (weapon == "Spear")
                            {
                                damageDone = rnd.Next(7, 11);
                            }
                            else
                            {
                                WriteLine("Invalid choice, please choose a valid weapon");
                                repeat = true;
                            }

                            WriteLine(" You have choosen " + weapon);
                            Console.ReadLine();


                            break;
                        case "2":
                        WriteLine("You will fight a bandit to the death \n" +
                        "You will choose a weapon to fight with");
                        break;
                        case "3":
                            break;

                    }
                }
            }  
            Console.Write("You have " + playerHP + " The bandit has " + enemyHP);

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

        }
    }
}
