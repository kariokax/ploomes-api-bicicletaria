using System;
using System.Threading.Tasks;
using Bicicletaria_ploomes.Models;
using Bicicletaria_ploomes.Models.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Bicicletaria_ploomes.Controllers
{

  [Route("v1/product")]
  [ApiController]
  public class ProductController : ControllerBase
  {
    private IProductRepository _productRepositorio;

    public ProductController(IProductRepository productRepositorio)
    {
      _productRepositorio = productRepositorio;
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateProduct([FromBody] Product product)
    {
      try
      {
        if (product == null)
          return NotFound("Produto não informado");
        if (product.CreatorUserId == decimal.Zero)
          return NotFound("Usuário não identificado");

        if (!ModelState.IsValid)
          return BadRequest(ModelState);

        _productRepositorio.Create(product);

        return Ok(product);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpGet]
    [Route("getall")]
    public async Task<IActionResult> GetAllProducts()
    {
      try
      {
        return Ok(_productRepositorio.GetAll());
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpGet]
    [Route("get/{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
      try
      {
        if (id <= decimal.Zero)
          return NotFound("Produto não definido");

        return Ok(_productRepositorio.Get(id));
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpPut]
    [Route("update")]
    public async Task<IActionResult> UpdateProduct([FromBody] Product product)
    {
      try
      {
        if (product.Id <= decimal.Zero)
          return NotFound("Produto não informado");

        if (!ModelState.IsValid)
          return BadRequest(ModelState);

        _productRepositorio.UpdateProduct(product);

        return Ok(product);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }
  }
}