using MediatR;
using Portal.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Application.BlogApplication.Queries
{
    public class FindPostQuery:IRequest<Post>
    {
        public int Id { get; set; }
    }
}
