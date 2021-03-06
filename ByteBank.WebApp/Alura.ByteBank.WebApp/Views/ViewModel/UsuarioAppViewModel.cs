using System.ComponentModel.DataAnnotations;

namespace Alura.ByteBank.WebApp.Views.ViewModel
{
  public class UsuarioAppViewModel
  {
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Senha { get; set; }
  }
}
