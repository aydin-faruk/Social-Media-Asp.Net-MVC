using SocialMedia.Entity.Models;
using SocialMedia.Entity.PocoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Interfaces
{
    public interface IUserService:IGenericService<User>
    {
        List<PocoNoFollowUser> GetUsers(int userId);
    }
}
