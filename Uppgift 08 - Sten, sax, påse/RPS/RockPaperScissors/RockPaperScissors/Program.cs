using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pMoney = 1000;
            int aiMoney = 1000;
            int betAmount = 0;
            string bet = "";
            
            Random rnd = new Random();

            while (pMoney > 0)
            {
                WriteLine("How much do you want to bet? \nYour money is " + pMoney + ":" + "\nThe AI has " + aiMoney + ":\n");
                
                bet = Console.ReadLine();
                if (int.TryParse(bet, out betAmount))
                {
                    if (betAmount > 0 && betAmount <= pMoney && betAmount <= aiMoney)
                    {
                        WriteLine("\nYou bet " + betAmount + " and the AI matches your bet\n");


                        pMoney = pMoney - betAmount;
                        aiMoney = aiMoney - betAmount;

                        int pot = betAmount * 2;
                        WriteLine("The pot is now " + pot);

                        break;
                    }
                    else if (betAmount > aiMoney)
                    {
                        WriteLine("\nThe AI only has " + aiMoney + ". You can't bet more than the AI can match\n");
                    }
                    else
                    {
                        WriteLine("\nInvalid amount! You must bet between 1 and " + pMoney + ".\n");

                    }
                    }
                }
            WriteLine("\nChoose between Rock,Paper or Scissors");
            string pChoice = Console.ReadLine();


            void WriteLine(string text, int sleepMs = 35)
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
    }

        
    



