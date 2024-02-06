using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using taskmanagement2.Entities;

namespace taskmanagement2.services
{
    [Table("Likes")]
    public class Like
    {
        [Key]
        public int LikeId { get; set; }
        [Required]
        public int PostId { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        [ForeignKey("UserId")]
        public string User { get; set;}
        [ForeignKey("PostId")]
        public string Post { get; set; }
    }
}
