namespace Lab_3.Models
{
    public class CurrentDateTimeProvider : IDateTimeProvider
    {
        public DateTime date()
        {
            return DateTime.Now;
        }
    }
}
