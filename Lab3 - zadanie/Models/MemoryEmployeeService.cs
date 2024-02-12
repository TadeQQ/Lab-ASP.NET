using Lab3zadanie.Models;
using Lab3___zadanieContextConnection.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Lab3zadanie.Models
{
    public class MemoryEmployeeService : IEmployeeService
    {
        private static readonly Dictionary<int, EmployeeEntity> _employees = new Dictionary<int, EmployeeEntity>();
        private static int employeeId = 1;

        public int Add(EmployeeEntity employeeEntity)
        {
            employeeEntity.Id = employeeId++;
            _employees.Add(employeeEntity.Id, employeeEntity);
            return employeeEntity.Id;
        }

        public void Delete(int id)
        {
            _employees.Remove(id);
        }

        public List<EmployeeEntity> FindAll()
        {
            return _employees.Values.ToList();
        }

        public EmployeeEntity? FindById(int id)
        {
            _employees.TryGetValue(id, out var employee);
            return employee;
        }

        public void Update(EmployeeEntity employeeEntity)
        {
            if (_employees.ContainsKey(employeeEntity.Id))
            {
                _employees[employeeEntity.Id] = employeeEntity;
            }
        }
    }
}
