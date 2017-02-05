using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompanyAnalysis2.WebApp.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Du måste ange en e-postadress")]
        [EmailAddress(ErrorMessage = "Du måste ange en e-postadress")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Lösenord är obligatoriskt")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage="Lösenorden stämmer inte överens")]
        public string Password2 { get; set; }
        [Required(ErrorMessage = "Förnamn är obligatoriskt")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Efternamn är obligatoriskt")]
        public string LastName { get; set; }
    }
}