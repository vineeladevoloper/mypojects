using Microsoft.AspNetCore.Mvc;
using taskmanagement2.Irepos;

namespace taskmanagement2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FollowerController : ControllerBase
    {
        private readonly IFollower _followerService;

        public FollowerController(IFollower followerService)
        {
            _followerService = followerService;
        }

        [HttpPost("sendFollowRequest")]
        public IActionResult SendFollowRequest([FromBody] FollowRequestDto followRequestDto)
        {
            _followerService.SendFollowRequest(followRequestDto.UserId, followRequestDto.FollowerId);
            return Ok();
        }

        [HttpPost("acceptFollowRequest")]
        public IActionResult AcceptFollowRequest([FromBody] FollowRequestDto followRequestDto)
        {
            _followerService.AcceptFollowRequest(followRequestDto.UserId, followRequestDto.FollowerId);
            return Ok();
        }

        [HttpGet("checkFollowing/{userId}/{followerId}")]
        public IActionResult CheckFollowing(string userId, string followerId)
        {
            bool isFollowing = _followerService.CheckFollowing(userId, followerId);
            return Ok(isFollowing);
        }

        [HttpGet("getFollowers/{userId}")]
        public IActionResult GetFollowers(string userId)
        {
            var followers = _followerService.GetFollowers(userId);
            return Ok(followers);
        }

        [HttpGet("getFollowing/{userId}")]
        public IActionResult GetFollowing(string userId)
        {
            var following = _followerService.GetFollowing(userId);
            return Ok(following);
        }

        [HttpGet("getPendingFollowRequests/{userId}")]
        public IActionResult GetPendingFollowRequests(string userId)
        {
            var pendingRequests = _followerService.GetPendingFollowRequests(userId);
            return Ok(pendingRequests);
        }

        // Additional actions can be added based on the requirements.
    }

    public class FollowRequestDto
    {
        public string UserId { get; set; }
        public string FollowerId { get; set; }
    }
}
