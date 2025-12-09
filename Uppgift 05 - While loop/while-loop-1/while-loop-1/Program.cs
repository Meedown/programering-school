using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace while_loop_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int saldo = 100;
            string köptaGlassar = "";

            while (saldo >= 10)
            {
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("Du har köpt:\n" + köptaGlassar);
                Console.WriteLine("You have " + saldo + " kr left");
                Console.WriteLine("What ice cream do you want? \n 1.Piggelin: 10kr \n 2.Magnum: 20kr \n 3.Daimstrut: 30kr");
                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    saldo -= 10;
                    Console.WriteLine("You picked Piggelin, 10kr has been deducted");
                    köptaGlassar = köptaGlassar + "Piggelin\n";                        
                }
                else if (choice == "2")
                {
                    saldo -= 20;
                    Console.WriteLine("You picked Magnum, 20kr has been deducted");
                    köptaGlassar = köptaGlassar + "Magnum\n";
                }
                else if (choice == "3")
                {
                    saldo -= 30;
                    Console.WriteLine("You picked Daimstrut, 30kr has been deducted");
                    köptaGlassar = köptaGlassar + "Daimstrut\n";
                }
                else
                {
                    Console.WriteLine("You have a incomplete choice idiot try again");
                }
            }
            
        }
    }
}
