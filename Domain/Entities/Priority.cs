namespace Domain.Entities
{
    public class Priority
    {
        public int PriorityId { get; set; }

        public string PriorityName { get; set; } = string.Empty;

        public int ExpectedDays { get; set; }
    }
}
