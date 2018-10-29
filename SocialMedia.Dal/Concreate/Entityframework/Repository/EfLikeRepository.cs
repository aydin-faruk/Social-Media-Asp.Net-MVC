using SocialMedia.Dal.Abstract;
using SocialMedia.Dal.Concrete.Entityfamework.Context;
using SocialMedia.Entity.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;

namespace SocialMedia.Dal.Concreate.Entityframework.Repository
{

    public class EfLikeRepository : ILikeDal
    {
        private readonly SocialMediaDbContext _socialMediaDbContext = new SocialMediaDbContext();

        public Like Add(Like entity)
        {
            try
            {
                _socialMediaDbContext.Likes.RemoveRange(_socialMediaDbContext.Likes.Local.Where(x => x.LikeID == 0).ToList());
                _socialMediaDbContext.Likes.AddOrUpdate(entity);
                _socialMediaDbContext.SaveChanges();
            }
            catch(Exception e)
            {

            }

            return entity;

        }

        public List<Like> GetAll(Expression<Func<Like, bool>> predicate)
        {
            return _socialMediaDbContext.Likes.AsNoTracking().Where(predicate).OrderByDescending(x => x.Date).ToList();
        }

    }
}
