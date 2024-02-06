using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using taskmanagement2;
using taskmanagement2.DTOS;

[ApiController]
[Route("api/[controller]")]
public class LikeController : ControllerBase
{
    private readonly ILikeRepository _likeRepository;

    public LikeController(ILikeRepository likeRepository)
    {
        _likeRepository = likeRepository;
    }

    [HttpPost]
    public async Task<IActionResult> AddLike([FromBody] LikeDTO likeDTO)
    {
        var result = await _likeRepository.AddLike(likeDTO);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllLikes()
    {
        var result = await _likeRepository.GetAllLike();
        return Ok(result);
    }

    [HttpGet("{likeId}")]
    public async Task<IActionResult> GetLikeById(int likeId)
    {
        var result = await _likeRepository.GetLikeById(likeId);
        if (result != null)
        {
            return Ok(result);
        }
        return NotFound();
    }

    [HttpGet("postUser/{postId}/{userId}")]
    public async Task<IActionResult> GetLikeByPostAndUser(int postId, string userId)
    {
        var result = await _likeRepository.GetLikeByPostAndUser(postId, userId);
        return Ok(result);
    }

    [HttpDelete("{likeId}")]
    public async Task<IActionResult> DeleteLike(int likeId)
    {
        var result = await _likeRepository.DeleteLike(likeId);
        if (result)
        {
            return Ok(new ResultModel { Success = true, Message = "Like deleted successfully." });
        }
        return NotFound(new ResultModel { Success = false, Message = "Like not found." });
    }

    [HttpDelete("postUser/{postId}/{userId}")]
    public async Task<IActionResult> DeleteLikeByUserPost(int postId, string userId)
    {
        var result = await _likeRepository.DeleteLikeByUserPost(postId, userId);
        if (result)
        {
            return Ok(new ResultModel { Success = true, Message = "Like deleted successfully." });
        }
        return NotFound(new ResultModel { Success = false, Message = "Like not found." });
    }

    [HttpGet("post/{postId}")]
    public async Task<IActionResult> GetLikesByPost(int postId)
    {
        var result = await _likeRepository.GetLikesByPost(postId);
        return Ok(result);
    }
}
