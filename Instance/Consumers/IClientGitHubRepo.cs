using System.Collections.Generic;
using System.Threading.Tasks;
using instance.Definitions;

namespace instance.Consumers
{

    public interface IClientGitHubRepo
    {
        Task<List<GitHubRepo>> ProcessRepositories();
    }
}