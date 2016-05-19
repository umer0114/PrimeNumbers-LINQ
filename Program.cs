using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatePrimeNumbersLINQ
{
    class Program
    {
        public int N { get; } = 500; // Auto Property Initializer, C# 6 Feature.

        
        static void Main(string[] args)
        {
            
            var time = System.Diagnostics.Stopwatch.StartNew(); //To Calculate the total time of execution

            //I have used the class object to execute the function to use the Auto Property Initializer Feature of C# 6.
            Program objProgram = new Program();
            Console.WriteLine(objProgram.calculatePrime());

            time.Stop();
            Console.WriteLine("Time Taken: " + time.ElapsedMilliseconds + " ms");
            Console.ReadLine(); //To stop Console from exiting
        }

        public string calculatePrime()
        {
            int upperBound = (int)(500 * (Math.Log(N) + Math.Log(Math.Log(N)) - 0.5));
            string result = (string.Join(" ", Enumerable.Range(2, upperBound)
                .AsParallel() //Paralell processing of the prime numbers.
                .WithDegreeOfParallelism(Environment.ProcessorCount) //Maximum threads to be made = total processors of coumputer
                .Where(number => Enumerable.Range(2, (int)Math.Sqrt(number) - 1 )
                .All(divisor => number % divisor != 0)).OrderBy(number => number)
                ));
            return result;

        }


    }
}
