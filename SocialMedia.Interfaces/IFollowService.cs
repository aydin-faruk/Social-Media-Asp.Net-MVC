﻿using SocialMedia.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Interfaces
{
    public interface IFollowService:IGenericService<Follow>
    {
        List<User> GetFollow(int userId);
    }
}
