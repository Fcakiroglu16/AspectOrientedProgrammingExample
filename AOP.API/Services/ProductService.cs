using AOP.API.Models;

namespace AOP.API.Services
{
    public class ProductService : IProductService
    {
        private static List<Product> _products = new List<Product>()
        {
            new(){ Id=1, Name="Pen 1", Price=100},
             new(){ Id=2, Name="Pen 2", Price=100},
              new(){ Id=3, Name="Pen 3", Price=100}

        };

        public Product GetById(int id)
        {

            return _products.FirstOrDefault(x => x.Id == id);
        }



    }
}
