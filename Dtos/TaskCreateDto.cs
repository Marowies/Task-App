namespace TaskApp.Dtos
{
    public class TaskCreateDto
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? DueDate { get; set; }
        public string? Priority { get; set; }
    }
}
