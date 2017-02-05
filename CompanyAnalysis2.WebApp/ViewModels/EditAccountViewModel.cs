using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompanyAnalysis2.WebApp.ViewModels
{
    public class EditAccountViewModel
    {
        public string Email { get; set; }
        [Required(ErrorMessage = "Förnamn är obligatoriskt")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Efternamn är obligatoriskt")]
        public string LastName { get; set; }
    }
}