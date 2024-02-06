using taskmanagement2.DTOS;
using static taskmanagement2.Irepos.IRpost;

namespace taskmanagement2.services
{


    public class PostRepository : IPostRepository
    {
        private List<PostDTO> posts;

        public PostRepository()
        {
            posts = new List<PostDTO>();
        }

        public void AddPost(PostwithoutIdDto postWithoutIdDto)
        {
            int postId = GenerateUniqueId();

            var postDto = new PostDTO
            {
                PostId = postId,
                UserId = postWithoutIdDto.UserId,
                Title = postWithoutIdDto.Title,
                Description = postWithoutIdDto.Description,
                Img = postWithoutIdDto.Img,
                DateandTime = DateTime.Now
            };

            posts.Add(postDto);
        }

        public List<PostDTO> GetAllPosts()
        {
            return posts.Select(p => new PostDTO
            {
                PostId = p.PostId,
                UserId = p.UserId,
                Title = p.Title,
                Description = p.Description,
                Img = p.Img,
                DateandTime = p.DateandTime,
                UserName = p.UserName,
                UserType = p.UserType
            }).ToList();
        }

        public PostDTO GetPostById(int postId)
        {
            return posts.FirstOrDefault(p => p.PostId == postId);
        }

        public void UpdatePost(int postId, PostwithoutIdDto updatedPost)
        {
            var existingPost = posts.FirstOrDefault(p => p.PostId == postId);

            if (existingPost != null)
            {
                // Update the properties with non-null values from the updatedPost
                existingPost.UserId = updatedPost.UserId ?? existingPost.UserId;
                existingPost.Title = updatedPost.Title ?? existingPost.Title;
                existingPost.Description = updatedPost.Description ?? existingPost.Description;
                existingPost.Img = updatedPost.Img ?? existingPost.Img;
            }
            // You might want to handle the case where the post with the specified ID is not found.
        }

        public void DeletePost(int postId)
        {
            var postToRemove = posts.FirstOrDefault(p => p.PostId == postId);

            if (postToRemove != null)
            {
                posts.Remove(postToRemove);
            }
            // You might want to handle the case where the post with the specified ID is not found.
        }

        private int GenerateUniqueId()
        {
            return posts.Count + 1;
        }
    }
}



