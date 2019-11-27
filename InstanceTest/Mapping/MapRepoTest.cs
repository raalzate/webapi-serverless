using Xunit;
using instance.MappingImp;
using instance.Definitions;

namespace instanceTest
{
    public class MapRepoTest
    {

        private MapRepo mapRepo;

        public MapRepoTest()
        {
            mapRepo = new MapRepo();
        }

        [Fact]
        public void ToMapTest()
        {
            //arrage
            var githubRepo = new GitHubRepo();
            githubRepo.Name = "repo-1";
            var map = (MapRepo)mapRepo.ToMap(githubRepo);

            Assert.Equal("repo-1", map.Name);

        }
    }
}
