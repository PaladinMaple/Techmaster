using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CynthiaTicanteSquare
{
    public class Program
    {
        /// <summary>
        /// Method for calculate square roots by long division method
        /// </summary>
        /// <param name="input">number given by user</param>
        /// <returns>remainder string</returns>
        public static string SqRtN(string input)
        {
            //split string into pairs
            int inicio = 0;
            List<string> bigNumberDivided = new List<string>();
            while (inicio < input.Length)
            {
                if (inicio == 0 && input.Length % 2 != 0)
                {
                    bigNumberDivided.Add(input.Substring(inicio, 1));
                    inicio++;
                }
                else
                {
                    bigNumberDivided.Add(input.Substring(inicio, 2));
                    inicio += 2;
                }
            }

            //reminder by long division
            int remainder = 1000;
            int dividend = 0;
            int divisor = 0;
            int quotientUnits = 0;
            int quotient = 0;

            for (int i = 0; i < bigNumberDivided.Count; i++)
            {
                dividend = dividend * 100 + int.Parse(bigNumberDivided[i]);

                for (int digitSquare = 0; digitSquare <= 9; digitSquare++)
                {
                    if(remainder >= dividend - ((divisor * 10 + digitSquare) * digitSquare) && dividend - ((divisor * 10 + digitSquare) * digitSquare) >= 0)
                    {
                        remainder = dividend - ((divisor * 10 + digitSquare) * digitSquare);
                        quotientUnits = digitSquare;
                    }
                }
                quotient = quotient * 10 + quotientUnits;
                divisor = quotient * 2;
                dividend = remainder;
            }
            return remainder.ToString();
        }

        public static void Main()
        {
            Console.WriteLine("Write a number and this program will tell you the remainder of its square root");
            string input;
            BigInteger veryHugeNumber;
            bool isNumber = false;

            while (true)
            {
                input = Console.ReadLine();
                isNumber = BigInteger.TryParse(input, out veryHugeNumber);

                if (input.Length > 50)
                    Console.WriteLine("Very huge number");
                else if (!BigInteger.TryParse(input, out veryHugeNumber))
                    Console.WriteLine("Input not a number");
                else if (veryHugeNumber <= 0)
                    Console.WriteLine("Enter a number greater than zero");
                else
                {
                    SqRtN(input);
                    Console.ReadKey();
                    break;
                }
            }
        }
    }
}
