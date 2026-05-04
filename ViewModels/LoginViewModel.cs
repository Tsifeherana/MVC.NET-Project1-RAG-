using System.ComponentModel.DataAnnotations;

namespace Projet1.ViewModels;

public class LoginViewModel
{
    [Required(ErrorMessage = "L'email est obligatoire.")]
    [EmailAddress(ErrorMessage="Format d'email Invalide")]
    public string Mail {get; set;} = string.Empty;

    [Required(ErrorMessage = "Le Mot de passe est obligatoir")]
    [DataType(DataType.Password)]
    public string Password {get; set;} = string.Empty;
}