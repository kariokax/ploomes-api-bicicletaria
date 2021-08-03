using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bicicletaria_ploomes.Models
{
  public class User
  {
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Nome de usuário não informado")]
    [MinLength(10, ErrorMessage = "Por favor digite o nome completo")]
    [MaxLength(60, ErrorMessage = "Nome deve conter no máximo 60 caracteres")]
    public string UserName { get; set; }

    public DateTime DateCreate { get; set; }

    public bool UserActive { get; private set; }

    public List<Product> Product { get; set; }

    public void ActiveUser()
    {
      UserActive = true;
    }

    public void DisableUser()
    {
      UserActive = false;
    }
  }
}