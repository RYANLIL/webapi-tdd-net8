using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FormulaApp.Test.Helpers
{
    // mocking the http used in Fanservice so we dont actually have to hit and api endpoint
    public class MockHttpHandler<T>
    {
        // Success
        internal static Mock<HttpMessageHandler> SetupGetRequest(List<T> response)
        {
            /*
             * Creating mock response to return http status code 200  ok
             * and serializing what ever response was passed to this method
             * 
             */
            var mockRes = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonConvert.SerializeObject(response))
            };

            //Specifying the type of content of the response
            mockRes.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            // method is returing a message handler
            var mockHandler = new Mock<HttpMessageHandler>();

            /*
             * Set as protected because using mock library
             * In setup specifying what type of response in this case 
             * the HttpMessageHandler.
             * making sure its a Task because its an async request
             * the method/property is "SendAsync" following are the
             * parameters 
             * 
             * ItExpr.IsAny<HttpRequestMessage>() -> Return for any 
             * type of request message
             * 
             * ItExpr.IsAny<CancellationToken>()) eturn for any 
             * type of cancelation token
             */
            mockHandler.Protected().Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(mockRes);

            return mockHandler;
        }

        

        // NotFound to mimic any problems the api the app is calling

        internal static Mock<HttpMessageHandler> SetupReturnNotFound()
        {
            var mockRes = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent("")
            };

            mockRes.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var mockHandler = new Mock<HttpMessageHandler>();

            mockHandler.Protected().Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(mockRes);

            return mockHandler;
        }
    }
}
