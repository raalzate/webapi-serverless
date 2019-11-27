using Xunit;
using Moq;
using System.Collections.Generic;
using instance.TransformsImp;
using instance.Consumers;
using instance.Mapping;
using instance.Definitions;
using instance.MappingImp;

namespace instanceTest
{
    public class TransformRepoTest
    {

        private TransformRepo transformRepo;

        private Mock<IClientGitHubRepo> client;

        private Mock<IMapRepo> mapper;

        public TransformRepoTest()
        {
            client = new Mock<IClientGitHubRepo>();
            mapper = new Mock<IMapRepo>();
        }

        [Fact]
        public void GetAllTest()
        {
            //arrage
            var list = new List<GitHubRepo>();
            list.Add(new GitHubRepo());
            var map = new MapRepo();
            map.Name = "Repo-1";
            client
                .Setup(e => e.ProcessRepositories())
                .ReturnsAsync(list);

            mapper
                .Setup(e => e.ToMap(It.IsAny<GitHubRepo>()))
                .Returns(map);

            transformRepo = new TransformRepo(client.Object, mapper.Object);

            //Act
            var result = transformRepo.GetAll().Result;

            //Assert
            Assert.Equal("Repo-1", ((MapRepo)result[0]).Name);

            client.Verify(e => e.ProcessRepositories());
            mapper.Verify(e => e.ToMap(It.IsAny<GitHubRepo>()));

        }
    }
}
