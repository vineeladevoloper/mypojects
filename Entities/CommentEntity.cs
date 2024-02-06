using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.Hosting;
using taskmanagement2.DTOS;

namespace taskmanagement2
{ 
    [Table("Comments")]
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        [Required]
        public string? CommentText { get; set; }
        [Required]
        public string? UserId { get; set; }
        [Required]
        public int PostId { get; set; }
        [Required]
        public DateTime DateandTime { get; set; }
        public string? ValidatedOrBlocked { get; set; }
        public string? ActionDoneById { get; set; }
        [ForeignKey("UserId")]
        public UserDTO User { get; set; }
        [ForeignKey("PostId")]
        public string Post { get; set; }
        [ForeignKey("ActionDoneById")]
        public UserDTO ActionDoneuser { get; set; }
    }
}