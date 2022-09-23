using DataAccessLayer.Abstracts;
using DataAccessLayer.ContextInfo;
using EntityLayer.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Implamentations
{
    public class CommentRepo : Repository<Comment, int>, ICommentRepo
    {
        public CommentRepo(MyContext myContext) : base(myContext)
        {
        }
    }
}
