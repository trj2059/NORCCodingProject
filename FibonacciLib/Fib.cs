using System;

namespace FibonacciLib
{
    public class Fib
    {
        /// <summary>
        /// Computes the nth Fibonacci number
        /// </summary>
        /// <param name="n">The input</param>
        /// <returns>The nth Fibonacci number</returns>
        public ulong Fibonacci(ulong n)
        {
            if(n == 0)
            {
                return 0;
            }
            else if(n == 1)
            {
                return 1;
            }
            else
            {
                return Fibonacci(n - 1) + Fibonacci(n - 2);
            }
        }
    }
}
