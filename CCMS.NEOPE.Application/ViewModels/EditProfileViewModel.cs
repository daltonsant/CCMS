using System.ComponentModel.DataAnnotations;

namespace CCMS.NEOPE.Application.ViewModels;

public class EditProfileViewModel
{
    public string? Photo { get; set; }
      
    [DataType(DataType.Password)]
    [Display(Name = "Senha antiga")]
    public string? OldPassword { get; set; }
    
    [DataType(DataType.Password)]
    [Display(Name = "Nova senha")]
    public string? Password { get; set; }
    
    [DataType(DataType.Password)]
    [Display(Name = "Confirme sua nova senha")]
    [Compare("Password",ErrorMessage = "As senhas não conferem")]
    public string? ConfirmPassword { get; set; }
}