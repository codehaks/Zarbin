using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Portal.Application.Blog.Models;
using Portal.Application.BlogApplication.Queries;
using Portal.Core.ViewModels;
using Portal.Domain;
using Portal.Persistence;

namespace Portal.Web.Pages.Blog
{
    public class IndexModel : PageModel
    {
        //private readonly IMediator _mediator;
        //private IMemoryCache _cache;
        //public IndexModel(IMediator mediator, IMemoryCache cache)
        //{
        //    _mediator = mediator;
        //    _cache = cache;

        //}

        public IList<Post> PostList { get; set; }

        public async Task<IActionResult> OnGet([FromServices]PortalDbContext db)
        {
            //if (!_cache.TryGetValue("posts", out IList<PostViewModel> model))
            //{
            //    model =await _mediator.Send(new FindAllPostsQuery());
            //    var cacheEntryOptions = new MemoryCacheEntryOptions()
            //        .SetAbsoluteExpiration(TimeSpan.FromHours(1));
            //    //.SetSlidingExpiration(TimeSpan.FromHours(3));

            //    _cache.Set("posts", model, cacheEntryOptions);
            //}

            //PostList = model;

            PostList =await db.Posts.ToListAsync();

            return Page();
        }
    }
}