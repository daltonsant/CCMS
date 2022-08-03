using System.ComponentModel.DataAnnotations;

namespace CCMS.NEOPE.Application.ViewModels;

public class RegisterViewModel
{
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(80, ErrorMessage = "Use menos caracteres")]
    [Display(Name = "Nome completo")]
    public string FullName { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(10, ErrorMessage = "Use menos caracteres")]
    [Display(Name = "Login do usuário")]
    public string UserName { get; set; }
    
    public string? Photo { get; set; }
    
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(80, ErrorMessage = "Use menos caracteres")]
    [EmailAddress(ErrorMessage = "Email inválido")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [DataType(DataType.Password)]
    [Display(Name = "Senha")]
    public string Password { get; set; }
    
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [DataType(DataType.Password)]
    [Display(Name = "Confirme sua senha")]
    [Compare("Password",ErrorMessage = "As senhas não conferem")]
    public string ConfirmPassword { get; set; }
}


/* string Code { get; set; }
    string FullName { get; set; }
    string Photo { get; set; }
    
    bool IsActive { get; set; }
    */