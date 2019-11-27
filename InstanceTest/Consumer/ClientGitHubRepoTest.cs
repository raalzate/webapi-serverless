
using System;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using instance.Clients;
using Xunit;
using System.IO;

namespace instanceTest
{
    public class ClientGithubRepoTest
    {
        private ClientGitHubRepo clientGitHub;


        [Fact]
        public void GerRepos()
        {
            string payload = File.ReadAllText(@"../../../Consumer/repos.json");
            clientGitHub = new ClientGitHubRepo(GetHttpMessageHandlerStub(payload));

            var result = clientGitHub.ProcessRepositories().Result;
            
            Assert.Equal("BenchmarkDotNet", result[0].Name);
            Assert.Equal(1, result.Count);
        }

        private HttpMessageHandlerStub GetHttpMessageHandlerStub(string payload){
            return new HttpMessageHandlerStub(async (request, cancellationToken) =>
            {
                var responseMessage = new HttpResponseMessage(HttpStatusCode.OK)
                        {
                            Content = new StringContent(payload, Encoding.UTF8, "application/json")
                        };

                return await Task.FromResult(responseMessage);
            });
        }

    }

    public class HttpMessageHandlerStub : HttpMessageHandler
    {
        private readonly Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> _sendAsync;

        public HttpMessageHandlerStub(Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> sendAsync)
        {
            _sendAsync = sendAsync;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return await _sendAsync(request, cancellationToken);
        }
    }
}