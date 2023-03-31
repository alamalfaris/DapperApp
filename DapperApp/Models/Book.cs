namespace DapperApp.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string PublishedYear { get; set; } = string.Empty;
        public bool IsDeleted { get; set; } = false;
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedTime { get; set; }
    }
}
