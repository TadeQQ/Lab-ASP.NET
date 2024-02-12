using Lab3___zadanieContextConnection;
using Lab3___zadanieContextConnection.Entities;
using Lab3zadanie.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab3zadanie.Models
{
    public class EFEmployeeService : IEmployeeService
    {
        private readonly AppDbContext _context;
        public EFEmployeeService(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public int Add(EmployeeEntity employeeEntity)
        {
            var e = _context.Employees.Add(employeeEntity);
            _context.SaveChanges();
            return e.Entity.Id;
        }

        public void Delete(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
        }

        public List<EmployeeEntity> FindAll()
        {
            return _context.Employees
                           .ToList();
        }

        public EmployeeEntity? FindById(int id)
        {
            return _context.Employees
                                .FirstOrDefault(a => a.Id == id);
        }

        public void Update(EmployeeEntity employeeEntity)
        {
            var existingEmployee = _context.Employees.Find(employeeEntity.Id);
            if (existingEmployee != null)
            {
                _context.Entry(existingEmployee).CurrentValues.SetValues(employeeEntity);
                _context.SaveChanges();
            }
        }
    }
}
