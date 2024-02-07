using System;
using System.Collections.Generic;
using taskmanagement2.Entities;

namespace taskmanagement2.Irepos
{
    public interface IFollower
    {
        void SendFollowRequest(string userId, string followerId);
        List<UserEntity> GetPendingFollowRequests(string userId);
        List<UserEntity> GetFollowers(string userId);
        void AcceptFollowRequest(string userId, string followerId);
        bool CheckFollowing(string userId, string followerId);
        List<UserEntity> GetFollowing(string userId);
    }
}
