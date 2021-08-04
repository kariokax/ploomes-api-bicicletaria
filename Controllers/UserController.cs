using System;
using System.Threading.Tasks;
using Bicicletaria_ploomes.Models;
using Bicicletaria_ploomes.Models.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Bicicletaria_ploomes.Controllers
{
  [Route("v1/user")]
  [ApiController]
  public class UserController : ControllerBase
  {
    private IUserRepository _userRepositorio;

    public UserController(IUserRepository userRepositorio)
    {
      _userRepositorio = userRepositorio;
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateProduct([FromBody] User user)
    {
      try
      {
        if (user == null)
          return NotFound("Usuario não informado");

        if (!ModelState.IsValid)
          return BadRequest(ModelState);

        _userRepositorio.Create(user);

        return Ok(user);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpGet]
    [Route("getall")]
    public async Task<IActionResult> GetAllUsers()
    {
      try
      {
        return Ok(_userRepositorio.GetAll());
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
        if (id == decimal.Zero)
          return NotFound("Usuário não informado");

        return Ok(_userRepositorio.GetById(id));
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpPut]
    [Route("enable/{id:int}")]
    public async Task<IActionResult> EnableUser(int id)
    {
      try
      {
        if (id == decimal.Zero)
          return NotFound("Usuário não informado");

        return Ok(_userRepositorio.EnableUser(id));
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpPut]
    [Route("disable/{id:int}")]
    public async Task<IActionResult> DisableUser(int id)
    {
      try
      {
        if (id == decimal.Zero)
          return NotFound("usuário não informado");

        return Ok(_userRepositorio.DisableUser(id));
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }
  }
}