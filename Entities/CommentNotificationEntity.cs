using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace taskmanagement2.Entities
{
    public class CommentNotificationEntity
    {

        [Key]
        public int CommentNotificationId { get; set; }

        [Required]
        public string SenderId { get; set; }

        [ForeignKey("SenderId")]
        public string Sender { get; set; }

        [Required]
        public string ReceiverId { get; set; }

        [ForeignKey("ReceiverId")]
        public string Receiver { get; set; }

        [Required]
        public int PostId { get; set; }

        [ForeignKey("PostId")]
        public Post Post { get; set; }

        [Required]
        public string CommentText { get; set; }

        public DateTime NotificationTime { get; set; }

        public int Read { get; set; } = 0;
        public string SenderName { get;  set; }
        public string ReceiverName { get; internal set; }
        public string PostTitle { get; internal set; }
    }
}
