using AOP.API.Models;

namespace AOP.API.Services
{
    public interface IProductService
    {

        Product GetById(int id);
    }
}
