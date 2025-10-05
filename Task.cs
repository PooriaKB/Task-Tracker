namespace TaskTracker
{
    public class Task
    {
        public int ID { get; set; }
        public string? Description { get; set; }
        public string? status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? updatedAt { get; set; }

        public Task(string Description, string status = "todo") 
        {
            this.Description = Description;
            this.status = status;
            this.CreatedAt = DateTime.Now;
        }

    }
}
