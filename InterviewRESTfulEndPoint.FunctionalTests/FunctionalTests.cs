using InterviewRESTfulEndPoint.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace InterviewRESTfulEndPoint.FunctionalTests
{
    public class EndPointFunctionalTests
    {
		HttpClientHandler _handler;
		HttpClient _httpClient;
		HttpRequestMessage _httpRequestMessage;
		const string BaseAddress = "https://localhost:5001";
		const string BasicAuthUserName = "admin";
		const string BasicAuthPassword = "1D6D06878ECEA9FC4FD2CECEFDA646A54A56682AF95E8C5F2E964A235DA0E2E7";

		[SetUp]
        public void Setup()
        {
			_handler = new HttpClientHandler()
			{
				AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
			};
			_httpClient = new HttpClient(_handler);
			_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
			   AuthenticationSchemes.Basic.ToString(),
			   Convert.ToBase64String(Encoding.ASCII.GetBytes($"{BasicAuthUserName}:{BasicAuthPassword}"))
			   );
		}

        [Test]
        public async Task Test1()
        {
			_httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, new Uri(BaseAddress + "/api/Interview"));

			Guid myGuid = Guid.NewGuid();

			Interview interview = new Interview()
			{
				ID = 1,
				DateTimeOfInterview = System.DateTime.Now,		
				guid = myGuid,
				Interviewee = null,
				InterviewResponses = null
			};

			Debug.WriteLine(interview);

			// post the interview item.
			_httpRequestMessage.Content = new StringContent(interview.ToString(), Encoding.UTF8, "application/json");
			var response = await _httpClient.SendAsync(_httpRequestMessage);
			if (response.StatusCode != HttpStatusCode.OK)
				Assert.Fail("Unable to connect");

			// get the corresponding interview
			const int interviewNumber = 1;
			_httpRequestMessage =  new HttpRequestMessage(HttpMethod.Get, new Uri(BaseAddress + $"/api/Interview/{interviewNumber}"));
			var response2 = await _httpClient.SendAsync(_httpRequestMessage);
			if (response2.StatusCode != HttpStatusCode.OK)
				Assert.Fail("Unable to connect");

			string responsString = await response2.Content.ReadAsStringAsync();

			Assert.Pass();
        }
    }

	
}