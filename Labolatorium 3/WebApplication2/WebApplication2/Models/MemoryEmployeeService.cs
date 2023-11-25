namespace WebApplication2.Models
{
    public class MemoryEmployeeService : IEmployeesService
    {
        private Dictionary<int, Employee> _items = new Dictionary<int, Employee>();
        public int Add(Employee item)
        {
            int id = _items.Keys.Count != 0 ? _items.Keys.Max() : 0;
            item.Id = id + 1;
            _items.Add(item.Id, item);
            return item.Id;
        }

        public void Delete(int id)
        {
            _items.Remove(id);
        }

        public List<Employee> FindAll()
        {
            return _items.Values.ToList();
        }

        public Employee? FindById(int id)
        {
            return _items[id];
        }

        public void Update(Employee item)
        {
            _items[item.Id] = item;
        }
    }
}
