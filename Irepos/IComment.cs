using System.Collections.Generic;
using taskmanagement2.DTOS;

namespace taskmanagement2.Irepos
{
    public interface ICommentService
    {
        void AddComment(CommentDTO commentDto);
     
        List<CommentDTO> GetAllCommentsForPost(int postId,MyDbContext myDbContext);
    }
}
