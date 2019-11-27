using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using instance.Consumers;
using instance.Mapping;
using instance.Transforms;

namespace instance.TransformsImp
{

    public class TransformRepo : ITransformRepo
    {
        private readonly IClientGitHubRepo _client;
        private readonly IMapRepo _mapper;

        public TransformRepo(IClientGitHubRepo client, IMapRepo mapper)
        {
            _client = client;
            _mapper = mapper;
        }

        public async Task<List<IMapRepo>> GetAll()
        {
            var result = await _client.ProcessRepositories();
            return result.Select(_mapper.ToMap).ToList();
        }
    }
}