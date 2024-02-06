using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using taskmanagement2.Irepos;
using taskmanagement2.DTOS;
using static taskmanagement2.Irepos.ICommentNotification;
using taskmanagement2.Entities;

namespace taskmanagement2.services
{
    public class CommentNotificationService : ICommentNotificationService
    {
        private readonly MyDbContext context;

        public CommentNotificationService(MyDbContext context)
        {
            this.context = context;
        }

        public void AddCommentNotification(CommentNotificationDTO notify)
        {
            try
            { 
          
                var commentNotification = new CommentNotificationEntity
                {
                    // Map properties from CommentNotificationDTO to CommentNotification
                    SenderId = notify.SenderId,
                    SenderName = notify.senderName,
                    ReceiverId = notify.ReceiverId,
                    ReceiverName = notify.ReceiverName,
                    PostId = notify.PostId,
                    PostTitle = notify.PostTitle,
                    CommentText = notify.CommentText,
                    NotificationTime = notify.NotificationTime,
                    Read = notify.Read
                };

                context.CommentNotifications.Add(commentNotification);
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<CommentNotificationDTO> GetAllCommentNotifications()
        {
            try
            {
                var notifications = context.CommentNotifications
                    .Include(c => c.Sender)
                    .Include(c => c.Receiver)
                    .Include(c => c.Post)
                    .Where(c => c.Post.Active == 1)
                    .ToList();

                List<CommentNotificationDTO> notificationDTOs = new List<CommentNotificationDTO>();

                foreach (var notification in notifications)
                {
                    CommentNotificationDTO notificationDTO = new CommentNotificationDTO
                    {
                        // Map properties manually from notification to notificationDTO
                        CommentNotificationId = notification.CommentNotificationId,
                        SenderId = notification.SenderId,
                        senderName = notification.SenderName,
                        ReceiverId = notification.ReceiverId,
                        ReceiverName = notification.ReceiverName,
                        PostId = notification.PostId,
                        PostTitle = notification.PostTitle,
                        CommentText = notification.CommentText,
                        NotificationTime = notification.NotificationTime,
                        Read = notification.Read
                    };

                    notificationDTOs.Add(notificationDTO);
                }

                return notificationDTOs;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<CommentNotificationDTO> GetCommentNotificationsByUser(string userId)
        {
            try
            {
                var notifications = context.CommentNotifications
                     .Include(c => c.Sender)
                     .Include(c => c.Receiver)
                     .Include(c => c.Post)
                     .Where(c => c.ReceiverId == userId && c.Post.Active == 1)
                     .ToList();

                List<CommentNotificationDTO> notificationDTOs = new List<CommentNotificationDTO>();

                foreach (var notification in notifications)
                {
                    CommentNotificationDTO notificationDTO = new CommentNotificationDTO
                    {
                        // Map properties manually from notification to notificationDTO
                        CommentNotificationId = notification.CommentNotificationId,
                        SenderId = notification.SenderId,
                        senderName = notification.SenderName,
                        ReceiverId = notification.ReceiverId,
                        ReceiverName = notification.ReceiverName,
                        PostId = notification.PostId,
                        PostTitle = notification.PostTitle,
                        CommentText = notification.CommentText,
                        NotificationTime = notification.NotificationTime,
                        Read = notification.Read
                    };

                    notificationDTOs.Add(notificationDTO);
                }

                return notificationDTOs;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void MarkAsRead(int commentNotificationId)
        {
            try
            {
                var notification = context.CommentNotifications.Find(commentNotificationId);

                if (notification != null)
                {
                    notification.Read = 1;
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
