using SocialMedia.Dal.Abstract;
using SocialMedia.Entity.Models;
using SocialMedia.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using SocialMedia.Entity.PocoModels;

namespace SocialMedia.Bll
{
    public class UserManager:IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal entity)
        {
            _userDal = entity;
        }

        public User Add(User entity)
        {
            return _userDal.Add(entity);
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public User Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll(Expression<Func<User, bool>> predicate)
        {
            return _userDal.GetAll(predicate);
        }

        public int Save(User entity)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }

        public List<PocoNoFollowUser> GetUsers(int userId)
        {
            return _userDal.GetUsers(userId);
        }
    }
}
