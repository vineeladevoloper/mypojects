using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using taskmanagement2.Irepos;

namespace taskmanagement2.Entities
{
    
        [Table("Followers")]
        public class Follower
        {
            [Key]
            public int Id { get; set; }

            [Required]
            public string UserId { get; set; }

            [Required]
            public string FollowerId { get; set; }
            public int Status { get; set; } = 0;

            [ForeignKey("UserId")]
            public UserEntity User { get; set; }

            [ForeignKey("FollowerId")]
            public UserEntity FollowerUser { get; set; }
        }
    }

