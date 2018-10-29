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
    public class ShareFileManager:IShareFileService
    {
        private readonly IShareFileDal _shareFileDal;

        public ShareFileManager(IShareFileDal entity)
        {
            _shareFileDal = entity;
        }

        public ShareFile Add(ShareFile entity)
        {
            return _shareFileDal.Add(entity);
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ShareFile Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<ShareFile> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<ShareFile> GetAll(Expression<Func<ShareFile, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public int Save(ShareFile entity)
        {
            throw new NotImplementedException();
        }

        public void Update(ShareFile entity)
        {
            throw new NotImplementedException();
        }
    }
}
