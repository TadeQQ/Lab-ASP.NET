namespace Lab3zadanie.Models;
using System.ComponentModel.DataAnnotations;

public enum Department
{
    [Display(Name = "IT")]
    IT,
    [Display(Name = "HR")]
    HR,
    [Display(Name = "Marketing")]
    Marketing,
    [Display(Name = "Sales")]
    Sales,
    [Display(Name = "Finance")]
    Finance,
    [Display(Name = "Other")]
    Other
}

