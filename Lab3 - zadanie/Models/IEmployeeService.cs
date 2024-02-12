using Lab3___zadanieContextConnection.Entities;

namespace Lab3zadanie.Models
{
    public interface IEmployeeService
    {
        int Add(EmployeeEntity employeeEntity);
        void Update(EmployeeEntity employeeEntity);
        void Delete(int id);
        EmployeeEntity? FindById(int id);
        List<EmployeeEntity> FindAll();
    }
}
