using System;
using System.Collections.Generic;
using System.Linq;
using Bicicletaria_ploomes.Data;
using Bicicletaria_ploomes.Models;
using Bicicletaria_ploomes.Models.Interface;
using Microsoft.EntityFrameworkCore;

namespace Bicicletaria_ploomes.Repository
{
  public class ProductRepository : IProductRepository
  {
    private DataContext _context;
    private IUserRepository _userRepositorio;

    public ProductRepository(DataContext context, IUserRepository userRepositorio)
    {
      _userRepositorio = userRepositorio;
      _context = context;
      _context.Database.EnsureCreated();
    }

    public void Create(Product product)
    {
      product.DateCreate = DateTime.Now;
      product.GenerateRecordIdentifier();

      _context.Product.AddRange(product);
      _context.SaveChanges();
    }

    public Product Get(int id)
    {
      return _context.Product.Where(p => p.Id == id).FirstOrDefault();
    }

    public List<Product> GetAll()
    {
      return _context.Product.ToList();
    }

    public void UpdateProduct(Product product)
    {
      _context.Entry<Product>(product).State = EntityState.Modified;
      _context.SaveChanges();
    }
  }
}