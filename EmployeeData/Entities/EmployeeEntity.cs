using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Lab3___zadanieContextConnection.Entities
{
    [Table("Employees")]
    public class EmployeeEntity
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
    };

}
