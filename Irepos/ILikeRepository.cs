using System.Collections.Generic;
using System.Threading.Tasks;
using taskmanagement2;
using taskmanagement2.DTOS;

public interface ILikeRepository
{
    Task<LikeDTO> AddLike(LikeDTO likeDTO);
    Task<IEnumerable<LikeDTO>> GetAllLike();
    Task<LikeDTO> GetLikeById(int likeId);
    Task<ResultModel> GetLikeByPostAndUser(int postId, string userId); // Corrected return type
    Task<bool> DeleteLikeByUserPost(int postId, string userId);
    Task<IEnumerable<LikeDTO>> GetLikesByPost(int postId);
    Task<bool> DeleteLike(int likeId);
}
