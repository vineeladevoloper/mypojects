using System;
using taskmanagement2.DTOS; // Assuming your DTOs are in this namespace
namespace taskmanagement2
{
    public class LikeDTO
    {
        public int LikeId { get;  set; }
        public int PostId { get;  set; }
        public string UserId { get; set; }
        public DateTime DateTime { get;  set; }
        public UserDTO User { get;  set; }
        public PostDTO Post { get;  set; }
    }
}
