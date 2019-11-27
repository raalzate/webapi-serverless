using instance.Definitions;

namespace instance.Mapping{
    public interface IMapRepo
    {
        IMapRepo ToMap(GitHubRepo repo);
    }

}