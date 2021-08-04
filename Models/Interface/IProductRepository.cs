using System.Collections.Generic;

namespace Bicicletaria_ploomes.Models.Interface
{
  public interface IProductRepository
  {
    void Create(Product product);
    void Delete(Product product);
    void UpdateProduct(Product product);
    List<Product> GetAll();
    Product Get(int id);
  }
}