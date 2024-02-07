using taskmanagement2.Entities;
using taskmanagement2.Irepos;

namespace taskmanagement2.services
{
        public class FollowerService : IFollower
        {
            private readonly MyDbContext context;

            public string UserId { get; private set; }
            public string FollowerId { get; private set; }
            public int Status { get; private set; }

            public FollowerService(MyDbContext context)
            {
                this.context = context;
            }

            public void SendFollowRequest(string userId, string followerId)
            {
                try
                {
                    var followRequest = new Follower
                    {
                        UserId = userId,
                        FollowerId = followerId,
                        Status = 0
                    };   
                    context.followers.Add(followRequest);
                    context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            // Accept a follow request
            public void AcceptFollowRequest(string userId, string followerId)
            {
                var followRequest = context.followers
                    .SingleOrDefault(f => f.UserId == userId && f.FollowerId == followerId && f.Status == 0);

                if (followRequest != null)
                {
                    followRequest.Status = 1;
                    context.SaveChanges();
                }
            }

            public bool CheckFollowing(string userId, string followerId)
            {
                var followRequest = context.followers
                    .SingleOrDefault(f => f.UserId == userId && f.FollowerId == followerId);

                return followRequest != null;
            }

            // Get followers for a user
            public List<UserEntity> GetFollowers(string userId)
            {
                return context.followers
                    .Where(f => f.UserId == userId && f.Status == 1)
                .Select(f => f.FollowerUser)
                    .ToList();
            }

            public List<UserEntity> GetFollowing(string userId)
            {
                return context.followers
                    .Where(f => f.FollowerId == userId && f.Status == 1)
                    .Select(f => f.User)
                    .ToList();
            }

            // Get pending follow requests for a user
            public List<UserEntity> GetPendingFollowRequests(string userId)
            {
                return context.followers
                    .Where(f => f.UserId == userId && f.Status == 0) // 0 for pending requests
                    .Select(f => f.FollowerUser)
                    .ToList();
            }
        }
    }

