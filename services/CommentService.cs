using taskmanagement2;
using taskmanagement2.DTOS;
using taskmanagement2.Irepos;
using taskmanagement2.Entities;

public class CommentService : ICommentService
{
    private readonly MyDbContext _context;

    public CommentService(MyDbContext context)
    {
        this._context = context;
    }

    public void AddComment(CommentDTO commentDto)
    {
        try
        {
            var comment = new Comment
            {
                CommentId = commentDto.CommentId,
                CommentText = commentDto.CommentText,
                UserId = commentDto.UserId,
                PostId = commentDto.PostId,
                Post = commentDto.Post,

                // Add other properties as needed
            };

            _ = _context.Comments.Add(comment);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            // Handle or log the exception as needed
            throw new ApplicationException("Error while adding comment.", ex);
        }
    }

    public List<CommentDTO> GetAllCommentsForPost(int postId, MyDbContext myDbContext)
    {
        try
        {
            List<CommentDTO> commentDTOsForPost = myDbContext.Comments
                .Where(c => c.PostId == postId)
                .Select(comment => new CommentDTO
                {
                    CommentId = comment.CommentId,
                    CommentText = comment.CommentText,
                    UserId = comment.UserId,
                    PostId = comment.PostId,
                    Post = comment.Post,
                    // Assuming Title is the property in PostDTO
                    // Add other properties as needed
                })
                .ToList();

            return commentDTOsForPost;
        }
        catch (Exception ex)
        {
            // Handle or log the exception as needed
            throw new ApplicationException("Error while retrieving comments for the post.", ex);
        }
    }
}
