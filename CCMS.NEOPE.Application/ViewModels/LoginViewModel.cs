using System.ComponentModel.DataAnnotations;

namespace CCMS.NEOPE.Application.ViewModels;

public class LoginViewModel
{
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(10, ErrorMessage = "Use menos caracteres")]
    [Display(Name = "Login do usuário")]
    public string UserName { get; set; }
    
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [DataType(DataType.Password)]
    [Display(Name = "Senha")]
    public string Password { get; set; }
    
    [Display(Name = "Permanecer conectado")]
    public bool IsToRemember { get; set; }
}