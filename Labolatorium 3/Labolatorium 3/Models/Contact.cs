using Data.Entities;
using Data.Migrations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Lab_3.Models
{
    public class Contact
    {
        [HiddenInput]
        public int Id { get; set; }
        [Required(ErrorMessage = "Pole imię jest wymagane.")]
        [StringLength(maximumLength: 50, ErrorMessage = "Zbyt długie imie, max 50 znaków")]
        [Display(Name="Imię")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Pole email jest wymagane.")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email{ get; set; }
        [Display(Name = "Numer telefonu")]
        public string? Phone { get; set; }
        [Display(Name = "Data urodzenia")]
        [Required(ErrorMessage = "Pole data urodzenia jest wymagane.")]
        [DataType(DataType.Date)]
        public DateTime Birth { get; set; }
        [Display(Name = "Priorytet")]
        public Priority Priority { get; set; }
        [HiddenInput]
        public DateTime Created { get; set; }
        [HiddenInput]
        public int? OrganizationId { get; set; }
        [ValidateNever]
        public List<SelectListItem>? OrganizationList { get; set; }
    }
}
