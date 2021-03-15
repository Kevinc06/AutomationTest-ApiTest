using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace AutomationTest.Methods
{
    public static class RestMethods
    {
        /* I create and instantiate an object called "client" of type HttpClient responsible for sending / receiving an HTTP request. */
        public static HttpClient client = new HttpClient();

        /* An object of type HttpResponseMessage was created called "ReturnGet" with the following parameter (string Url) 
           that will be responsible for returning the content contained in the passed Url */
        public static HttpResponseMessage ReturnGet(string Url)
        {
            /* I created an object called "message" of type HttpRequestMessage responsible for 
               containing the GET method of type HttpMethod and the "RequestUri" object */
            HttpRequestMessage message = new HttpRequestMessage
            {
                /* Create an object called "Method" responsible for receiving a HttpMethod "GET" used when the client would like to obtain server resources */
                Method = new HttpMethod("GET"),
                RequestUri = new Uri(Url)
            };

            /* An object called "response" of the HttpResponseMessage type was created that when using the client object to send 
               an asynchronous request to the "message" object requesting its contents */
            HttpResponseMessage response = client.SendAsync(message).Result;
            return response;
        }
    }
}


