using Lab3___zadanieContextConnection.Entities;
using Lab3zadanie.Models;
using System.Linq;

namespace Lab3zadanie.Models
{
    public class EmployeeMapper
    {
        public static EmployeeEntity ToEntity(Employee model)
        {
            return new EmployeeEntity()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PESEL = model.PESEL,
                Position = model.Position,
                Department = model.Department,
                EmploymentDate = model.EmploymentDate,
                TerminationDate = model.TerminationDate
            };
        }

        public static Employee FromEntity(EmployeeEntity entity)
        {
            return new Employee()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                PESEL = entity.PESEL,
                Position = entity.Position,
                Department = entity.Department,
                EmploymentDate = entity.EmploymentDate,
                TerminationDate = entity.TerminationDate
            };
        }
    }
}
