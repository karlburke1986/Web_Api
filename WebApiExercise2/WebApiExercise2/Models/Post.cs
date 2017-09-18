using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApiExercise2.Models
{
    public class UserPost
    {
        [Required]
        [StringLength(25, MinimumLength = 1, ErrorMessage = "Enter value must be between 1 and 25 characters long")]
        public string Subject { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Message is a max of 100 characters long")]
        public string Message { get; set; }
    }

    public class ForumPost
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public UserPost Post { get; set; }
    }
}