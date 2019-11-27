using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using instance.Consumers;
using instance.Definitions;

namespace instance.Clients
{
    public class ClientGitHubRepo: IClientGitHubRepo
    {
       private readonly HttpClient client;
       private const string URL = "https://api.github.com/orgs/dotnet/repos";

       public ClientGitHubRepo(HttpMessageHandler handler){
           client = new HttpClient(handler);
       }

       public ClientGitHubRepo(){
           client = new HttpClient();
       }

        public async Task<List<GitHubRepo>> ProcessRepositories()
        {
            var serializer = new DataContractJsonSerializer(typeof(List<GitHubRepo>));

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json")
            );
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var streamTask = client.GetStreamAsync(URL);
            var repositories = serializer.ReadObject(await streamTask) as List<GitHubRepo>;
            return repositories;
        }

    }
}