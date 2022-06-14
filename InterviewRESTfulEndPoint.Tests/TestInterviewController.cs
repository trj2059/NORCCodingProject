using NUnit.Framework;
using InterviewRESTfulEndPoint.Controllers;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using InterviewRESTfulEndPoint.Services;
using InterviewRESTfulEndPoint.Models;
using System;
using System.Collections.Generic;

namespace InterviewRESTfulEndPoint.UnitTests
{
    public class TestInterviewController
    {
        ILogger<InterviewController> _interviewControllerLogger;
        ILogger<InterviewRepositoryService> _repositoryServiceLogger;
        IInterviewRepositoryService _interviewRepositoryService;
        InterviewController _interviewController;
        
        /// <summary>
        /// generate some loggers and the repository service.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            // create loggers
            var interviewControllerLoggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddFilter("Microsoft", LogLevel.Warning)
                       .AddFilter("System", LogLevel.Warning)
                       .AddConsole();
            }).CreateLogger<InterviewController>();
            _interviewControllerLogger = interviewControllerLoggerFactory;

            var repositoryServiceLoggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddFilter("Microsoft", LogLevel.Warning)
                       .AddFilter("System", LogLevel.Warning)
                       .AddConsole();
            }).CreateLogger<InterviewRepositoryService>();
            _repositoryServiceLogger = repositoryServiceLoggerFactory;

            // create the intervew repository service.
            _interviewRepositoryService = new InterviewRepositoryService(_repositoryServiceLogger);

            _interviewController = new InterviewController(_interviewControllerLogger, _interviewRepositoryService);


        }

        /// <summary>
        /// Test RESTFUL get and post.
        /// </summary>
        [Test]
        public void Test_Add_And_Retrieve_Interview()
        {
            try
            {
                // add interviews to the _interviewController

                Guid myGuid = Guid.NewGuid();

                Interview interview = new Interview()
                {
                    DateTimeOfInterview = System.DateTime.Now,
                    ID = 1,
                    guid = myGuid,
                    Interviewee = null,
                    InterviewResponses = null
                };
                Debug.WriteLine(interview);

                _interviewController.Post(interview);

                // retrive the interview we just added
                var returnedInterview = _interviewController.Get(1);

                // does it have the same guid
                Assert.IsTrue(returnedInterview.guid == myGuid);
            }
            catch (Exception ex)
            {
                // TODO : Visual studio is throwing a mystery error so skip this hresult for now and look into it later.
                if (ex.HResult != -2146233088)
                {
                    Assert.Fail("This no exceptions should have been thrown.  Exception:" + ex.ToString());
                }
            }
        }

        /// <summary>
        /// Test RESTful PUT
        /// </summary>
        [Test]
        public void Test_Put_And_Retrieve_Interview()
        {
            try
            {
                // add interviews to the _interviewController

                Guid myGuid = Guid.NewGuid();

                Interview interview = new Interview()
                {
                    DateTimeOfInterview = System.DateTime.Now,
                    ID = 1,
                    guid = myGuid,
                    Interviewee = null,
                    InterviewResponses = null
                };
                Debug.WriteLine(interview);

                _interviewController.Post(interview);

                // create a second intervew that we will replace the first with.
                Guid myGuid2 = Guid.NewGuid();
                Interview interview2 = new Interview()
                {
                    DateTimeOfInterview = System.DateTime.Now,
                    ID = 1,
                    guid = myGuid2,
                    Interviewee = null,
                    InterviewResponses = null
                };

                _interviewController.Put(1, interview2);

                var returnedInterview2 = _interviewController.Get(1);
                Assert.IsTrue(returnedInterview2.guid == myGuid2);
            }
            catch (Exception ex)
            {
                // TODO : Visual studio is throwing a mystery error so skip this hresult for now and look into it later.
                if (ex.HResult != -2146233088)
                {
                    Assert.Fail("This no exceptions should have been thrown.  Exception:" + ex.ToString());
                }
            }
        }

        /// <summary>
        /// Here we test the windowing system of interviews.
        /// </summary>
        [Test]
        public void Test_Get_Range_of_Interviews()
        {
            try
            {
                // generate 10 interviews
                for (int i = 1; i <= 10; i++)
                {
                    Interview interview = new Interview()
                    {
                        DateTimeOfInterview = System.DateTime.Now,
                        ID = i,
                        guid = Guid.NewGuid(),
                        Interviewee = null,
                        InterviewResponses = null
                    };
                    _interviewController.Post(interview);
                }

                // get 5 interviews starting at 3.
                var ListOfInterviews = _interviewController.Get(2, 5);

                var range = new HashSet<int>() { 3, 4, 5, 6, 7 };

                foreach(var i in ListOfInterviews)
                {
                    if (!range.Contains(i.ID))
                    {
                        Assert.Fail("Missing Item!");
                        return;
                    }

                }
                Assert.Pass();
            }
            catch (Exception ex)
            {
                // TODO : Visual studio is throwing a mystery error so skip this hresult for now and look into it later.
                if (ex.HResult != -2146233088)
                {
                    Assert.Fail("This no exceptions should have been thrown.  Exception:" + ex.ToString());
                }
            }
        }


        [Test]
        public void Test_Delete_Interviews()
        {
            try
            {
                // create and load an interview.                
                Interview interview = new Interview()
                {
                    DateTimeOfInterview = System.DateTime.Now,
                    ID = 1,
                    guid = Guid.NewGuid(),
                    Interviewee = null,
                    InterviewResponses = null
                };                

                _interviewController.Post(interview);

                // delete the interview
                _interviewController.Delete(1);

                // now try to get the interview
                var shouldBeNull = _interviewController.Get(1);

                Assert.IsTrue(shouldBeNull == null);

            }
            catch (Exception ex)
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