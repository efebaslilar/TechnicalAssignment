using AutoMapper;
using BusinessLayer.Abstracts;
using DataAccessLayer.Abstracts;
using EntityLayer.EntityModels;
using EntityLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implamentations
{
    public class CommentService : Service<CommentDTO, Comment, int>, ICommentService
    {
        public CommentService(IMapper mapper, ICommentRepo repo, string includeEntities = null) : base(mapper, repo, "AppUser,Product")
        {
        }
    }
}
