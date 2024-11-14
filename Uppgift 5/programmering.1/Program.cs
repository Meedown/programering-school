using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programmering._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int val = 0;
            int saldo = 100;
            

            while (saldo > 0)
            {

                Console.WriteLine("your money is " + saldo);
                Console.WriteLine("what ice cream you want?");
                Console.WriteLine("1.Piggelin = 10 kr  2.Magnum = 20 kr and 3.Daim = 30 kr");
                val = int.Parse(Console.ReadLine());

                if (val == 1)
                {

                    saldo = saldo - 10;

                }

                else if (val == 2)
                {

                    saldo = saldo - 20;

                }

                else if (val == 3)
                {

                    saldo = saldo - 30;

                }

 
            }
           
        }
    }
}
