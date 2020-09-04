using System;
using System.ComponentModel.DataAnnotations;

namespace quotingDojo.Models
{
    public class Quote
    {
        [Required]
        [Display(Name="Author Name")]
        public string Name {get;set;}
        [Required]
        [Display(Name =  "Quotes")]
        public string _Quote {get;set;}
    }
}