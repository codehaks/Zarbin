using MediatR;
using Portal.Domain;
using Portal.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Portal.Application.BlogApplication.Queries
{
    public class FindPostQueryHandler : IRequestHandler<FindPostQuery, Post>
    {
        private readonly PortalDbContext _db;

        public FindPostQueryHandler(PortalDbContext db)
        {
            _db = db;
        }

        public async Task<Post> Handle(FindPostQuery request, CancellationToken cancellationToken)
        {
            return await _db.Posts.FindAsync(request.Id);
        }
    }
}
