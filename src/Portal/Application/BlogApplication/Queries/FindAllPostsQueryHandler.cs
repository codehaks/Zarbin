using AutoMapper;
using MediatR;
using Portal.Application.Blog.Models;
using Portal.Domain;
using Portal.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Portal.Core.ViewModels;

namespace Portal.Application.BlogApplication.Queries
{
    public class FindAllPostsQueryHandler : IRequestHandler<FindAllPostsQuery, IList<PostViewModel>>
    {
        private readonly PortalDbContext _db;
        private readonly IMapper _mapper;

        public FindAllPostsQueryHandler(IMapper mapper, PortalDbContext db)
        {
            _db = db;
            _mapper = mapper;
        }

 
        async Task<IList<PostViewModel>> IRequestHandler<FindAllPostsQuery, IList<PostViewModel>>.Handle(FindAllPostsQuery request, CancellationToken cancellationToken)
        {
            var model = await _db.Posts.ToListAsync();
            return model.Select(_mapper.Map<Post, PostViewModel>).ToList();
        }
    }
}
