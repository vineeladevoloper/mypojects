using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using taskmanagement2.DTOS;
using static taskmanagement2.Irepos.IRpost;

namespace taskmanagement2.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;

        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [HttpGet(Name = nameof(GetAllPosts))]
        public ActionResult<IEnumerable<PostDTO>> GetAllPosts()
        {
            var posts = _postRepository.GetAllPosts();
            return Ok(posts);
        }

        [HttpGet("{postId}", Name = nameof(GetPostById))]
        public ActionResult<PostDTO> GetPostById(int postId)
        {
            var post = _postRepository.GetPostById(postId);

            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        [HttpPost(Name = nameof(AddPost))]
        public ActionResult AddPost(PostwithoutIdDto postWithoutIdDto)
        {
            _postRepository.AddPost(postWithoutIdDto);
            return Ok();
        }

        [HttpPut("{postId}", Name = nameof(UpdatePost))]
        public ActionResult UpdatePost(int postId, PostwithoutIdDto updatedPost)
        {
            var existingPost = _postRepository.GetPostById(postId);

            if (existingPost == null)
            {
                return NotFound();
            }

            _postRepository.UpdatePost(postId, updatedPost);
            return Ok();
        }

        [HttpDelete("{postId}", Name = nameof(DeletePost))]
        public ActionResult DeletePost(int postId)
        {
            var existingPost = _postRepository.GetPostById(postId);

            if (existingPost == null)
            {
                return NotFound();
            }

            _postRepository.DeletePost(postId);
            return Ok();
        }
    }
}
 