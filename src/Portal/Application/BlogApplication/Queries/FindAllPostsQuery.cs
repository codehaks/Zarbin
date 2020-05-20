using MediatR;
using Portal.Application.Blog.Models;
using Portal.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Application.BlogApplication.Queries
{
    public class FindAllPostsQuery:IRequest<IList<PostViewModel>>
    {
        public int? Count { get; set; }
    }
}
