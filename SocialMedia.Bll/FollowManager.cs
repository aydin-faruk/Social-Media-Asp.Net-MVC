using SocialMedia.Dal.Abstract;
using SocialMedia.Entity.Models;
using SocialMedia.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace SocialMedia.Bll
{
    public class FollowManager:IFollowService
    {
        private readonly IFollowDal _followDal;

        public FollowManager(IFollowDal entity)
        {
            _followDal = entity;
        }

        public Follow Add(Follow entity)
        {
            return _followDal.Add(entity);
        }

        public bool Delete(int id)
        {
            var fllw = _followDal.Delete(id);
            return true;
        }

        public Follow Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Follow> GetAll()
        {
            return null;
        }

        public List<Follow> GetAll(Expression<Func<Follow, bool>> predicate)
        {
            return _followDal.GetAll(predicate);
        }

        public List<User> GetFollow(int userId)
        {
            return _followDal.GetFollow(userId);
        }

        public int Save(Follow entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Follow entity)
        {
            throw new NotImplementedException();
        }
    }
}
