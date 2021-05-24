using System;

namespace CynthiaTicante
{
    public class Program
    {
        /// <summary>
        /// This methood is a loop that 'splits' the number by digits
        /// then sum its square
        /// if the sum of its squares equals 1 is a happy number
        /// if the sum of its squares equals 4 is not a happy number
        /// </summary>
        /// <param name="num">Number introduced by the user</param>
        /// <returns></returns>
        public static bool isHappyNumber(int num)
        {
            int temp, sum = 0;
            temp = num;

            while (true)
            {
                sum = sum + ((temp % 10) * (temp % 10));
                temp /= 10;
                if (temp == 0)
                {
                    if(sum == 1)
                        return true;
                    if (sum == 4)
                        break;
                    temp = sum;
                    sum = 0;
                }
            }
            return false;
        }

        public static void Main()
        {
            try
            {
                Console.WriteLine("Write a number and this program will tell you if is happy or not");
                string input;
                int number = 0;
                bool isNumber = false;
                while (true)
                {
                    input = Console.ReadLine();
                    isNumber = int.TryParse(input, out number);
                    if (!int.TryParse(input, out number))
                        Console.WriteLine("Input not a number");
                    else if (number <= 0)
                        Console.WriteLine("Enter a number greater than zero");
                    else
                    {
                        Console.WriteLine(isHappyNumber(number));
                        Console.ReadKey();
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }              
        }
    }
}
