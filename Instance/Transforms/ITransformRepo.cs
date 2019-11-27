using System.Collections.Generic;
using System.Threading.Tasks;
using instance.Mapping;

namespace instance.Transforms{
    public interface ITransformRepo
    {
        Task<List<IMapRepo>> GetAll();
    }

}