using DatingApp2.DTO;
using DatingApp2.Helper;
using DatingApp2.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatingApp2.Interfaces
{
    public interface ILikesRepository
    {
        Task<UserLike> GetUserLike(int sourceUserId, int targetUserId);
        Task<AppUser> GetUserWithLikes(int userId);
        Task<PagedList<LikeDTO>> GetUserLikes(LikeParams likesParams);
    }
}
