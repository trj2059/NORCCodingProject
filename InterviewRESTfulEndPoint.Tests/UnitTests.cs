using NUnit.Framework;
using InterviewRESTfulEndPoint.Controllers;
using System.Diagnostics;

namespace InterviewRESTfulEndPoint.UnitTests
{
    public class Tests
    {

        [SetUp]
        public void Setup()
        {
            var controller = new InterviewController();
            var x = controller.Get();
            foreach(var s in x)
                Debug.WriteLine(s);
        }

        [Test]
        public void Test1()
        {          
            Assert.Pass();
        }
    }
}