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
    public class LikeManager: ILikeService
    {
        private readonly ILikeDal _likeDal;

        public LikeManager(ILikeDal entity)
        {
            _likeDal = entity;
        }

        public Like Add(Like entity)
        {
            return _likeDal.Add(entity);
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Like Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Like> GetAll()
        {
            return null;
        }

        public List<Like> GetAll(Expression<Func<Like, bool>> predicate)
        {
            return _likeDal.GetAll(predicate);
        }

        public int Save(Like entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Like entity)
        {
            throw new NotImplementedException();
        }
    }
}
