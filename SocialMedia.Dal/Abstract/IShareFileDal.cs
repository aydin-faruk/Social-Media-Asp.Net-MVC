using SocialMedia.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Dal.Abstract
{
    public interface IShareFileDal
    {
        ShareFile Add(ShareFile entity);
    }
}
