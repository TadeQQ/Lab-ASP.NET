namespace Laboratorium_2.Models
{
    public class Birth
    {
        public string? name { get; set; }
        public DateOnly? bDate { get; set; }
        public DateOnly? dateToday { get; set; }
        public bool IsValid()
        {
            return name != null && bDate != null;
        }
    }
}
