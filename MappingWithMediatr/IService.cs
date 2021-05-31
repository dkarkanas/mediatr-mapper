using System.Threading.Tasks;
using MappingWithMediatr;

namespace MappingWithMediatr
{
    public interface IService
    {
        Task<ResponseModel> GetResponseModel();
    }
}