using NUnit.Framework;
using InterviewRESTfulEndPoint.Controllers;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using InterviewRESTfulEndPoint.Services;

namespace InterviewRESTfulEndPoint.UnitTests
{
    public class TestInterviewController
    {
        ILogger<InterviewController> _interviewControllerLogger;
        ILogger<InterviewRepositoryService> _repositoryServiceLogger;
        IInterviewRepositoryService _interviewRepositoryService;
        InterviewController _interviewController;
        [SetUp]
        public void Setup()
        {
            // create loggers
            var interviewControllerLoggerFactory = LoggerFactory.Create(builder => {
                builder.AddFilter("Microsoft", LogLevel.Warning)
                       .AddFilter("System", LogLevel.Warning)
                       .AddConsole();
            }).CreateLogger<InterviewController>();
            _interviewControllerLogger = interviewControllerLoggerFactory;

            var repositoryServiceLoggerFactory = LoggerFactory.Create(builder => {
                builder.AddFilter("Microsoft", LogLevel.Warning)
                       .AddFilter("System", LogLevel.Warning)
                       .AddConsole();
            }).CreateLogger<InterviewRepositoryService>();
            _repositoryServiceLogger = repositoryServiceLoggerFactory;

            // create the intervew repository service.
            _interviewRepositoryService = new InterviewRepositoryService(_repositoryServiceLogger);

            _interviewController = new InterviewController(_interviewControllerLogger, _interviewRepositoryService);
        }

        [Test]
        public void Test1()
        {          
            Assert.Pass();
        }
    }
}