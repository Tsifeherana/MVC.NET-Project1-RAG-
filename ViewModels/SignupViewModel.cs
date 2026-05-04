using System.ComponentModel.DataAnnotations;

namespace Projet1.ViewModels;

public class SignUpViewModel
{
    [Required(ErrorMessage = "L'email est obligatoire.")]
    [EmailAddress(ErrorMessage = "Format d'email invalide.")]
    public string Mail { get; set; } = string.Empty;

    [Required(ErrorMessage = "Le nom est obligatoire.")]
    [StringLength(100, ErrorMessage = "Le nom ne doit pas depasser 100 caracteres.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Le numero d'inscription est obligatoire.")]
    [StringLength(50, ErrorMessage = "Le numero d'inscription ne doit pas depasser 50 caracteres.")]
    public string NoInscription { get; set; } = string.Empty;

    [Required(ErrorMessage = "Le numero de telephone est obligatoire.")]
    [Phone(ErrorMessage = "Numero de telephone invalide.")]
    public string Phone { get; set; } = string.Empty;

    [Required(ErrorMessage = "Le mot de passe est obligatoire.")]
    [StringLength(100, MinimumLength = 8, ErrorMessage = "Le mot de passe doit contenir au moins 8 caracteres.")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;

    [Required(ErrorMessage = "La confirmation du mot de passe est obligatoire.")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Les mots de passe ne correspondent pas.")]
    public string ConfirmPassword { get; set; } = string.Empty;
}