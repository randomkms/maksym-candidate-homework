using System;

namespace _1.WarmUp.Easy
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             
               Write code that meets the following requirements:
                   - loops through all integers from 1 to 100 and prints to the console according to the following rules
                       - where the integer is a multiple of 3, the console prints the word 'Fizz'
                       - where the integer is a multiple of 5, the console prints the word 'Buzz' 
                       - where the integer is a multiple of both 3 and 5, the console prints the words 'Fizz Buzz'
                       - otherwise the console simply prints the integer value
              
             
                   - example output:
             
                   1
                   2
                   Fizz
                   4
                   Buzz

               Please do this work yourself - you should be able to do this easily without any 3rd party libraries
             
             */

            for (int i = 1; i <= 100; i++)
            {
                var isMultipleOf3 = i % 3 == 0;
                var isMultipleOf5 = i % 5 == 0;

                if (isMultipleOf3 && isMultipleOf5)
                {
                    Console.WriteLine("Fizz Buzz");
                    continue;
                }

                if (isMultipleOf3)
                {
                    Console.WriteLine("Fizz");
                    continue;
                }

                if (isMultipleOf5)
                {
                    Console.WriteLine("Buzz");
                    continue;
                }

                Console.WriteLine(i);
            }



            Console.WriteLine("\r\n\r\nCompleted -- Press any key to quit");


            Console.ReadKey();
        }
    }
}
