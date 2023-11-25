namespace WebApplication2.Models
{
    public interface IContactService
    {
        int Add(Employee book);
        void Delete(int id);
        void Update(Employee book);
        List<Employee> FindAll();
        Employee? FindById(int id);
    }
}
