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

    public class EfUserRepository:IUserDal
    {
        private readonly SocialMediaDbContext _socialMediaDbContext = new SocialMediaDbContext();

        public User Add(User entity)
        {
            try
            {
                _socialMediaDbContext.Users.RemoveRange(_socialMediaDbContext.Users.Local.Where(x => x.UserID == 0).ToList());
                _socialMediaDbContext.Users.AddOrUpdate(entity);
                _socialMediaDbContext.SaveChanges();
            }
            catch(Exception e)
            {

            }

            return entity;

        }

        public User Login(User user)
        {
            return _socialMediaDbContext.Users.AsNoTracking().SingleOrDefault(x => x.Mail == user.Mail && x.Password == user.Password);
        }

        public List<User> GetAll(Expression<Func<User, bool>> predicate)
        {
            return _socialMediaDbContext.Users.AsNoTracking().Where(predicate).OrderByDescending(x => x.UserID).ToList();
        }

        public List<PocoNoFollowUser> GetUsers(int userId)
        {
            //var x = _socialMediaDbContext.Users.AsEnumerable().Join(
            //    _socialMediaDbContext.Follows.AsEnumerable().Where(w=>w.UserOneID!=userId), u => u.UserID, f => f.FollowID, (u, f) => new PocoNoFollowUser
            //    {
            //        userID = u.UserID,
            //        userName = u.Name,
            //        userSurname = u.Surname,
            //        userPicture = u.UserPicture                   

            //    }).ToList();
            List<PocoNoFollowUser> _followUsers = new List<PocoNoFollowUser>();

            if (_socialMediaDbContext.Follows.Where(o => o.UserOneID == userId).FirstOrDefault() == null)
            {
                User _activeuser = _socialMediaDbContext.Users.Where(o => o.UserID == userId).FirstOrDefault();
                foreach (var item in _socialMediaDbContext.Users.Where(o => o.School == _activeuser.School))
                {
                    _followUsers.Add(new PocoNoFollowUser { userID = item.UserID, userName = item.Name, userPicture = item.UserPicture, userSurname = item.Surname });

                }
            }
            else
            {
                foreach (var item in _socialMediaDbContext.Follows.Where(o => o.UserTwoID != userId && o.UserOneID != userId).ToList())
                {
                    if (_followUsers.Where(o => o.userID == item.UserOneID).FirstOrDefault() == null)
                    {
                        User u = _socialMediaDbContext.Users.Where(o => o.UserID == item.UserTwoID).FirstOrDefault();
                        _followUsers.Add(new PocoNoFollowUser { userID = u.UserID, userName = u.Name, userPicture = u.UserPicture, userSurname = u.Surname });
                    }
                }
            }
            return _followUsers;
        }
    }
}
