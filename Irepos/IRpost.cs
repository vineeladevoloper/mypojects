using taskmanagement2.DTOS;

namespace taskmanagement2.Irepos
{
    public interface IRpost
    {
        public interface IPostRepository
        {
            void AddPost(PostwithoutIdDto postWithoutIdDto);
            List<PostDTO> GetAllPosts();
            PostDTO GetPostById(int postId);
            void UpdatePost(int postId, PostwithoutIdDto updatedPost);
            void DeletePost(int postId);
        }
    }
}
