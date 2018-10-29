using SocialMedia.Dal.Abstract;
using SocialMedia.Dal.Concrete.Entityfamework.Context;
using SocialMedia.Entity.Models;
using SocialMedia.Entity.PocoModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;

namespace SocialMedia.Dal.Concreate.Entityframework.Repository
{

    public class EfFollowRepository : IFollowDal
    {
        private readonly SocialMediaDbContext _socialMediaDbContext = new SocialMediaDbContext();

        public Follow Add(Follow entity)
        {
            try
            {
                _socialMediaDbContext.Follows.RemoveRange(_socialMediaDbContext.Follows.Local.Where(x => x.FollowID == 0).ToList());
                _socialMediaDbContext.Follows.AddOrUpdate(entity);
                _socialMediaDbContext.SaveChanges();
            }
            catch (Exception e)
            {

            }

            return entity;

        }

        public List<Follow> GetAll(Expression<Func<Follow, bool>> predicate)
        {
            return _socialMediaDbContext.Follows.AsNoTracking().Where(predicate).OrderByDescending(x => x.Date).ToList();
        }

        public List<User> GetFollow(int userId)
        {
            var x = _socialMediaDbContext.Users.AsEnumerable().Join(
                    _socialMediaDbContext.Follows.AsEnumerable().Where(a => a.UserOneID == userId), k => k.UserID, ky => ky.UserTwoID, (k, ky) => new User()
                    {
                        UserID = k.UserID,
                        Name = k.Name,
                        Surname = k.Surname,
                        PictureLink = k.UserPicture    

                    }).OrderBy(s => s.Name).ToList();
            return x;
        }

        public bool Delete(Follow entity)
        {
            _socialMediaDbContext.Follows.Remove(entity);
            return _socialMediaDbContext.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var entity = this._socialMediaDbContext.Follows.FirstOrDefault(x => x.UserTwoID == id);
            return Delete(entity);
        }
    }
}
