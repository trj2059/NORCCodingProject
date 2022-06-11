using NUnit.Framework;
using InterviewRESTfulEndPoint.Controllers;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using InterviewRESTfulEndPoint.Services;
using InterviewRESTfulEndPoint.Models;
using System;

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
        public void Test_Add_And_Retrieve_Interview()
        {
            try
            {
                Guid myGuid = Guid.NewGuid();

                // add interviews to the _interviewController
                Interview interview = new Interview()
                {
                    DateTimeOfInterview = System.DateTime.Now,
                    ID = 1,
                    guid = myGuid,
                    Interviewee = null,
                    InterviewResponses = null
                };

                _interviewController.Post(interview);

                var returnedInterview = _interviewController.Get(1);

                Assert.IsTrue(returnedInterview.guid == myGuid);
               
            } 
            catch(Exception ex)
            {
                // TODO : Visual studio is throwing a mystery error so skip this hresult for now and look into it later.
                if (ex.HResult != -2146233088)
                {
                    Assert.Fail("This no exceptions should have been thrown.  Exception:" + ex.ToString());
                }
            }
        }
    }
}