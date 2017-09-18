using System.ComponentModel.DataAnnotations;

namespace Task2.Models
{
    public class Text
    {
        [Required]
        public int NumberSender { get; set; }
        [Required]
        public int NumberReceiver { get; set; }
        [StringLength(140, ErrorMessage ="Message can only be 140 characters long")]
        public string Message { get; set; }
    }
}