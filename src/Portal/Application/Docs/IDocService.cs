using System;
using System.Threading.Tasks;
using Portal.Application.Docs.Models;

namespace Portal.Application.Docs
{
    public interface IDocService
    {
        Task<bool> Create(DocInfo docInfo);
        DocInfo GetById(Guid id);
    }
}