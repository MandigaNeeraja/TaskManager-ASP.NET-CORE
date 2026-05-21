using System.ComponentModel.DataAnnotations;

namespace TaskManager.Model
{
    public class Taskitem
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
    }
}
