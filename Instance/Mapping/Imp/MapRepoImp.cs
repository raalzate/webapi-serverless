

using instance.Definitions;
using instance.Mapping;

namespace instance.MappingImp
{

    public class MapRepo : IMapRepo
    {
        public string Name { get; set; }
        public IMapRepo ToMap(GitHubRepo repo)
        {
            var mp = new MapRepo();
            mp.Name = repo.Name;
            return mp;
        }
    }
}