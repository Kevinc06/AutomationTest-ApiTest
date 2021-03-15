using NUnit.Framework;
using AutomationTest.LoginInfo;
using AutomationTest.Methods;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System;

namespace AutomationTest.APITest
{
    [TestFixture]
    class ApiTest : Login
    {
        [Test]
        public void FirstTest()
        {
            /* Creating and assigning value to the variables that will be used in the API placeholders */
            string nameOfCity = "Round Rock";
            string nameOfState = "TX";
            int expectedBehaviour = 200;
            /* Assigning the API link in the variable "url" with the placeholders being replaced by the equivalent data using the interpolation */
            string url = $"https://api.interzoid.com/getweather?license={kevin.license}&city={nameOfCity}&state={nameOfState}";

            try
            {
                /* Creation of a variable called "response" of type HttpResponseMessage to store 
                   the return that the HTTP Request GET method will bring when reading the API present in the variable "url" */
                HttpResponseMessage response = RestMethods.ReturnGet(url);
                /* Stores in the variable "body" as a string the unformatted data/content that was present in the variable "response" */
                string body = response.Content.ReadAsStringAsync().Result;
                /* Verifying that the value assigned in the "StatusCode" field that was returned through the "body" variable is the same as that in the "ExpectedBehaviour" field, if true the test will pass */
                Assert.AreEqual((int)response.StatusCode, expectedBehaviour);
                /* A variable was created so that it was possible to store the content present in the variable "body", however, formatted as a JSON using the method "JOBject.Parse (Body)"  
                 as the type of data present in the content will change at run time, we need the type of the variable to be dynamic*/
                dynamic formatedBody = JObject.Parse(body);
                /* The "statusCode" variable was created to store the value in the "Code" field of the "formatedBody" variable */
                string statusCode = formatedBody.Code;
                /* Checking if the data in the variable "statusCode" is the same as the word "Sucess" */
                Assert.AreEqual(statusCode, "Success");
            }
            /* If the Try block fails, the error message will be attributed to the exception argument "e" */
            catch (Exception e)
            {
                /* In case the test fails, the message stored in "e" will be displayed */
                Assert.Fail(e.Message);
            }
        }
        [Test]
        public void SecondTest()
        {

            string nameOfCity = "Tampa";
            string nameOfState = "TX";
            int expectedBehaviour = 404;
            string url = $"https://api.interzoid.com/getweather?license={kevin.license}&city={nameOfCity}&state={nameOfState}";

            try
            {
                HttpResponseMessage response = RestMethods.ReturnGet(url);
                string body = response.Content.ReadAsStringAsync().Result;
                /* As the variable "body" was unable to return a valid JSON file 
                   I was able to check the HTTP Status code, but not its description. */
                Assert.AreEqual((int)response.StatusCode, expectedBehaviour);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        [Test]
        public void ThirdTest()
        {
            string nameOfCity = "";
            string nameOfState = "";
            int expectedBehaviour = 400;

            string url = $"https://api.interzoid.com/getweather?license={kevin.license}&city={nameOfCity}&state={nameOfState}";

            try
            {
                HttpResponseMessage response = RestMethods.ReturnGet(url);
                string body = response.Content.ReadAsStringAsync().Result;
                /* As the variable "body" was unable to return a valid JSON file 
                   I was able to check the HTTP Status code, but not its description. */
                Assert.AreEqual((int)response.StatusCode, expectedBehaviour);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }
}

