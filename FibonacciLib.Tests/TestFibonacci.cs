using NUnit.Framework;
using FibonacciLib;
using System;

/// <summary>
/// //https://en.wikipedia.org/wiki/Fibonacci_number
/// </summary>
namespace FibonacciLib.UnitTests
{
    public class Tests
    {
        private Fib _fib;

        [SetUp]
        public void Setup()
        {
            _fib = new Fib();
        }       
        
        [Test]
        public void Fib_Base_Case_Returns_0()
        {
            Assert.AreEqual(_fib.Fibonacci(0), 0);
        }

        [Test]
        public void Fib_Base_Case_Returns_1()
        {
            Assert.AreEqual(_fib.Fibonacci(1), 1);
        }

        [Test]
        public void Fib_Case_11_Returns_89()
        {
            Assert.AreEqual(_fib.Fibonacci(11), 89);
        }
    }
}