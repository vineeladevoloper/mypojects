using taskmanagement2.DTOS;

namespace taskmanagement2.Irepos
{
    public class ICommentNotification
    {
        
    
        public interface ICommentNotificationService
        {
            void AddCommentNotification(CommentNotificationDTO notify);
            List<CommentNotificationDTO> GetAllCommentNotifications();
            List<CommentNotificationDTO> GetCommentNotificationsByUser(string userId);
            void MarkAsRead(int commentNotificationId);
        }
    }

}


