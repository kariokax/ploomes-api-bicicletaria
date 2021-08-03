using System;
using System.ComponentModel.DataAnnotations;

namespace Bicicletaria_ploomes.Models
{
  public class Product
  {

    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Id do criador necessário")]
    public int CreatorUserId { get; set; }

    [Required(ErrorMessage = "Id do criador necessário")]
    [MinLength(10, ErrorMessage = "Por favor detalher melhor o nome do produto")]
    [MaxLength(255, ErrorMessage = "Nome deve conter no máximo 255 caracteres")]
    public string NameProduct { get; set; }

    [Required(ErrorMessage = "Valor deve ser informado")]
    [Range(1, int.MaxValue, ErrorMessage = "Valor deve ser maior que zero")]
    public decimal Value { get; set; }

    [MaxLength(ErrorMessage = "A descrição deve conter no máximo 1024 caracteres")]
    public string Description { get; set; }

    [Required(ErrorMessage = "Por favor, adicione o tamanho do produto")]
    public string Size { get; set; }

    public string RecordIdentifier { get; set; }

    public DateTime DateCreate { get; set; }

    public Boolean Validate()
    {
      if (string.IsNullOrEmpty(NameProduct))
        throw new Exception("O Produto deve possuir um nome");

      if (Value <= decimal.Zero)
        throw new Exception("O Produto deve possuir um valor maior que zero");

      if (string.IsNullOrEmpty(Size))
        throw new Exception("O produto deve possuir um tamanho");

      return true;
    }

    public void GenerateRecordIdentifier()
    {
      if (string.IsNullOrEmpty(RecordIdentifier))
        RecordIdentifier = Guid.NewGuid().ToString("N");
    }

    public void SetRecordIdentifier(Product product)
    {
      this.RecordIdentifier = product.RecordIdentifier;
    }
  }
}