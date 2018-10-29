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
    public class ShareManager:IShareService
    {
        private readonly IShareDal _shareDal;

        public ShareManager(IShareDal entity)
        {
            _shareDal = entity;
        }

        public Share Add(Share entity)
        {
            return _shareDal.Add(entity);
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Share Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Share> GetAll()
        {
            return null;
        }

        public List<Share> GetAll(Expression<Func<Share, bool>> predicate)
        {
            return _shareDal.GetAll(predicate);
        }

        public int Save(Share entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Share entity)
        {
            throw new NotImplementedException();
        }
    }
}
