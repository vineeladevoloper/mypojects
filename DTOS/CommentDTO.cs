namespace taskmanagement2.DTOS
{
    public class CommentDTO
    {
        public int CommentId { get; set; }
        public string? CommentText { get; set; }
        public string? UserId { get; set; }
        public int PostId { get; set; }
        public string User { get;  set; }
        public string Post { get;  set; }
    }
}