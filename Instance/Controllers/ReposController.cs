using System.Collections.Generic;
using System.Threading.Tasks;
using instance.Mapping;
using instance.Transforms;
using Microsoft.AspNetCore.Mvc;

namespace instance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReposController : ControllerBase
    {

        private readonly ITransformRepo _repo;
        public ReposController(ITransformRepo repo){
            _repo = repo;
        }

        [HttpGet]
        public async Task<List<IMapRepo>> Get()
        {
            return await _repo.GetAll();
        }

    }


}
