using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Lab3zadanie.Models
{
    public class Employee
    {
        [HiddenInput]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Proszę podać imię.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwisko.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Proszę podać PESEL.")]
        [StringLength(11, ErrorMessage = "PESEL musi mieć 11 cyfr.")]
        public string PESEL { get; set; }

        [Required(ErrorMessage = "Proszę podać stanowisko.")]
        public string Position { get; set; }

        [Required(ErrorMessage = "Proszę podać oddział.")]
        public string Department { get; set; }

        [Required(ErrorMessage = "Proszę podać datę zatrudnienia.")]
        public DateTime EmploymentDate { get; set; }

        public DateTime? TerminationDate { get; set; }
    }
}
