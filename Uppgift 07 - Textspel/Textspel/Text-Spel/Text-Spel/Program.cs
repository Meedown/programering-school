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
            int playerHP = 100;
            bool choice = true;
            int damageDone;
            string weaponstr = "";
            int enemyHP = 100;
            int enemyDMG = 4;
            int enemyMaxDMG = 10;
            WriteLine("Lets play a game");
            while (choice == true)
            {           
                
                WriteLine("\nPress 1 to play \n" +
                    "Press 2 to read the rules \n" +
                    "Press 3 to quit\n");
                string startChoice = Console.ReadLine();
                while (startChoice != "1" && startChoice != "2" && startChoice != "3")
                {
                    WriteLine("\nPress 1 to play \n" +
                   "Press 2 to read the rules \n" +
                   "Press 3 to quit\n");
                    startChoice = Console.ReadLine();
                }
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
                            "3) Spear (8-10 DMG)\n");                        
                            string weapon = Console.ReadLine();
                            if (weapon == "1")
                            {
                                weaponstr = "Mace";
                                damageDone = rnd.Next(3, 21);
                            }
                            else if (weapon == "2")
                            {
                                weaponstr = "Sword";
                                damageDone = rnd.Next(6, 16);
                            }
                            else if (weapon == "3")
                            {
                                weaponstr = "Spear";
                                damageDone = rnd.Next(8, 12);
                            }
                            else
                            {
                                WriteLine("Invalid choice, please choose a valid weapon");
                                repeat = true;
                            }

                            WriteLine("You have choosen " + weaponstr);
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
                choice = false;
            }
            while (playerHP > 0 && enemyHP > 0)
            {
                Console.WriteLine("\n-----------------------------------------");
                Console.WriteLine("You: " + playerHP + " HP | Bandit: " + enemyHP + " HP");
                Console.WriteLine("Press 1 to attack!");

                string action = Console.ReadLine();

                if (action == "1")
                {
                    
                    int attackPower = 0;
                    if (weaponstr == "Mace") attackPower = rnd.Next(3, 21);
                    else if (weaponstr == "Sword") attackPower = rnd.Next(5, 16);
                    else if (weaponstr == "Spear") attackPower = rnd.Next(7, 11);

                    enemyHP -= attackPower;
                    WriteLine("You hit the bandit for " + attackPower + " damage!");

                    
                    if (enemyHP <= 0)
                    {
                        WriteLine("The bandit has been defeated! You win!");
                        break;
                    }

                    
                    int enemyAttack = rnd.Next(enemyDMG, enemyMaxDMG + 1);
                    playerHP -= enemyAttack;
                    WriteLine("The bandit hits you back for " + enemyAttack + " damage!");

                    if (playerHP <= 0)
                    {
                        WriteLine("You have been slain...");
                    }
                }
                else
                {
                    WriteLine("Invalid input! The bandit stares at you awkwardly.");
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

        }
    }
}
