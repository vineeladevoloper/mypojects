using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace taskmanagement2.Entities
{
    [Table("Posts")]
    public class Post
    {
        [Key]
        public int PostId { get; set; }

        [ForeignKey("User")]
        public string? UserId { get; set; }
        public virtual UserEntity User { get; set; }

        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Img { get; set; }
        public DateTime DateandTime { get; set; }

        [ForeignKey("Author")]
        public string? UserName { get; set; }
        public virtual UserEntity Author { get; set; }
        public string? UserType { get; set; }
        public int Active { get; internal set; }
    }

}