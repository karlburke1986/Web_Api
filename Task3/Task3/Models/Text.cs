using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Task3.Models
{
    public class Text
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public int NumberSender { get; set; }
        [Required]
        public int NumberReceiver { get; set; }
        [StringLength(140, ErrorMessage = "Message can only be 140 characters long")]
        public string Message { get; set; }
    }

    public class TextContext : DbContext
    {
        public TextContext() : base("DefaultConnection")
        {
            Database.SetInitializer<TextContext>(null);
        }
        public DbSet<Text> Texts { get; set; }


        //public DbSet<Text> Texts { get; set; }

    }
}