using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace stansaxpåse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name;
            int saldo = 100;
            string val = "";
            int bot_choice = 0;
            int bet = 0;
            int bot_saldo = 100;
            Random rnd = new Random();
            
            Console.WriteLine("Please enter Challenger name");
            name = Console.ReadLine();

            Console.WriteLine("\nYou will face Larry " +
                              "\nPress enter" );
            

            

            

            while (saldo > 0 && bot_saldo > 0)
            {
                Console.Read();
                Console.Clear();
                Console.WriteLine("How much you want to bet " +
                                  "\nYour current money is " + saldo);
                bool haveBet = false;
                while (haveBet == false)
                {
                    if (int.TryParse(Console.ReadLine(), out int bet2) == true)
                    {
                        bet = bet2;
                        if (bet > saldo)
                        {

                            Console.WriteLine("You can't bet more then you have stupid");


                        }
                        else
                        {

                            saldo = saldo - bet;
                            haveBet = true;

                        }



                    }


                }

                Console.WriteLine("Choose rock,paper or scissors" +
                "\n1. Rock" +
                "\n2. Paper" +
                "\n3. Scissors");
                bot_choice = rnd.Next(1,4);

                
                val = "";
                while (val != "1" && val != "2" && val != "3")
                {
                    val = Console.ReadLine();
                }

                int num_val = Convert.ToInt32(val);

                if (bot_choice == 1)
                {

                    Console.WriteLine("Larry chose Rock");

                }

                if (bot_choice == 2)
                {

                    Console.WriteLine("Larry chose Paper");

                }

                if (bot_choice == 3)
                {

                    Console.WriteLine("Larry chose Scissors");

                }

                if (val == "1" && bot_choice == 3)
                {
                    bet = bet * 2;

                    Console.WriteLine("You chose Rock and won " + bet);
                    saldo = saldo + bet;

                }
                else if (val == "2" && bot_choice == 1)
                {


                    bet = bet * 2;
                    Console.WriteLine("You chose Paper and won " + bet);
                    saldo = saldo + bet;

                }
                else if (val == "3" && bot_choice == 2)
                {

                    bet = bet * 2;

                    Console.WriteLine("You chose Scissors and won " + bet);
                    saldo = saldo + bet;

                }
                else if (val == "3" && bot_choice == 1)
                {
                    bet = bet * 2;

                    Console.WriteLine("You chose Scissors and Lost " + bet);
                    saldo = saldo + bet;

                }
                else if (val == "1" && bot_choice == 2)
                {


                    bet = bet * 2;
                    Console.WriteLine("You chose Rock and Lost " + bet);
                    saldo = saldo + bet;

                }
                else if (val == "2" && bot_choice == 3)
                {

                    bet = bet * 2;

                    Console.WriteLine("You chose Paper and Lost " + bet);
                    saldo = saldo + bet;
                }
                else if (num_val == bot_choice)
                {
                    Console.WriteLine("You tied");
                    saldo = saldo + bet;
                }


                else
                {

                    Console.WriteLine("You lost " + bet);
                }
            
            
            }
            if (saldo <= 0)
            {
                Console.WriteLine("You went broke you suck");
                Console.ReadLine();
            }
            else if (bot_saldo <= 0)
            {
                Console.WriteLine("Larry went broke Good Job");
                Console.ReadLine();
            }
        }
    }
}